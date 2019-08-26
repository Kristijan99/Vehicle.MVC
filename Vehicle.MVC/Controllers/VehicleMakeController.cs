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
    public class VehicleMakeController : Controller
    {
        VehicleMakeService make = new VehicleMakeService();
        
        public ActionResult Index(int? page, string sort, string search)
        {
            var sortPar = new Parameters.SortParameters() { Sort = sort };
            var filterPar = new Parameters.FilterParameters() { Search = search };
            var pagePar = new Parameters.PageParameters() { Page = page ?? 1, PageSize = 7 };
            var vehicleMake = make.Get(sortPar, filterPar, pagePar);
            ViewBag.sort = sort;
            ViewBag.name = sort == "name_desc" ? "name" : "name_desc";
            ViewBag.abrv = sort == "abrv_desc" ? "abrv" : "abrv_desc";
            ViewBag.search = search;
            var list = Mapper.Map<IEnumerable<VehicleMake>, IEnumerable<VehicleMakeView>>(vehicleMake);
            return View(new StaticPagedList<VehicleMakeView>(list, vehicleMake.GetMetaData()));
        }

        [HttpGet]
        public ActionResult Delete (int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else
            {
                var vehicleId = make.Find(id);
                if (vehicleId == null)
                {
                    return HttpNotFound();
                }
                return View(Mapper.Map<VehicleMakeView>(vehicleId));
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(VehicleMakeView makes)
        {
            try
            {
                make.Delete(Mapper.Map<VehicleMake>(makes));
                return RedirectToAction("Index");
            }
            catch (Exception) { }
            return RedirectToAction("Delete", makes.Id);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name,Abrv")] VehicleMakeView makes)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    make.Create(Mapper.Map<VehicleMake>(makes));
                    return RedirectToAction("Index");
                }
            }
            catch (DataException) { }
            return RedirectToAction("Create");
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else
            {
                var vehicleMake = make.Find(id);
                if (vehicleMake == null)
                {
                    return HttpNotFound();
                }
                return View(Mapper.Map<VehicleMakeView>(vehicleMake));
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Abrv")] VehicleMakeView makes)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    make.Edit(Mapper.Map<VehicleMake>(makes));
                    return RedirectToAction("Index");
                }
            }
            catch (DataException) { }
            return RedirectToAction("Edit", makes.Id);
        }

    }
}