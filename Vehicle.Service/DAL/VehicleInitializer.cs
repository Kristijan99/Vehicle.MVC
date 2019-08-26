using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicle.Service.DAL
{
    public class VehicleInitializer : DropCreateDatabaseAlways<VehicleContext>
    {
        protected override void Seed(VehicleContext context)
        {
            IList<VehicleMake> Make = new List<VehicleMake>() {
            new VehicleMake() { Id = 1, Name = "Audi", Abrv = "A" },
            new VehicleMake() { Id = 2, Name = "BMW", Abrv = "BMW" },
            new VehicleMake() { Id = 3, Name = "Fiat", Abrv = "Fi" },
            new VehicleMake() { Id = 4, Name = "Kia", Abrv = "K" },
            new VehicleMake() { Id = 5, Name = "Opel", Abrv = "Opl" },
            new VehicleMake() { Id = 6, Name = "Renault", Abrv = "Ren" },
            new VehicleMake() { Id = 7, Name = "Volkswagen", Abrv = "VW" },
            new VehicleMake() { Id = 8, Name = "Cadilac", Abrv = "Ca" },
            new VehicleMake() { Id = 9, Name = "Honda", Abrv = "Ho" },
            new VehicleMake() { Id = 10, Name = "Dacia", Abrv = "Da" },
            new VehicleMake() { Id = 11, Name = "Hyundai", Abrv = "Hyu" },
            new VehicleMake() { Id = 12, Name = "Toyota", Abrv = "Toy" },
            new VehicleMake() { Id = 13, Name = "Warturg", Abrv = "Wa" },
            new VehicleMake() { Id = 14, Name = "Porsche", Abrv = "Po" }};
            context.VehicleMakes.AddRange(Make);

            IList<VehicleModel> Model = new List<VehicleModel>() {
            new VehicleModel() { VehicleMakeId = 1, Name = "A3", Abrv = "A" },
            new VehicleModel() { VehicleMakeId = 1, Name = "A5", Abrv = "A" },
            new VehicleModel() { VehicleMakeId = 1, Name = "RS6", Abrv = "A" },
            new VehicleModel() { VehicleMakeId = 2, Name = "X6", Abrv = "BMW" },
            new VehicleModel() { VehicleMakeId = 2, Name = "serija 3 Gran Turismo", Abrv = "BMW" },
            new VehicleModel() { VehicleMakeId = 2, Name = "Z4", Abrv = "BMW" },
            new VehicleModel() { VehicleMakeId = 3, Name = "Tipo", Abrv = "Fi" },
            new VehicleModel() { VehicleMakeId = 3, Name = "Uno", Abrv = "Fi" },
            new VehicleModel() { VehicleMakeId = 4, Name = "Stronic", Abrv = "K" },
            new VehicleModel() { VehicleMakeId = 5, Name = "Astra", Abrv = "Opl" },
            new VehicleModel() { VehicleMakeId = 5, Name = "Insignia", Abrv = "Opl" },
            new VehicleModel() { VehicleMakeId = 5, Name = "Meriva", Abrv = "Opl" },
            new VehicleModel() { VehicleMakeId = 5, Name = "Vectra", Abrv = "Opl" },
            new VehicleModel() { VehicleMakeId = 5, Name = "Zafira", Abrv = "Opl" },
            new VehicleModel() { VehicleMakeId = 6, Name = "Clio", Abrv = "Ren" },
            new VehicleModel() { VehicleMakeId = 6, Name = "Laguna", Abrv = "Ren" },
            new VehicleModel() { VehicleMakeId = 6, Name = "Megane", Abrv = "Ren" },
            new VehicleModel() { VehicleMakeId = 6, Name = "Talisman", Abrv = "Ren" },
            new VehicleModel() { VehicleMakeId = 7, Name = "Golf 4", Abrv = "VW" },
            new VehicleModel() { VehicleMakeId = 7, Name = "Golf 6", Abrv = "VW" },
            new VehicleModel() { VehicleMakeId = 7, Name = "Passat", Abrv = "VW" },
            new VehicleModel() { VehicleMakeId = 7, Name = "Polo", Abrv = "VW" },
            new VehicleModel() { VehicleMakeId = 7, Name = "Touran", Abrv = "VW" } };
            context.VehicleModels.AddRange(Model);

            base.Seed(context);
        }
    }
}
