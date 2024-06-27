﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Frontend.Web.App.Admin.Controllers
{
    public class EventsController : Controller
    {
        // GET: EventsController
        public ActionResult Index()
        {
            return View();
        }

        // GET: EventsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EventsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EventsController/Details/{id}
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: EventsController/Edit/{id}
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: EventsController/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EventsController/Delete/{id}
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EventsController/Delete/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
