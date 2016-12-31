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
    public class AdministrationController : Controller
    {
        private ModelUserDriveCarAcident db = new ModelUserDriveCarAcident();

        private bool isAdministrator()
        {
            return db.AspNetUsers.Find(User.Identity.GetUserId()).Admin;
        }

        // GET: Accidents list
        public ActionResult Accidents()
        {
            if (!isAdministrator())
            {
                return RedirectToAction("Error", "Administration");
            }
            var returnVal = db.Accidents.ToList();

            if(returnVal.Count != 0)
            {
                returnVal.Reverse();
            }

            return View(returnVal);
        }

        // GET: Accidents/Details/5
        public ActionResult AccidentsDetails(int? id)
        {
            if (!isAdministrator())
            {
                return RedirectToAction("Error", "Administration");
            }

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Accidents accidents = db.Accidents.Find(id);
            if (accidents == null)
            {
                return HttpNotFound();
            }
            return View(accidents);
        }




        // GET: Cars list
        public ActionResult Cars()
        {
            if (!isAdministrator())
            {
                return RedirectToAction("Error", "Administration");
            }

            var cars = db.Cars.Where(c => c.Active == true);

            return View(cars.ToList());
        }

        // GET: Cars/Create
        public ActionResult CarsCreate()
        {
            if (!isAdministrator())
            {
                return RedirectToAction("Error", "Administration");
            }

            return View();
        }

        // POST: Cars/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CarsCreate([Bind(Include = "Id,Name,VIN,SPZ,Color,Photo")] Cars cars)
        {
            if (!isAdministrator())
            {
                return RedirectToAction("Error", "Administration");
            }

            cars.Active = true;

            if (ModelState.IsValid)
            {
                cars.DriveAble = true;
                db.Cars.Add(cars);
                db.SaveChanges();
                return RedirectToAction("Cars");
            }

            return View(cars);
        }

        // GET: Cars/Edit/5
        public ActionResult CarsEdit(int? id)
        {
            if (!isAdministrator())
            {
                return RedirectToAction("Error", "Administration");
            }

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cars cars = db.Cars.Find(id);
            if (cars == null)
            {
                return HttpNotFound();
            }
            return View(cars);
        }

        // POST: Cars/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CarsEdit([Bind(Include = "Id,Name,VIN,SPZ,Color,Photo,DriveAble")] Cars cars)
        {
            if (!isAdministrator())
            {
                return RedirectToAction("Error", "Administration");
            }
            cars.Active = true;
            if (ModelState.IsValid)
            {
                db.Entry(cars).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Cars");
            }
            return View(cars);
        }

        // GET: Cars/Delete/5
        public ActionResult CarsDelete(int? id)
        {
            if (!isAdministrator())
            {
                return RedirectToAction("Error", "Administration");
            }

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cars cars = db.Cars.Find(id);
            if (cars == null)
            {
                return HttpNotFound();
            }
            return View(cars);
        }

        // POST: Cars/Delete/5
        [HttpPost, ActionName("CarsDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult CarsDeleteConfirmed(int id)
        {
            if (id == null)
            {
                return View("Cars");
            }

            if (!isAdministrator())
            {
                return RedirectToAction("Error", "Administration");
            }

            Cars cars = db.Cars.Find(id);
            if (cars == null)
            {
                return HttpNotFound();
            }

            cars.Active = false;
            db.Entry(cars).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Cars");
        }





        // GET: Drives list
        public ActionResult Drives()
        {
            if (!isAdministrator())
            {
                return RedirectToAction("Error", "Administration");
            }

            return View(db.Drives.OrderByDescending(d => d.StartDate).ToList());
        }

        // GET: Users list
        public ActionResult Users()
        {
            if (!isAdministrator())
            {
                return RedirectToAction("Error", "Administration");
            }

            var users = db.AspNetUsers.Where(u => u.Active == true);

            return View(users.ToList());
        }

        // GET: Users Detail
        public ActionResult UsersDetail(string id)
        {
            if(id == "")
            {
                return RedirectToAction("Users", "Administration");
            }

            if (!isAdministrator())
            {
                return RedirectToAction("Error", "Administration");
            }

            var users = db.AspNetUsers.Find(id);

            if (users == null)
            {
                return HttpNotFound();
            }

            return View(users);
        }

        // GET: Users Edit
        public ActionResult UsersEdit(string id)
        {
            if (id == "")
            {
                return RedirectToAction("Users", "Administration");
            }

            if (!isAdministrator())
            {
                return RedirectToAction("Error", "Administration");
            }
            var users = db.AspNetUsers.Find(id);

            users.Active = true;

            if (users == null)
            {
                return HttpNotFound();
            }

            return View(users);
        }

        // POST: User/Edit
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UsersEdit([Bind(Include = "Id,Name,Surname,Address,Email,PhoneNumber,DrivingLicenceId, Admin")] IndexViewModel model, string id)
        {
            if (id == "")
            {
                return RedirectToAction("Users", "Administration");
            }

            if (!isAdministrator())
            {
                return RedirectToAction("Error", "Administration");
            }

            if (ModelState.IsValid)
            {
                AspNetUsers user = db.AspNetUsers.Find(id);
                user.Name = model.Name;
                user.Surname = model.Surname;
                user.Address = model.Address;
                user.Email = model.Email;
                user.PhoneNumber = model.PhoneNumber;
                user.DrivingLicenceId = model.DrivingLicenceId;

                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Users");
            }
            return View(model);
        }

        // GET: Users/Delete/5
        public ActionResult UsersDelete(string id)
        {
            if (id == "")
            {
                return RedirectToAction("Users", "Administration");
            }

            if (!isAdministrator())
            {
                return RedirectToAction("Error", "Administration");
            }

            AspNetUsers user = db.AspNetUsers.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("UsersDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult UsersDeleteConfirmed(string id)
        {
            
            if (id == "")
            {
                return View("Users");
            }

            if (!isAdministrator())
            {
                return RedirectToAction("Error", "Administration");
            }

            AspNetUsers user = db.AspNetUsers.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }

            user.Active = false;
            db.Entry(user).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Users");
        }





        // GET: Index
        public ActionResult Index()
        {
            if (!isAdministrator())
            {
                return RedirectToAction("Error", "Administration");
            }

            return View();
        }

        // GET: Error
        public ActionResult Error()
        {
            return View();
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
