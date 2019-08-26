using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Vehicle.MVC.Models
{
    public class VehicleModelView
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Abrv { get; set; }

        public int VehicleMakeId { get; set; }

        public virtual VehicleMakeView VehicleMake { get; set; }

        public IList<SelectListItem> VehicleMakes { get; set; }
    }
}