using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TomasekCore.ApiApp.Entities
{
    /// <summary>
    /// Represent User entity
    /// </summary>
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
