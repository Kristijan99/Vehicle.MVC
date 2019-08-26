using AutoMapper;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Vehicle.MVC.Models;
using Vehicle.Service.DAL;
using Vehicle.Service.Services;

namespace Vehicle.MVC.Controllers
{
    public class VehicleModelController : Controller
    {
        VehicleModelService model = new VehicleModelService();

        public ActionResult Index(int? page, string sort, string search)
        {
            var sortPar = new Parameters.SortParameters() { Sort = sort };
            var filterPar = new Parameters.FilterParameters() { Search = search };
            var pagePar = new Parameters.PageParameters() { Page = page ?? 1, PageSize = 10 };
            var vehicleModel = model.Get(sortPar, filterPar, pagePar);
            ViewBag.sort = sort;
            ViewBag.model = sort == "model_desc" ? "model" : "model_desc";
            ViewBag.make = sort == "make_desc" ? "make" : "make_desc";
            ViewBag.abrv = sort == "abrv_desc" ? "abrv" : "abrv_desc";
            ViewBag.search = search;
            var list = Mapper.Map<IEnumerable<VehicleModel>, IEnumerable<VehicleModelView>>(vehicleModel);
            return View(new StaticPagedList<VehicleModelView>(list, vehicleModel.GetMetaData()));
        }

        [HttpGet]
        public ActionResult Create()
        {
            VehicleModelView vehicleModel = new VehicleModelView()
            {
                VehicleMakes = Mapper.Map<IList<SelectListItem>>
                               (model.GetMakes().Select
                               (c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name }))
            };
            return View(vehicleModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(VehicleModelView models)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    model.Create(Mapper.Map<VehicleModel>(models));
                    return RedirectToAction("Index");
                }
            }
            catch (DataException) { }
            return RedirectToAction("Create");
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else
            {
                var vehicleId = model.Find(id);
                if (vehicleId == null)
                {
                    return HttpNotFound();
                }
                return View(Mapper.Map<VehicleModelView>(vehicleId));
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(VehicleModelView models)
        {
            try
            {
                model.Delete(Mapper.Map<VehicleModel>(models));
                return RedirectToAction("Index");
            }
            catch (Exception) { }
            return RedirectToAction("Delete", models.Id);
        }

        [HttpGet]
        public ActionResult Edit( int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else
            {
                var models = model.Find(id);
                if (models == null)
                {
                    return HttpNotFound();
                }
                var result = Mapper.Map<VehicleModel, VehicleModelView>(models);
                result.VehicleMakes = Mapper.Map<IList<SelectListItem>>
                                      (model.GetMakes().Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name }));
                return View(result);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,VehicleMakeId,Name,Abrv")] VehicleModelView models)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    model.Edit(Mapper.Map<VehicleModel>(models));
                    return RedirectToAction("Index");
                }
            }
            catch (DataException) { }
            return RedirectToAction("Edit", models.Id);
        }

    }
}