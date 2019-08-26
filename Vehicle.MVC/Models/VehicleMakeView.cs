using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vehicle.Service.DAL;

namespace Vehicle.MVC.Models
{
    public class VehicleMakeView
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Abrv { get; set; }

        public virtual ICollection<VehicleModelView> VehicleModels { get; set; }
    }
}