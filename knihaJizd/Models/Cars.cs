namespace knihaJizd.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Cars
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Cars()
        {
            Drives = new HashSet<Drives>();
        }

        public int Id { get; set; }

        [Required]
        [DisplayName("Název")]
        public string Name { get; set; }

        [Required]
        [DisplayName("VIN Kód")]
        public string VIN { get; set; }

        [Required]
        [DisplayName("Státní poznávaci značka")]
        public string SPZ { get; set; }

        [DisplayName("Barva")]
        public string Color { get; set; }

        [DisplayName("Fotka")]
        public string Photo { get; set; }
        public bool Active { get; set; }
        [DisplayName("Jízdy schopné")]
        public bool DriveAble { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Drives> Drives { get; set; }
    }
}
