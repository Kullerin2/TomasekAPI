using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TomasekCore.ApiApp.Entities;

namespace TomasekCore.ApiApp.Services
{
    /// <summary>
    /// Define Interface for service
    /// </summary>
    public interface IPetService
    {
        IEnumerable<Pet> GetPets();
    }
    /// <summary>
    /// Gets dummy set of Pets
    /// </summary>
    public class DummyPetService : IPetService
    {
        public IEnumerable<Pet> GetPets()
        { 
            return new Pet[] {
                new Pet(1,"Chichi","available", new Category(1,"Cat"),new Tag[]{ new Tag(1,"Tag#1")},new PhotoUrls(new string[] {"http://cat1.png","http://cat2.png" })),
                new Pet(2,"MnauMnau","sold",new Category(1,"Cat"),new Tag[]{ new Tag(1,"Tag#1")},new PhotoUrls(new string[] {"http://cat3.png"})),
                new Pet(3,"Tom","pending",new Category(1,"Cat"),new Tag[]{ new Tag(1,"Tag#1")},new PhotoUrls(new string[] {"http://cat4.png"})),
                new Pet(4,"Jerry","pending",new Category(2,"Mouse"),new Tag[]{ new Tag(2,"Tag#2")},new PhotoUrls(new string[] {"http://jerry.png"})),
                new Pet(5,"Mickey","pending",new Category(2,"Mouse"),new Tag[]{ new Tag(2,"Tag#2")},new PhotoUrls(new string[] {"http://mickeymouse.png"})),

                new Pet(6,"Beethoven","pending", new Category(3,"Dog"),new Tag[]{ new Tag(3,"Tag#3")},new PhotoUrls(new string[] {"http://beethoven.png"})),
            };
        }
    }
}
