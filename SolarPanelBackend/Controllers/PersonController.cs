using Microsoft.AspNetCore.Mvc;
using SolarPanelBackend.Data.Repositories;
using SolarPanelBackend.Models;

namespace SolarPanelBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : Controller
    {
        private readonly IPersonRepository _personRepository;
        public PersonController(IPersonRepository personRepository)
        {
            this._personRepository = personRepository;
        }
        [HttpPost]
        [Route("Login")]
        [ProducesResponseType(200, Type = typeof(string))]
        public IActionResult CheckLoginInformation([FromBody] LoginInformationModel loginInformation)
        {
            if (loginInformation == null)
            {
                return BadRequest("Error! loginInformation object is null!");
            }
            try
            {
                KeyValuePair<string, int> result = _personRepository.CheckLoginInformation(loginInformation); // string -> job, int -> personID
                Console.WriteLine("Success! Login information validated!");
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        [Route("NewPerson")]
        [ProducesResponseType(200, Type = typeof(string))]
        public IActionResult InsertPerson([FromBody] PersonModel personModel)
        {
            if (personModel == null)
            {
                return BadRequest("Error! Something went wrong inserting a new person into the database!");
            }
            try
            {
                int personID = _personRepository.InsertPersonAndLoginInformation(personModel);
                return Ok($"Success! Person inserted with ID: {personID}");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}