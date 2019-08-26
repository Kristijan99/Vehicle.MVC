using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vehicle.MVC.Models;
using Vehicle.Service.DAL;

namespace Vehicle.MVC.App_Start
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<VehicleMake, VehicleMakeView>().ReverseMap();
            CreateMap<VehicleModel, VehicleModelView>().ReverseMap();
        }
    }
}