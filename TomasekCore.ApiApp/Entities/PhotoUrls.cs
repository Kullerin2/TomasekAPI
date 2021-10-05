using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TomasekCore.ApiApp.Entities
{
    /// <summary>
    /// That represent PhotoUrls, designed only for reason to have 'PhotoUrl' in json result
    /// </summary>
    public class PhotoUrls
    {
        public string[] PhotoUrl { get; set; }
        public PhotoUrls(string[] urls)
        {
            this.PhotoUrl = urls;
        }
    }
}
