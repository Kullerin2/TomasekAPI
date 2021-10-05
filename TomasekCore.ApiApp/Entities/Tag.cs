using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TomasekCore.ApiApp.Entities
{
    /// <summary>
    /// Represent Tag entity
    /// </summary>
    public class Tag
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public Tag(int id,string name)
        {
            ID = id;
            Name = name;
        }
    }
}
