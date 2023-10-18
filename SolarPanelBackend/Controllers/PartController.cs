using Microsoft.AspNetCore.Mvc;
using SolarPanelBackend.Data.Repositories;
using SolarPanelBackend.Dtos;
using SolarPanelBackend.Models;

namespace SolarPanelInstallationBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PartController : Controller
    {
        private readonly IPartRepository _partRepository;
        public PartController(IPartRepository partRepository)
        {
            this._partRepository = partRepository;
        }
        // Specialist
        // A2
        [HttpGet]
        [Route("ListAllParts")]
        [ProducesResponseType(200, Type = typeof(ICollection<PartModel>))]
        public IActionResult ListAllPartsAndInventory()
        {
            List<PartModel> parts = _partRepository.ListAllPartsAndInventory().ToList<PartModel>();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(parts);
        }
        // Storage Manager
        // B1
        [HttpPost]
        [Route("NewPart")]
        [ProducesResponseType(200, Type = typeof(string))]
        public IActionResult InsertNewPart([FromBody] PartModel part)
        {
            if (part == null)
            {
                return BadRequest("Part object is null!");
            }
            try
            {
                int partID = _partRepository.InsertNewPart(part);
                return Ok($"Success! Part inserted with ID: {partID}");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        // B2
        [HttpPatch("UpdatePartPrice/{id}")]
        public IActionResult UpdatePartPrice(int id, [FromBody] UpdatePriceDto dto)
        {
            if (dto.ID != id)
            {
                return BadRequest("Error! The ID in the URL path does not match the ID in the request body!");
            }
            var result = _partRepository.UpdatePartPrice(dto.ID, dto.Price);
            if (result == 0)
            {
                return NotFound($"Error! No part found with ID {id}");
            }
            var response = new
            {
                message = $"Success! Price for part with ID {id} has been updated to {dto.Price} Euros!"
            };
            Console.WriteLine(response.message);
            return Ok(response);
        }
        // B3
        [HttpGet]
        [Route("ListPartsNotInStorage/")]
        [ProducesResponseType(200, Type = typeof(string))]
        public IActionResult ListPartsNotInStorage()
        {
            List<PartModel> partsNotInStorage = _partRepository.ListAllPartsNotInStorage().ToList();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(partsNotInStorage);
        }
        // B4
        [HttpGet]
        [Route("ListAllPartsPreordered/")]
        [ProducesResponseType(200, Type = typeof(string))]
        public IActionResult ListAllPartsPreordered()
        {
            List<Tuple<string, string, int>> partsPreordered = _partRepository.ListAllPartsPreordered().ToList();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(partsPreordered);
        }
        // not required functions
        [HttpPatch("UpdatePartCountPerCompartment/{id}")]
        public IActionResult UpdatePartCountPerCompartment(int id, [FromBody] UpdateCountPerCompartmentDto dto)
        {
            if (dto.ID != id)
            {
                return BadRequest("Error! The ID in the URL path does not match the ID in the request body!");
            }
            var result = _partRepository.UpdatePartCountPerCompartment(dto.ID, dto.CountPerComparment);
            if (result == 0)
            {
                return NotFound($"Error! No part found with ID {id}");
            }
            var response = new
            {
                message = $"Success! Count per compartmnet for part with ID {id} has been updated to {dto.CountPerComparment}"
            };
            Console.WriteLine(response);
            return Ok(response);
        }
    }
}
