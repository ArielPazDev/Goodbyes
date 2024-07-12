using Backend.Services.DB.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Frontend.Web.App.Admin.Controllers
{
    public class PartiesController : Controller
    {
        private IPartiesModel model;

        public PartiesController(IPartiesModel iPartiesModel)
        {
            model = iPartiesModel;
        }

        // GET: PartiesController
        public ActionResult Index()
        {
            return View(model.GetParties());
        }

        // GET: PartiesController/Earring/{id}
        public ActionResult Earring(int id)
        {
            model.PutState(id, "P");

            return RedirectToAction(nameof(Index));
        }

        // GET: PartiesController/Approve/{id}
        public ActionResult Approve(int id)
        {
            model.PutState(id, "A");

            return RedirectToAction(nameof(Index));
        }

        // GET: PartiesController/Decline/{id}
        public ActionResult Decline(int id)
        {
            model.PutState(id, "R");

            return RedirectToAction(nameof(Index));
        }
    }
}
