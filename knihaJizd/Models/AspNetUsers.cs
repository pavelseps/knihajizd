namespace knihaJizd.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class AspNetUsers
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AspNetUsers()
        {
            Drives = new HashSet<Drives>();
        }

        public string Id { get; set; }

        [StringLength(256)]
        [DisplayName("E-Mail")]
        public string Email { get; set; }

        public bool EmailConfirmed { get; set; }

        public string PasswordHash { get; set; }

        public string SecurityStamp { get; set; }

        [DisplayName("Telefoní číslo")]
        public string PhoneNumber { get; set; }

        public bool PhoneNumberConfirmed { get; set; }

        public bool TwoFactorEnabled { get; set; }

        public DateTime? LockoutEndDateUtc { get; set; }

        public bool LockoutEnabled { get; set; }

        public int AccessFailedCount { get; set; }

        [Required]
        [StringLength(256)]
        [DisplayName("Uživatelské jmeno")]
        public string UserName { get; set; }

        [DisplayName("Administrator")]
        public bool Admin { get; set; }

        [DisplayName("Jméno")]
        public string Name { get; set; }

        [DisplayName("Příjmení")]
        public string Surname { get; set; }

        [DisplayName("Adresa")]
        public string Address { get; set; }

        [DisplayName("Č. Řidického průkazu")]
        public string DrivingLicenceId { get; set; }


        public bool Active { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Drives> Drives { get; set; }
    }
}
