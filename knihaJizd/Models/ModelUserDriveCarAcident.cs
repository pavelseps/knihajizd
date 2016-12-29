namespace knihaJizd.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ModelUserDriveCarAcident : DbContext
    {
        public ModelUserDriveCarAcident()
            : base("name=DefaultConnection")
        {
        }

        public virtual DbSet<Accidents> Accidents { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<Cars> Cars { get; set; }
        public virtual DbSet<Drives> Drives { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetUsers>()
                .HasMany(e => e.Drives)
                .WithOptional(e => e.AspNetUsers)
                .HasForeignKey(e => e.User);

            modelBuilder.Entity<Cars>()
                .HasMany(e => e.Drives)
                .WithRequired(e => e.Cars)
                .HasForeignKey(e => e.Car)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Drives>()
                .HasMany(e => e.Accidents)
                .WithRequired(e => e.Drives)
                .HasForeignKey(e => e.DriveId)
                .WillCascadeOnDelete(false);
        }
    }
}
