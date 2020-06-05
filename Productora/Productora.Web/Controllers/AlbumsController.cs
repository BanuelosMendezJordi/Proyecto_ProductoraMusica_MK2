using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Productora.Web.Models;

namespace Productora.Web.Controllers
{
    public class AlbumsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult AllAlbums()
        {
            var albums = db.Albums.Include(o => o.Artist).Include(u => u.Artist.ApplicationUser).ToList();
            return View(albums);
        }
        // GET: Albums
        public ActionResult Index()
        {
            var user = User.Identity.GetUserId();
            var ar = db.Artists.Where(o => o.UserId == user).FirstOrDefault();
            var albums = db.Albums.Include(a => a.Artist).Where(p => p.ArtistId == ar.Id).ToList();
            return View(albums);
        }

        // GET: Albums/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Album album = db.Albums.Find(id);
            if (album == null)
            {
                return HttpNotFound();
            }
            return View(album);
        }

        // GET: Albums/Create
        public ActionResult Create()
        {
            ViewBag.ArtistId = new SelectList(db.Artists, "Id", "StageName");
            return View();
        }

        // POST: Albums/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Album album, HttpPostedFileBase hpb)
        {

            if (ModelState.IsValid)
            {
                if (hpb != null)
                {
                    string pictureName = System.IO.Path.GetFileName(hpb.FileName);
                    string picturePath = "~/Content/img/AlbumCovers/" + album.AlbumName + "_" + pictureName;
                    hpb.SaveAs(Server.MapPath(picturePath));
                    album.Album_Cover = album.AlbumName + "_" + pictureName;
                }
                var userId = User.Identity.GetUserId();
                var art = db.Artists.Where(a => a.UserId== userId).FirstOrDefault();
                album.ArtistId = art.Id;
                db.Albums.Add(album);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(album);
        }

        // GET: Albums/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Album album = db.Albums.Find(id);
            if (album == null)
            {
                return HttpNotFound();
            }
            return View(album);
        }

        // POST: Albums/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,AlbumName,AlbumDescription,AlbumRelease,AlbumCover,ArtistId")] Album album)
        {
            if (ModelState.IsValid)
            {
                db.Entry(album).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(album);
        }

        // GET: Albums/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Album album = db.Albums.Find(id);
            if (album == null)
            {
                return HttpNotFound();
            }
            return View(album);
        }

        // POST: Albums/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Album album = db.Albums.Find(id);
            db.Albums.Remove(album);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
