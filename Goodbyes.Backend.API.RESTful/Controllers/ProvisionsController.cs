using Goodbyes.Backend.Services.DB.Entities;
using Goodbyes.Backend.Services.DB.Services;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Goodbyes.Backend.API.RESTful.Controllers
{
    [ApiController]
    [Route("api/web/v1/provisions")]
    public class ProvisionsController : Controller
    {
        [HttpPost]
        public IActionResult PostProvision([FromBody] Provision provision)
        {
            ProvisionsService previsionsService = new ProvisionsService();

            var done = previsionsService.PostProvision(provision);

            if (done)
                return Ok();
            else
                return StatusCode(StatusCodes.Status400BadRequest);
        }

        [HttpGet]
        public IActionResult GetProvisions()
        {
            ProvisionsService previsionsService = new ProvisionsService();

            var data = previsionsService.GetProvisions();

            if (data == null)
                return StatusCode(StatusCodes.Status404NotFound);
            else
                return Ok(data);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetProvision(int id)
        {
            ProvisionsService previsionsService = new ProvisionsService();

            var data = previsionsService.GetProvision(id);

            if (data == null)
                return StatusCode(StatusCodes.Status404NotFound);
            else
                return Ok(data);
        }

        [HttpPut("{id:int}")]
        public IActionResult PutProvision(int id, [FromBody] Provision provision)
        {
            ProvisionsService previsionsService = new ProvisionsService();

            var done = previsionsService.PutProvision(id, provision);

            if (done)
                return Ok();
            else
                return StatusCode(StatusCodes.Status400BadRequest);
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteProvision(int id)
        {
            ProvisionsService previsionsService = new ProvisionsService();

            var done = previsionsService.DeleteProvision(id);

            if (done)
                return Ok();
            else
                return StatusCode(StatusCodes.Status400BadRequest);
        }
    }
}
