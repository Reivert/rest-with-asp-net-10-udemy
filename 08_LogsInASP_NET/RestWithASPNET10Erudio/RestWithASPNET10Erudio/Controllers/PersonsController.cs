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
        private  readonly ILogger<PersonsController> _logger;

        public PersonsController(IPersonsServices personsService, 
            ILogger<PersonsController> logger)
        {
            _personsService = personsService;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            _logger.LogInformation("Getting all persons");
            return Ok(_personsService.FindAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id) {
            _logger.LogInformation("Getting person with id {Id}", id);

            var person = _personsService.FindById(id);
            if (person == null)
            {
                _logger.LogWarning("Person with id {Id} not found", id);
                return NotFound();
            }
            return Ok(person);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Model.Persons persons)
        {
            _logger.LogInformation("Creating a new person {first_name}", persons.FirstName);

            var createdPerson = _personsService.Create(persons);
            if (createdPerson == null)
            {
                _logger.LogError("Error creating person {first_name}", persons.FirstName);
                return BadRequest();
            }
            return Ok(createdPerson);
        }

        [HttpPut]
        public IActionResult Put([FromBody] Model.Persons persons)
        {
            _logger.LogInformation("Updating person with id {Id}", persons.Id);

            var updatedPerson = _personsService.Update(persons);
            if (updatedPerson == null)
            {
                _logger.LogError("Error updating person with id {Id}", persons.Id);
                return BadRequest();
            }

            _logger.LogDebug("Person with id {Id} updated successfully", persons.Id);
            return Ok(updatedPerson);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _logger.LogInformation("Deleting person with id {Id}", id);

            _personsService.Delete(id);
            _logger.LogDebug("Person with id {Id} deleted successfully", id);
            return NoContent();
        }

    }
}
