using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using knihaJizd.Models;
using Microsoft.AspNet.Identity;

namespace knihaJizd.Controllers
{
    public class DrivesController : Controller
    {
        private ModelUserDriveCarAcident db = new ModelUserDriveCarAcident();

        // GET: Drives
        public ActionResult Index()
        {
            var drives = db.Drives.Include(d => d.AspNetUsers).Include(d => d.Cars).OrderByDescending(d => d.StartDate);
            return View(drives.ToList());
        }

        // GET: Drives/Create
        public ActionResult Create(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Drives drives = db.Drives.Create();
            drives.User = User.Identity.GetUserId();
            drives.Car = (int) id;
            drives.StartDate = DateTime.Now;
            
            try
            {
                var query = from d in db.Drives
                            where d.Car == id
                            orderby d.StopKm descending
                            select d.StopKm;
                drives.StartKm = (int)query.FirstOrDefault();
            }
            catch
            {
                drives.StartKm = 0;
            }

            ViewBag.User = new SelectList(db.AspNetUsers.Where(u => u.Id == drives.User), "Id", "Email");
            ViewBag.Car = new SelectList(db.Cars.Where(c => c.Id == drives.Car), "Id", "Name");
            return View(drives);
        }

        // POST: Drives/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,User,Car,Acident,StartDate,StopDate,StartKm,StopKm")] Drives drives)
        {
            if (ModelState.IsValid)
            {
                db.Drives.Add(drives);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.User = new SelectList(db.AspNetUsers, "Id", "Email", drives.User);
            ViewBag.Car = new SelectList(db.Cars, "Id", "Name", drives.Car);
            return View(drives);
        }

        // GET: Drives/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Drives drives = db.Drives.Find(id);
            if (drives == null)
            {
                return HttpNotFound();
            }
            ViewBag.User = new SelectList(db.AspNetUsers, "Id", "Email", drives.User);
            ViewBag.Car = new SelectList(db.Cars, "Id", "Name", drives.Car);
            drives.StopDate = DateTime.Now;
            
            return View(drives);
        }

        // POST: Drives/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,User,Car,Acident,StartDate,StopDate,StartKm,StopKm")] Drives drives)
        {
            if (ModelState.IsValid && drives.StartKm <= drives.StopKm && drives.StartDate <= drives.StopDate)
            {
                db.Entry(drives).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            if (drives.StartKm > drives.StopKm)
            {
                ViewBag.KmError = "Špatně zadané km";
            }

            if (drives.StartDate > drives.StopDate)
            {
                ViewBag.DateError = "Špatně zadaný datum";
            }

            ViewBag.User = new SelectList(db.AspNetUsers, "Id", "Email", drives.User);
            ViewBag.Car = new SelectList(db.Cars, "Id", "Name", drives.Car);
            return View(drives);
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
