using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Productora.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Productora.Web.Class
{
    public class Utilities
    {
        readonly static ApplicationDbContext db = new ApplicationDbContext();
        public static void CheckRoles(string roleName)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
            if (!roleManager.RoleExists(roleName))
            {
                roleManager.Create(new IdentityRole(roleName));
            }
        }
        //public void Dispose()
        //{
        //    db.Dispose();
        //}

        internal static void CheckSuperUser()
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            var userAsp = userManager.FindByName("Administrador@mail.com");

            if (userAsp == null)
            {
                CreateUserAsp("Administrador@mail.com", "QWERTY", "Admin");
            }
        }

        internal static void CheckClientDefault()
        {
            var clientdb = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            var userClient = clientdb.FindByEmail("Artista@mail.com");
            if (userClient == null)
            {
                CreateUserAsp("Artista@mail.com", "QWERTY", "Artist");
            }
        }
        public static void CreateUserAsp(string email, string password, string rol)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            var userASP = new ApplicationUser()
            {
                UserName = email,
                Email = email,
            };
            userManager.Create(userASP, password);
            userManager.AddToRole(userASP.Id, rol);
        }
    }
}