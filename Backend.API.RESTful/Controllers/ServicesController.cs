using Goodbyes.Backend.Services.DB.Entities;
using Goodbyes.Backend.Services.DB.Services;
using Microsoft.AspNetCore.Mvc;

namespace Goodbyes.Backend.API.RESTful.Controllers
{
    [ApiController]
    [Route("api/web/v1/services")]
    public class ServicesController : Controller
    {
        private ServicesModel servicesModel = new ServicesModel();

        [HttpPost]
        public IActionResult PostService([FromBody] Service service)
        {
            bool? done = servicesModel.PostService(service);

            if (done == true)
                return Ok();
            else if (done == false)
                return StatusCode(StatusCodes.Status400BadRequest);
            else
                return StatusCode(StatusCodes.Status500InternalServerError);
        }

        [HttpGet]
        public IActionResult GetServices()
        {
            IEnumerable<Service>? services = servicesModel.GetServices();

            if (services != null)
                return Ok(services);
            else
                return StatusCode(StatusCodes.Status500InternalServerError);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetService(int id)
        {
            Service? service = servicesModel.GetService(id);

            if (service != null)
                return Ok(service);
            else
                return StatusCode(StatusCodes.Status404NotFound);
        }

        [HttpPut("{id:int}")]
        public IActionResult PutService(int id, [FromBody] Service service)
        {
            service.IDService = id;

            bool? done = servicesModel.PutService(service);

            if (done == true)
                return Ok();
            else if (done == false)
                return StatusCode(StatusCodes.Status404NotFound);
            else
                return StatusCode(StatusCodes.Status500InternalServerError);
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteService(int id)
        {
            bool? done = servicesModel.DeleteService(id);

            if (done == true)
                return Ok();
            else if (done == false)
                return StatusCode(StatusCodes.Status404NotFound);
            else
                return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
}
