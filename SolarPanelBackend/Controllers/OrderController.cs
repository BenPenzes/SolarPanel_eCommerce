using Microsoft.AspNetCore.Mvc;
using SolarPanelBackend.Data.Repositories;
using SolarPanelBackend.Models;

namespace SolarPanelBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : Controller
    {
        private readonly IOrderRepository _orderRepository;
        public OrderController(IOrderRepository orderRepository)
        {
            this._orderRepository = orderRepository;
        }
        // Specialist
        // A4/a
        [HttpGet]
        [Route("AddOrderToProject/{projectID}")]
        [ProducesResponseType(200, Type = typeof(string))] 
        public IActionResult AddOrderToProject(int projectID)
        {
            try
            {
                int orderID = _orderRepository.AddOrderToProject(projectID);
                return Ok($"Order inserted with ID {orderID} to project with ID {projectID}!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        // A4/b
        
        [HttpPost]
        [Route("AddOrderEntryToOrder/{orderId}")]
        [ProducesResponseType(200, Type = typeof(string))]
        public IActionResult AddOrderEntryToOrder(int orderId, [FromBody] OrderEntryModel orderEntry)
        {
            if (orderEntry == null)
            {
                return BadRequest("OrderEntry object is null!");
            }
            try
            {
                int orderEntryID = _orderRepository.AddOrderEntryToOrder(orderId, orderEntry);
                return Ok($"Order entry inserted with ID {orderEntryID} to order with ID {orderId}!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        // A5, A6
        [HttpGet]
        [Route("CalculatePriceOfOrder/{projectID}/{orderID}")]
        [ProducesResponseType(200, Type = typeof(string))]
        public IActionResult CalculatePriceOfOrder(int orderID, int projectID)
        {
            try
            {
                decimal priceOfOrder = _orderRepository.CalculatePriceOfOrder(orderID, projectID);
                return Ok(priceOfOrder);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        // helper functions
        [HttpGet]
        [Route("GetOrderIdOfProject/{projectID}")]
        [ProducesResponseType(200, Type = typeof(string))]
        public IActionResult GetOrderIdOfProject(int projectID)
        {
            try
            {
                int orderID = _orderRepository.GetOrderIdOfProject(projectID);
                return Ok(orderID);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Route("ListOrderEntriesOfOrder/{orderID}")]
        [ProducesResponseType(200, Type = typeof(string))]
        public IActionResult ListOrderEntriesOfOrder(int orderID)
        {
            List<Tuple<string, int, int>> orderEntries = _orderRepository.ListOrderEntriesOfOrder(orderID).ToList(); // PartName, PartCount, OrderEntryStatus
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(orderEntries);
        }
    }
}