using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestWithASPNET10Erudio.Services;

namespace RestWithASPNET10Erudio.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonsController : ControllerBase
    {
        private IPersonsServices _personsService;

        public PersonsController(IPersonsServices personsService)
        {
            _personsService = personsService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_personsService.FindAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id) {
            var person = _personsService.FindById(id);
            if (person == null)
            {
                return NotFound();
            }
            return Ok(person);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Model.Persons persons)
        {
            var createdPerson = _personsService.Create(persons);
            if (createdPerson == null)
            {
                return BadRequest();
            }
            return Ok(createdPerson);
        }

        [HttpPut]
        public IActionResult Put([FromBody] Model.Persons persons)
        {
            var updatedPerson = _personsService.Update(persons);
            if (updatedPerson == null)
            {
                return BadRequest();
            }
            return Ok(updatedPerson);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _personsService.Delete(id);
            return NoContent();
        }

    }
}
