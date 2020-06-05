using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Productora.Web.Class;
using Productora.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Productora.Web.Controllers
{
    public class UsersController : Controller
    {
        readonly ApplicationDbContext db = new ApplicationDbContext();

        // GET: Users
        public ActionResult Index()
        {
            var users=db.Users.ToList();
            return View(users);
        }

        // GET: Users/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        [HttpPost]
        public ActionResult Create(UserViewModel userViewModel)
        {
            try
            {
                if (userViewModel != null)
                {
                    Utilities.CreateUserAsp(userViewModel.Email, userViewModel.Password, userViewModel.RoleName);
                    var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
                    var user = userManager.FindByName(userViewModel.Email);
                    var artist = new Artist();
                    artist.UserId = user.Id;
                    db.Artists.Add(artist);
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Users/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Users/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Users/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Users/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
