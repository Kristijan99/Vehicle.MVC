using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Vehicle.Service.DAL
{
    public class VehicleContext : DbContext
    {
        public VehicleContext() : base("name=VehicleContext")
        {
            Database.SetInitializer(new VehicleInitializer());
        }

        public DbSet<VehicleMake> VehicleMakes { get; set; }

        public DbSet<VehicleModel> VehicleModels { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VehicleMake>()
                .HasMany(e => e.VehicleModels)
                .WithOptional(e => e.VehicleMake)
                .HasForeignKey(e => e.VehicleMakeId);
        }
    }
}
