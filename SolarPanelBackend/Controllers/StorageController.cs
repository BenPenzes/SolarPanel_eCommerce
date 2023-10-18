using Microsoft.AspNetCore.Mvc;
using SolarPanelBackend.Data.Repositories;
using SolarPanelBackend.Data.Repositories.Impl;
using SolarPanelBackend.Models;
using System.Collections.Generic;

namespace SolarPanelBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StorageController : Controller
    {
        private readonly IStorageRepository _storageRepository;
        public StorageController(IStorageRepository storageRepository)
        {
            _storageRepository = storageRepository;
        }
        // Storage Manager
        // B5, B6
        [HttpGet]
        [Route("SupplyParts/{partID}/{numOfParts}")]
        [ProducesResponseType(200, Type = typeof(string))]
        public IActionResult SupplyParts(int partID, int numOfParts)
        {
            try
            {
                int rowsAffected = _storageRepository.SupplyParts(partID, numOfParts);
                return Ok(rowsAffected);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        // Storage Worker
        // C1
        [HttpGet]
        [Route("FulfillOrder/{orderID}")]
        [ProducesResponseType(200, Type = typeof(string))]
        public IActionResult FullfillOrder(int orderID)
        {
            try
            {
                int rowsAffected = _storageRepository.FulfillOrder(orderID);
                return Ok(rowsAffected);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        // C2
        [HttpGet]
        [Route("ListPartsOfOrderInStorage/{orderID}")]
        [ProducesResponseType(200, Type = typeof(string))]
        public IActionResult ListPartsOfOrderInStorage(int orderID)
        {
            var partsOfOrder = _storageRepository.ListPartsOfOrderInStorage(orderID);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(partsOfOrder);
        }
        // C3
        // WARNING: Repository method not implemented!
        [HttpGet]
        [Route("ShortestPath/{orderID}")]
        [ProducesResponseType(200, Type = typeof(string))]
        public IActionResult ShortestPath(int orderID)
        {
            try
            {
                var compartments = _storageRepository.ShortestPath(orderID);
                return Ok(compartments);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        // helper functions
        [HttpGet]
        [Route("ViewStorage")]
        [ProducesResponseType(200, Type = typeof(string))]
        public IActionResult ViewStorage()
        {
            try
            {
                var compartments = _storageRepository.ViewStorage();
                return Ok(compartments);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}