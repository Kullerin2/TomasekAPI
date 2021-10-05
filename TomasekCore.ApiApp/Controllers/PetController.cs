using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;

using TomasekCore.ApiApp.Entities;
using TomasekCore.ApiApp.Helpers;
using TomasekCore.ApiApp.Models;
using TomasekCore.ApiApp.Services;

namespace TomasekCore.Controllers
{
    /// <summary>
    /// Controller for PET function findbystatus
    /// </summary>
    [Authorize]
    [ApiController]    
    [Route("/pet/findByStatus")]
    public class PetController : ControllerBase
    {
        private IMemoryCache cache;
        private ILogger<PetController> logger;
        public PetController(IMemoryCache cache,ILogger<PetController> logger)
        {
            this.cache = cache;
            //Logging not used, should be more learned more !!
            this.logger = logger;
        }
        /// <summary>
        /// FindByStatus function, main API method
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>
        [HttpPost]
        public IEnumerable<Pet> FindByStatus(string status)
        {
            IEnumerable<Pet> result = null;

           bool hasValue =cache.TryGetValue(Constants.CACHE_KEY_PETS, out result);
            if (!hasValue)
            {
                result =GetData();

                // Set cache options
                var cacheOptions = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromMinutes(Constants.CACHE_EXPIRATION_IN_MINUTES));


                cache.Set(Constants.CACHE_KEY_PETS, result, cacheOptions); ;
            }
            
            return result.Where(pet => pet.Status == status);
            
        }
        /// <summary>
        /// Call of dummy service
        /// </summary>
        /// <returns></returns>
        private IEnumerable<Pet> GetData()
        {
            IPetService service = new DummyPetService();
            return service.GetPets();
        }        
    }
}
