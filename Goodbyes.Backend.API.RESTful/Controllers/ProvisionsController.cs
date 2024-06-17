using Goodbyes.Backend.Services.DB.Entities;
using Goodbyes.Backend.Services.DB.Services;
using Microsoft.AspNetCore.Mvc;

namespace Goodbyes.Backend.API.RESTful.Controllers
{
    [ApiController]
    [Route("api/web/v1/provisions")]
    public class ProvisionsController : Controller
    {
        [HttpGet]
        public IEnumerable<ProvisionsEntity> Get()
        {
            ProvisionsService previsionsService = new ProvisionsService();

            return previsionsService.GetProvisionsTest();
        }

        [HttpGet("{id:int}")]
        public string Get2(int id)
        {
            return "Hola..." + id;
        }



        /*// GET: ProvisionsController
        public ActionResult Index()
        {
            return View();
        }

        // GET: ProvisionsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProvisionsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProvisionsController/Create
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

        // GET: ProvisionsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProvisionsController/Edit/5
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

        // GET: ProvisionsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProvisionsController/Delete/5
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
        }*/
    }
}
