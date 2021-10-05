# Configure the Azure provider
terraform {
  required_providers {
    azurerm = {
      source  = "hashicorp/azurerm"
      version = "~> 2.65"
    }
  }

  required_version = ">= 0.14.9"
}

provider "azurerm" {
  features{}
}

resource "azurerm_resource_group" "TomasekRG" {
  name     = "TomasekRG"
  location = "GermanyWestCentral"
}

resource "azurerm_api_management" "TomasekAPIM" {
  name                = "TomasekAPIM"
  location            = azurerm_resource_group.TomasekRG.location
  resource_group_name = azurerm_resource_group.TomasekRG.name
  publisher_name      = "Tomasek	"
  publisher_email     = "kullerincz@gmail.com"

  sku_name = "Developer_1"
}

resource "azurerm_api_management_api" "TomasekAPI" {
  name                = "TomasekAPI"
  resource_group_name = azurerm_resource_group.TomasekRG.name
  api_management_name = azurerm_api_management.TomasekAPIM.name
  revision            = "1"
  display_name        = "TomasekAPI"
  path                = ""
  protocols           = ["https"] 
  subscription_required = "false"

  

}

resource "azurerm_api_management_api_operation" "findByStatus" {
  operation_id        = "findByStatus"
  api_name            = azurerm_api_management_api.TomasekAPI.name
  api_management_name = azurerm_api_management.TomasekAPIM.name  
  resource_group_name = azurerm_resource_group.TomasekRG.name
  display_name        = "findByStatus"
  method              = "POST"
  url_template        = "/findByStatus"
  description         = "This can only be done by the logged in user"

  response {
    status_code = 200
  }
}

resource "azurerm_api_management_api_operation_policy" "findByStatusPolicy" {
  api_name            = azurerm_api_management_api.TomasekAPI.name
  api_management_name = azurerm_api_management.TomasekAPIM.name  
  resource_group_name = azurerm_resource_group.TomasekRG.name
  operation_id        = azurerm_api_management_api_operation.findByStatus.operation_id

  xml_content = <<XML
    <policies>  
      <inbound>
        <base />
        <set-header name="Ocp-Apim-Subscription-Key" exists-action="delete" />
        <set-variable name="status" value="@{
        JObject json = context.Request.Body.As<JObject>();
        var code = json.GetValue("status").ToString();
        return code;
        }" />
        <set-variable name="cacheKey" value="@("cacheFindByStatus-"+context.Variables["status"])" />
        <cache-lookup-value key="@((string)context.Variables["cacheKey"])" variable-name="response" />
        <choose>
            <when condition="@(!context.Variables.ContainsKey("response"))">
                <send-request mode="new" response-variable-name="CAllPetStore" timeout="20" ignore-error="true">
                    <set-url>@($"https://petstore.swagger.io/v2/pet/findByStatus?status={context.Variables["status"]}")</set-url>
                    <set-method>GET</set-method>
                </send-request>
                <choose>
                    <when condition="@((int)((IResponse)context.Variables["CAllPetStore"]).StatusCode == 200)">
                        <set-variable name="response" value="@{
            return ((IResponse)context.Variables["CAllPetStore"]).Body.As<string>(preserveContent: true);
            
            }" />
                        <cache-store-value key="@((string)context.Variables["cacheKey"])" value="@((string)context.Variables["response"])" duration="300" />
                    </when>
                    <when condition="@((int)((IResponse)context.Variables["CAllPetStore"]).StatusCode != 200)">
                        <return-response>
                            <set-status code="500" reason="Server internal error" />
                            <set-header name="Content-Type" exists-action="override">
                                <value>application/json</value>
                            </set-header>
                            <set-body>@{
            return ((IResponse)context.Variables["CAllPetStore"]).Body.As<string>(preserveContent: true);
            
            }</set-body>
                        </return-response>
                    </when>
                </choose>
            </when>
        </choose>
        <return-response>
            <set-status code="200" reason="OK" />
            <set-header name="Content-Type" exists-action="override">
                <value>application/json</value>
            </set-header>
            <set-body>@{
            return (string)context.Variables["response"];
            }</set-body>
        </return-response>
        <authentication-basic username="test" password="test" />
    </inbound>
    </policies>
  XML
}

	

