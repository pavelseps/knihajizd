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
    public class CarsController : Controller
    {
        private ModelUserDriveCarAcident db = new ModelUserDriveCarAcident();

        // GET: Cars
        public ActionResult Index()
        {
            
            var actualCarQuery = from d in db.Drives
                                  where d.StopKm == 0 || d.StopKm == null
                                  select d.User;

            if (actualCarQuery.Contains(User.Identity.GetUserId()))
            {
                return RedirectToAction("Index", "Drives");
            }


            var innerquery = from c in db.Cars
                             join d in db.Drives on c.Id equals d.Car into ps
                             from r in ps.DefaultIfEmpty()
                             where r.StopKm == 0 || r.StopKm == null
                             select c.Id;

            var innerquery2 = from d in db.Drives
                              select d.Car;

            var query = from c in db.Cars
                        where (!innerquery.Contains(c.Id) || !innerquery2.Contains(c.Id)) && c.Active == true && c.DriveAble == true
                        select c;

            return View(query);
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
