using Microsoft.AspNetCore.Mvc;
using SolarPanelBackend.Data.Repositories;
using SolarPanelBackend.Dtos;
using SolarPanelBackend.Models;

namespace SolarPanelBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : Controller
    {
        private readonly IProjectRepository _projectRepository;
        public ProjectController(IProjectRepository projectRepository)
        {
            this._projectRepository = projectRepository;
        }
        // Specialist
        // A1
        [HttpPost]
        [Route("NewProject")]
        [ProducesResponseType(200, Type = typeof(string))]
        public IActionResult InsertNewProject([FromBody] ProjectModel project)
        {
            if (project == null)
            {
                return BadRequest("Error! Project object is null!");
            }
            try
            {
                int partID = _projectRepository.InsertNewProject(project);
                return Ok($"Success! Project inserted with ID: {partID}");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        // A2
        [HttpGet]
        [Route("ListAllProjectsOfSpecialist/{id}")]
        [ProducesResponseType(200, Type = typeof(string))]
        public IActionResult ListAllProjectsOfSpecialist(int id)
        {
            List<ProjectModel> projects = _projectRepository.ListAllProjectsOfSpecialist(id).ToList();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(projects);
        }
        // A5, A6
        [HttpPatch("UpdateProjectPricePerHour/{id}")]
        public IActionResult UpdateProjectPricePerHour(int id, [FromBody] UpdatePricePerHourDto dto)
        {
            if (dto.ID != id)
            {
                return BadRequest("Error! The ID in the URL path does not match the ID in the request body!");
            }
            var result = _projectRepository.UpdateProjectPricePerHour(dto.ID, dto.NewPrice);
            if (result == 0)
            {
                return NotFound($"Error! No project found with ID {id}");
            }
            var response = new
            {
                message = $"Success! Price per hour for project with ID {id} has been updated to {dto.NewPrice} Euros!"
            };
            return Ok(response);
        }
        [HttpPatch("UpdateProjectEstimatedHours/{ProjectID}")]
        public IActionResult UpdateProjectEstimatedHours(int ProjectID, [FromBody] UpdateProjectEstimatedHoursDto dto)
        {
            if (dto.ID != ProjectID)
            {
                return BadRequest("Error! The ID in the URL path does not match the ID in the request body!");
            }
            var result = _projectRepository.UpdateProjectEstimatedHours(dto.ID, dto.EstimatedHours);
            if (result == 0)
            {
                return NotFound($"Error! No project found with ID {ProjectID}");
            }
            var response = new
            {
                message = $"Success! Estimated hours for project with ID {ProjectID} has been updated to {dto.EstimatedHours}"
            };
            Console.WriteLine(response);
            return Ok(response);
        }
        // Storage Worker
        // C1
        [HttpGet]
        [Route("ListAllProjects")]
        [ProducesResponseType(200, Type = typeof(string))]
        public IActionResult ListAllProjects()
        {
            List<ProjectModel> projects = _projectRepository.ListAllProjects().ToList();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(projects);
        }
        // several requirements: A6, A7, C1, etc.
        [HttpPatch("UpdateProjectStatus/{id}")]
        public IActionResult UpdateProjectStatus(int id, [FromBody] UpdateProjectStatusDto dto)
        {
            if (dto.ID != id)
            {
                return BadRequest("Error! The ID in the URL path does not match the ID in the request body!");
            }
            var result = _projectRepository.UpdateProjectStatus(id, dto.Status);
            if (result == 0)
            {
                return NotFound($"Error! No project found with ID {id}");
            }
            var response = new
            {
                message = $"Success! Status for project with ID {id} has been updated to {dto.Status}"
            };
            Console.WriteLine(response);
            return Ok(response);
        }
        // helper functions
        [HttpGet]
        [Route("GetProjectStatus/{id}")]
        [ProducesResponseType(200, Type = typeof(string))]
        public IActionResult GetProjectStatus(int id)
        {
            ProjectModel.ProjectStatus projectStatus = _projectRepository.GetProjectStatus(id);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(projectStatus);
        }
    }
}