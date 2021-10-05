using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TomasekCore.ApiApp.Entities
{
    /// <summary>
    /// Category entity for result
    /// </summary>
    public class Category
    {
        public Category(int id, string name)
        {
            this.ID = id;
            this.Name = name;
        }
        public int ID { get; set;        }
        public string Name { get; set; }
    }
}
