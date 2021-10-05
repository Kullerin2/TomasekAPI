This is public repository for Tomasek API solution

1. Read the Journey about my progress during time spent on task
2. Read Tomasek.tf if everything is well prepared for new API. I didn't used the variables, so names are hardcoded
3. Run Terraform Init , Terraform Plan, Terraform Apply with Tomasek.tf.  I think also AZ Login will be needed. The subscriptionid is not used

What the script doing?

Creating the new Resource, Api Managements service, Api service, Operation and finally Operation Policy
 
The created API has operation POST findByStatus with authentication, and there is something like workflow defined in inbound section.
That part is calling the GET of original api, and transform that to POST, also the CACHE mechanism is used there

Testing: run the service after API is created ( 45 min)
Use this as input body with JSON format 
{"status":"sold"}


Look at TomasekCore.ApiApp , where I prepared the API in .Net core, but this isn't needed. More info in Journey.txt

Libor Tomasek


