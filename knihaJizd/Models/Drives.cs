namespace knihaJizd.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Drives
    {
        public int Id { get; set; }

        [StringLength(128)]
        public string User { get; set; }

        public int Car { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? StopDate { get; set; }

        public int StartKm { get; set; }

        public int? StopKm { get; set; }

        public virtual AspNetUsers AspNetUsers { get; set; }

        public virtual Cars Cars { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Accidents> Accidents { get; set; }
    }
}
