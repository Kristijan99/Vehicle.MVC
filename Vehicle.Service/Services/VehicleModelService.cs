using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicle.Service.DAL;
using AutoMapper;
using PagedList;
using System.Data.Entity;

namespace Vehicle.Service.Services
{
    public class VehicleModelService
    {
        VehicleContext context = new VehicleContext();

        public void Create(VehicleModel model)
        {
            context.VehicleModels.Add(Mapper.Map<VehicleModel>(model));
            context.SaveChanges();
        }

        public IEnumerable<VehicleMake> GetMakes()
        {
            return context.VehicleMakes.AsEnumerable();
        }

        public IPagedList<VehicleModel> Get(Parameters.SortParameters sortParameters,
            Parameters.FilterParameters filterParameters, Parameters.PageParameters pageParameters)
        {
            var model = context.VehicleModels.AsEnumerable();
            switch (sortParameters.Sort)
            {
                case "model":  // Name ascending 
                    model = model.OrderBy(m => m.Name);
                    break;
                case "model_desc":
                    model = model.OrderByDescending(m => m.Name);
                    break;
                case "abrv":
                    model = model.OrderBy(m => m.Abrv);
                    break;
                case "abrv_desc":
                    model = model.OrderByDescending(m => m.Abrv);
                    break;
                case "make":
                    model = model.OrderBy(m => m.VehicleMake.Name);
                    break;
                case "make_desc":
                    model = model.OrderByDescending(m => m.VehicleMake.Name);
                    break;
                default:
                    model = model.OrderBy(m => m.VehicleMake.Name);
                    break;
            }
            if (!string.IsNullOrEmpty(filterParameters.Search))
            {
                var search = filterParameters.Search.ToUpper();
                model = model.Where(c => c.Name.ToUpper().Contains(search) | 
                                    c.Abrv.ToUpper().Contains(search) |
                                    c.VehicleMake.Name.ToUpper().Contains(search));
            }
            return model.ToPagedList(pageParameters.Page, pageParameters.PageSize);
        }

        public void Delete(VehicleModel model)
        {
            context.VehicleModels.Remove(context.VehicleModels.Where(c => c.Id == model.Id).FirstOrDefault());
            context.SaveChanges();
        }

        public VehicleModel Find(int? id)
        {
            return context.VehicleModels.Where(c => c.Id == id).FirstOrDefault();
        }

        public void Edit(VehicleModel model)
        {
            context.Entry(model).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}
