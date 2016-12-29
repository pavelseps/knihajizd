using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using knihaJizd.Models;

namespace knihaJizd.Controllers
{
    public class AccidentsController : Controller
    {
        private ModelUserDriveCarAcident db = new ModelUserDriveCarAcident();
        

        // GET: Accidents/Create
        public ActionResult Create(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Accidents accidents = db.Accidents.Create();
            accidents.DriveId = (int) id;
            accidents.AccidentTime = DateTime.Now;
            return View(accidents);
        }

        // POST: Accidents/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,AccidentAddress,Driver2Name,Driver2Surname,Driver2Phone,Driver2Address,Driver2DrivingLicenceId,Driver2InsuranceCompany,Driver2CarName,Driver2CarColor,Driver2SPZ,Driver2VIN,ImgSituation,Driver1DetailImg,Driver2DetailImg,Driver1VINImg,Driver2VINImg,Info,DriveAble,DriveId")] Accidents accidents)
        {
            if (ModelState.IsValid)
            {
                if (!accidents.DriveAble)
                {
                    var drive = db.Drives.Find(accidents.DriveId);
                    drive.StopDate = DateTime.Now;
                    drive.StopKm = drive.StartKm;

                    var car = db.Cars.Find(drive.Car);

                    car.DriveAble = false;

                    db.Entry(car).State = EntityState.Modified;
                    db.Entry(drive).State = EntityState.Modified;
                    db.SaveChanges();
                }


                db.Accidents.Add(accidents);
                db.SaveChanges();
                return RedirectToAction("../Cars");
            }

            return View(accidents);
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
