using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TomasekCore.ApiApp.Entities;

namespace TomasekCore.ApiApp.Helpers
{
    /// <summary>
    /// Not necesary, copied for get user without passowrd
    /// </summary>
    public static class ExtensionMethods
    {
        public static IEnumerable<User> WithoutPasswords(this IEnumerable<User> users)
        {
            return users.Select(x => x.WithoutPassword());
        }

        public static User WithoutPassword(this User user)
        {
            user.Password = null;
            return user;
        }
    }
}
