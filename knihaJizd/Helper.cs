using knihaJizd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace knihaJizd
{
    public class Helper
    {
        //private static ModelUserDriveCarAcident db = new ModelUserDriveCarAcident();


        public static bool isAdmin(string id)
        {
            ModelUserDriveCarAcident db = new ModelUserDriveCarAcident();
            var user = db.AspNetUsers.Find(id);
            return user.Admin;
        }
    }
}