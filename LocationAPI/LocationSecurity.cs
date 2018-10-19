using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LocationAPI.Models;

namespace LocationAPI
{
    public class LocationSecurity
    {
        public static bool login(string username, string password)
        {
            using (LocationDBEntities dbContext = new LocationDBEntities())
            {
                return dbContext.Users.Any(user => user.UserName.Equals(username, StringComparison.OrdinalIgnoreCase) && user.Password == password);
            }
        }
    }
}