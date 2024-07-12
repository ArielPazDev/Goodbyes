using Backend.Services.DB.Entities;
using Backend.Services.DB.Models;
using Microsoft.AspNetCore.Mvc;

namespace Backend.API.RESTful.Controllers
{
    [ApiController]
    [Route("api/web/v1/peoples")]
    public class PeoplesController : Controller
    {
        private IPeoplesModel model;

        public PeoplesController(IPeoplesModel iPeoplesModel)
        {
            model = iPeoplesModel;
        }

        [HttpPost]
        public IActionResult PostPeople([FromBody] People people)
        {
            int id = model.PostPeople(people);

            if (id > 0)
                return Ok();
            else
                return StatusCode(StatusCodes.Status500InternalServerError);
        }

        [HttpGet]
        public IActionResult GetPeoples()
        {
            IEnumerable<People>? peoples = model.GetPeoples();

            if (peoples != null)
                return Ok(peoples);
            else
                return StatusCode(StatusCodes.Status500InternalServerError);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetPeople(int id)
        {
            People? people = model.GetPeople(id);

            if (people != null)
                return Ok(people);
            else
                return StatusCode(StatusCodes.Status404NotFound);
        }

        [HttpPut("{id:int}")]
        public IActionResult PutPeople(int id, [FromBody] People people)
        {
            people.IDPeople = id;

            bool? done = model.PutPeople(people);

            if (done == true)
                return Ok();
            else if (done == false)
                return StatusCode(StatusCodes.Status404NotFound);
            else
                return StatusCode(StatusCodes.Status500InternalServerError);
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeletePeople(int id)
        {
            bool? done = model.DeletePeople(id);

            if (done == true)
                return Ok();
            else if (done == false)
                return StatusCode(StatusCodes.Status404NotFound);
            else
                return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
}
