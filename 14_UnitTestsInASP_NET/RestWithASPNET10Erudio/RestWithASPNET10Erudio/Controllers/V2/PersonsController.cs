using Microsoft.AspNetCore.Mvc;
using RestWithASPNET10Erudio.Data.DTO.V2;
using RestWithASPNET10Erudio.Services.Implementations;

namespace RestWithASPNET10Erudio.Controllers.V2
{
    [ApiController]
    [Route("api/[controller]/v2")]
    public class PersonsController : ControllerBase
    {
        private PersonsServicesImplementationsV2 _personService;
        private readonly ILogger<PersonsController> _logger;

        public PersonsController(PersonsServicesImplementationsV2 personService,
            ILogger<PersonsController> logger)
        {
            _personService = personService;
            _logger = logger;
        }


        [HttpPost]
        public IActionResult Post([FromBody] PersonsDTO person)
        {
            _logger.LogInformation("Creating new Person: {firstName}", person.FirstName);

            var createdPerson = _personService.Create(person);
            if (createdPerson == null)
            {
                _logger.LogError("Failed to create person with name {firstName}", person.FirstName);
                return NotFound();
            }
            return Ok(createdPerson);
        }
    }
}
