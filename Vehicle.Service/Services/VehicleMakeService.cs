using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicle.Service.DAL;
using AutoMapper;
using PagedList;

namespace Vehicle.Service.Services
{
    public class VehicleMakeService
    {
        VehicleContext context = new VehicleContext();

        public void Create(VehicleMake make)
        { 
            context.VehicleMakes.Add(Mapper.Map<VehicleMake>(make));
            context.SaveChanges();
        }

        public IPagedList<VehicleMake> Get(Parameters.SortParameters sortParameters, 
            Parameters.FilterParameters filterParameters, Parameters.PageParameters pageParameters)
        {
            var model = context.VehicleMakes.AsEnumerable();
            switch (sortParameters.Sort)
            {
                case "name":  // Name ascending 
                    model = model.OrderBy(m => m.Name);
                    break;
                case "name_desc":
                    model = model.OrderByDescending(m => m.Name);
                    break;
                case "abrv":
                    model = model.OrderBy(m => m.Abrv);
                    break;
                case "abrv_desc":
                    model = model.OrderByDescending(m => m.Abrv);
                    break;
                default:
                    model = model.OrderBy(m => m.Name);
                    break;
            }
            if (!string.IsNullOrEmpty(filterParameters.Search))
            {
                var search = filterParameters.Search.ToUpper();
                model = model.Where(c => c.Name.ToUpper().Contains(search) | c.Abrv.ToUpper().Contains(search));
            }
            return model.ToPagedList(pageParameters.Page, pageParameters.PageSize);
        }

        public void Delete (VehicleMake make)
        {
                context.VehicleMakes.Remove(context.VehicleMakes.Where(c => c.Id == make.Id).FirstOrDefault());
                context.SaveChanges();
        }

        public VehicleMake Find (int? id)
        {
            return context.VehicleMakes.Where(c => c.Id == id).FirstOrDefault();
        }

        public void Edit (VehicleMake make)
        {
            context.Entry(make).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}
