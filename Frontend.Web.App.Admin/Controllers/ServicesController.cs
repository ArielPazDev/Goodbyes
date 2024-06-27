﻿using Goodbyes.Backend.Services.DB.Entities;
using Goodbyes.Backend.Services.DB.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Frontend.Web.App.Admin.Controllers
{
    public class ServicesController : Controller
    {
        private ServicesModel servicesModel = new ServicesModel();

        // GET: ServicesController
        public ActionResult Index()
        {
            return View(servicesModel.GetServices());
        }

        // GET: ServicesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ServicesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                Service service = new Service();

                service.IDService = 0;
                service.Active = true;
                service.Type = collection["Type"].ToString();
                service.Name = collection["Name"].ToString();
                service.Description = collection["Description"].ToString();
                service.Price = decimal.Parse(collection["Price"].ToString());

                servicesModel.PostService(service);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ServicesController/Details/{id}
        public ActionResult Details(int id)
        {
            return View(servicesModel.GetService(id));
        }

        // GET: ServicesController/Edit/{id}
        public ActionResult Edit(int id)
        {
            return View(servicesModel.GetService(id));
        }

        // POST: ServicesController/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                Service service = new Service();

                service.IDService = int.Parse(collection["IDService"].ToString());
                service.Active = collection["Active"].ToString() != "false";
                service.Type = collection["Type"].ToString();
                service.Name = collection["Name"].ToString();
                service.Description = collection["Description"].ToString();
                service.Price = decimal.Parse(collection["Price"].ToString());

                servicesModel.PutService(service);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ServicesController/Delete/{id}
        public ActionResult Delete(int id)
        {
            return View(servicesModel.GetService(id));
        }

        // POST: ServicesController/Delete/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                servicesModel.DeleteService(id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
