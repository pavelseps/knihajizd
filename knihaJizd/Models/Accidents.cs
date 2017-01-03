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

        [DisplayName("Čas nehody")]
        public DateTime? AccidentTime { get; set; }

        [DisplayName("Jméno druhého řidiče")]
        public string Driver2Name { get; set; }

        [DisplayName("Příjmení druhého řidiče")]
        public string Driver2Surname { get; set; }

        [DisplayName("Telefon druhého řidiče")]
        public string Driver2Phone { get; set; }

        [DisplayName("Adresa druhého řidiče")]
        public string Driver2Address { get; set; }

        [DisplayName("Č. Řidičského průkazu druhého řidiče")]
        public string Driver2DrivingLicenceId { get; set; }

        [DisplayName("Pojišťovna druhého řidiče")]
        public string Driver2InsuranceCompany { get; set; }

        [DisplayName("Název automobilu druhého řidiče")]
        public string Driver2CarName { get; set; }

        [DisplayName("Barva automobilu druhého řidiče")]
        public string Driver2CarColor { get; set; }

        [DisplayName("SPZ automobilu druhého řidiče")]
        public string Driver2SPZ { get; set; }

        [DisplayName("VIN kód druhého řidiče")]
        public string Driver2VIN { get; set; }

        [DisplayName("Fotka celé situace")]
        public string ImgSituation { get; set; }

        [DisplayName("Detailní fotka vaše vozidla")]
        public string Driver1DetailImg { get; set; }

        [DisplayName("Detailní fotka druhého vozidla")]
        public string Driver2DetailImg { get; set; }

        [DisplayName("Fotka VIN kódu vašeho vozidla")]
        public string Driver1VINImg { get; set; }

        [DisplayName("Fotka VIN kódu druhého řidiče")]
        public string Driver2VINImg { get; set; }

        [DisplayName("Poznámky")]
        [DataType(DataType.MultilineText)]
        public string Info { get; set; }

        [DisplayName("Schopné jízdy")]
        public bool DriveAble { get; set; }

        public int DriveId { get; set; }

        public virtual Drives Drives { get; set; }
    }
}
