using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace SolarPanelBackend.Data.Repositories.Impl
{
    public class StorageRepository : IStorageRepository
    {
        private readonly DataContext _context;
        public StorageRepository(DataContext dataContext)
        {
            this._context = dataContext;
        }
        // Storage Manager
        // B5, B6
        public int SupplyParts(int partID, int numOfParts)
        {
            var connectionString = _context.Database.GetConnectionString();
            try
            {
                using (SqlConnection connection = new(connectionString))
                {
                    SqlCommand command = new("dbo.SupplyParts", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@PartID", partID);
                    command.Parameters.AddWithValue("@NumOfParts", numOfParts);
                    connection.Open();
                    var rowsAffected = (int)command.ExecuteScalar();
                    return rowsAffected;
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception(ex.Message);
            }
        }
        // Storage Worker
        // C1
        public int FulfillOrder(int orderID)
        {
            var connectionString = _context.Database.GetConnectionString();
            try
            {
                using (SqlConnection connection = new(connectionString))
                {
                    SqlCommand command = new("dbo.FullfillOrder", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@OrderID", orderID);
                    connection.Open();
                    var rowsAffected = (int)command.ExecuteScalar();
                    return rowsAffected;
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception(ex.Message);
            }
        }
        // C2
        public ICollection<Tuple<List<int>, string>> ListPartsOfOrderInStorage(int orderID)
        {
            var connectionString = _context.Database.GetConnectionString();
            using (SqlConnection connection = new(connectionString))
            {
                connection.Open();
                SqlCommand command = new("dbo.ListPartsOfOrderInStorage", connection);
                command.Parameters.AddWithValue("@OrderID", orderID);
                command.CommandType = CommandType.StoredProcedure;
                List<Tuple<List<int>, string>> partsOfOrder = new();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Tuple<List<int>, string>  compartment = new
                    (
                        new()
                        {
                            (int)reader["StorageRow"],
                            (int)reader["StorageColumn"],
                            (int)reader["StorageLevel"],
                            (int)reader["PartCount"],
                        },
                        reader["PartName"].ToString()

                    );
                    partsOfOrder.Add(compartment);
                }
                return partsOfOrder;
            }
        }
        // C3
        public ICollection<Tuple<string, List<int>>> ShortestPath(int orderID)
        {
            throw new NotImplementedException();
        }
        // not required functions
        public ICollection<Tuple<List<int>, string>> ViewStorage()
        {
            var connectionString = _context.Database.GetConnectionString();
            try
            {
                using (SqlConnection connection = new(connectionString))
                {
                    SqlCommand command = new("dbo.ViewStorage", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    List<Tuple<List<int>, string>> compartments = new();
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Tuple<List<int>, string> compartment = new
                        (
                            new()
                                {
                                    (int)reader["StorageRow"],
                                    (int)reader["StorageColumn"],
                                    (int)reader["StorageLevel"],
                                    (int)reader["PartCount"]
                                },
                            reader["PartName"].ToString()
                        );
                        compartments.Add(compartment);
                    }
                    return compartments;
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
