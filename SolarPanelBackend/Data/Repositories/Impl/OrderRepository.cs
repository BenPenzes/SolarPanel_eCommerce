using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SolarPanelBackend.Models;
using System.Data;
using static SolarPanelBackend.Models.OrderEntryModel;

namespace SolarPanelBackend.Data.Repositories.Impl
{
    public class OrderRepository : IOrderRepository
    {
        private readonly DataContext _context;
        public OrderRepository(DataContext dataContext)
        {
            this._context = dataContext;
        }
        // Specialist
        // A4/a
        public int AddOrderToProject(int projectID)
        {
            var connectionString = _context.Database.GetConnectionString();
            try
            {
                using (SqlConnection connection = new(connectionString))
                {
                    SqlCommand command = new("AddOrderToProject", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ProjectID", projectID);
                    connection.Open();
                    int orderID = (int)command.ExecuteScalar();
                    Console.WriteLine($"Success! Order added to project with ID {projectID}!");
                    return orderID;
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception(ex.Message);
            }
        }
        // A4/b
        public int AddOrderEntryToOrder(int orderId, OrderEntryModel orderEntry)
        {
            var connectionString = _context.Database.GetConnectionString();
            try
            {
                using (SqlConnection connection = new(connectionString))
                {
                    SqlCommand command = new("AddOrderEntryToOrder", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@OrderID", orderId);
                    command.Parameters.AddWithValue("@PartID", orderEntry.PartID);
                    command.Parameters.AddWithValue("@PartCount", orderEntry.PartCount);
                    connection.Open();
                    int orderEntryID = (int)command.ExecuteScalar();
                    Console.WriteLine($"Success! OrderEntry with ID {orderEntryID} added to order with ID {orderId}");
                    return orderEntryID;
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception(ex.Message);
            }
        }
        // A5, A6
        public int CalculatePriceOfOrder(int orderID, int projectID)
        {
            int result;
            var connectionString = _context.Database.GetConnectionString();
            try
            {
                using (SqlConnection connection = new(connectionString))
                {
                    SqlCommand command = new("CalculatePriceOfOrder", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@OrderID", orderID);
                    command.Parameters.AddWithValue("@ProjectID", projectID);
                    connection.Open();
                    result = (int)command.ExecuteScalar();
                    Console.WriteLine($"Success! Calculated price of Order with ID {orderID} = {result} Euros!");
                    return result;
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception(ex.Message);
            }

        }
        // helper functions
        public int GetOrderIdOfProject(int projectID)
        {
            var connectionString = _context.Database.GetConnectionString();
            try
            {
                using (SqlConnection connection = new(connectionString))
                {
                    SqlCommand command = new("GetOrderIDOfProject", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ProjectID", projectID);
                    connection.Open();
                    int orderID = (int)command.ExecuteScalar();
                    if (orderID == -1)
                    {
                        Console.WriteLine($"Error! No order for project with ID {projectID}!");
                    }
                    else
                    {
                        Console.WriteLine($"Order of project with ID {projectID} selected!");
                    }
                    return orderID;
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception(ex.Message);
            }
        }
        public ICollection<Tuple<string, int, int>> ListOrderEntriesOfOrder(int orderID)
        {
            var connectionString = _context.Database.GetConnectionString();
            try
            {
                using (SqlConnection connection = new(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new("dbo.ListOrderEntriesOfOrder", connection);
                    command.Parameters.AddWithValue("@OrderID", orderID);
                    List<Tuple<string, int, int>> orderEntries = new();
                    command.CommandType = CommandType.StoredProcedure;
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        var orderEntry = new Tuple<string, int, int>
                        (
                            reader["PartName"].ToString(),
                            (int)reader["PartCount"],
                            (int)reader["OrderEntryStatus"]
                        );
                        orderEntries.Add(orderEntry);
                    }
                    return orderEntries;
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception(ex.Message);
            }
        }
    }
}
