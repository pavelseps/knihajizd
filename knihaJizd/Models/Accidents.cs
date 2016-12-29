namespace knihaJizd.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Accidents
    {
        public int Id { get; set; }

        [DisplayName("Adresa nehody")]
        public string AccidentAddress { get; set; }

        [DisplayName("Èas nehody")]
        public DateTime? AccidentTime { get; set; }

        public string Driver2Name { get; set; }

        public string Driver2Surname { get; set; }

        public string Driver2Phone { get; set; }

        public string Driver2Address { get; set; }

        public string Driver2DrivingLicenceId { get; set; }

        public string Driver2InsuranceCompany { get; set; }

        public string Driver2CarName { get; set; }

        public string Driver2CarColor { get; set; }

        public string Driver2SPZ { get; set; }

        public string Driver2VIN { get; set; }
        
        public string ImgSituation { get; set; }
        
        public string Driver1DetailImg { get; set; }
        
        public string Driver2DetailImg { get; set; }
        
        public string Driver1VINImg { get; set; }
        
        public string Driver2VINImg { get; set; }

        public string Info { get; set; }

        public bool DriveAble { get; set; }

        public int DriveId { get; set; }

        public virtual Drives Drives { get; set; }
    }
}
