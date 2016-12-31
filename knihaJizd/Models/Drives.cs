namespace knihaJizd.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Drives
    {
        public int Id { get; set; }

        [StringLength(128)]
        [DisplayName("Uživatel")]
        public string User { get; set; }

        [DisplayName("Auto")]
        public int Car { get; set; }

        [DisplayName("Čas začátku")]
        public DateTime? StartDate { get; set; }

        [DisplayName("Čas konce")]
        public DateTime? StopDate { get; set; }

        [DisplayName("Počáteční stav km")]
        public int StartKm { get; set; }

        [DisplayName("Konečný stav km")]
        public int? StopKm { get; set; }

        public virtual AspNetUsers AspNetUsers { get; set; }

        public virtual Cars Cars { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Accidents> Accidents { get; set; }
    }
}
