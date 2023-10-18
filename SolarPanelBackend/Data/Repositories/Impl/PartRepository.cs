using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SolarPanelBackend.Models;
using System.Data;

namespace SolarPanelBackend.Data.Repositories.Impl
{
    public class PartRepository : IPartRepository
    {
        private readonly DataContext _context;

        public PartRepository(DataContext dataContext)
        {
            this._context = dataContext;
        }
        // Specialist
        // A2
        public ICollection<PartModel> ListAllPartsAndInventory()
        {
            var connectionString = _context.Database.GetConnectionString();
            using (SqlConnection connection = new(connectionString))
            {
                connection.Open();
                SqlCommand command = new("dbo.ListAllPartsAndInventory", connection);
                List<PartModel> allPossibleParts = new();
                command.CommandType = CommandType.StoredProcedure;
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    decimal currentPrice = reader["CurrentPrice"].Equals(System.DBNull.Value) ? (decimal)0.0 : (decimal)reader["CurrentPrice"];
                    var partModel = new PartModel
                    (
                        (int)reader["PartID"],
                        reader["PartName"].ToString(),
                        reader["PartDescription"].ToString(),
                        (int)reader["CountPerCompartment"],
                        currentPrice,
                        (int)reader["NumInstorage"]
                    );
                    allPossibleParts.Add(partModel);
                }
                return allPossibleParts;
            }
        }
        // Storage Manager
        // B1
        public int InsertNewPart(PartModel part)
        {
            var connectionString = _context.Database.GetConnectionString();
            try
            {
                using (SqlConnection connection = new(connectionString))
                {
                    SqlCommand command = new("InsertNewPart", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@PartName", part.PartName);
                    command.Parameters.AddWithValue("@PartDescription", part.PartDescription);
                    command.Parameters.AddWithValue("@CountPerCompartment", part.CountPerCompartment);
                    command.Parameters.AddWithValue("@CurrentPrice", part.CurrentPrice);

                    connection.Open();

                    int partId = (int)command.ExecuteScalar();
                    Console.WriteLine("Success! Part inserted with ID: " + partId);
                    return partId;
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception(ex.Message);
            }
        }
        // B2
        public int UpdatePartPrice(int partId, decimal newPrice) 
        {
            var connectionString = _context.Database.GetConnectionString();
            try
            {
                using (SqlConnection connection = new(connectionString))
                {
                    SqlCommand command = new("dbo.UpdatePartPrice", connection);

                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@PartId", partId);
                    command.Parameters.AddWithValue("@NewPrice", newPrice);
                    connection.Open();
                    command.ExecuteNonQuery();
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
        // B3
        public ICollection<PartModel> ListAllPartsNotInStorage() 
        {
            var connectionString = _context.Database.GetConnectionString();
            using (SqlConnection connection = new(connectionString))
            {
                connection.Open();
                SqlCommand command = new("dbo.ListAllPartsNotInStorage", connection);
                List<PartModel> partsNotInStorage = new();
                command.CommandType = CommandType.StoredProcedure;
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    decimal currentPrice = reader["CurrentPrice"].Equals(System.DBNull.Value) ? (decimal)0.0 : (decimal)reader["CurrentPrice"];
                    var partModel = new PartModel
                    (
                        (int)reader["PartID"],
                        reader["PartName"].ToString(),
                        reader["PartDescription"].ToString(),
                        (int)reader["CountPerCompartment"],
                        currentPrice,
                        (int)reader["NumInstorage"]
                    );
                    partsNotInStorage.Add(partModel);
                }
                return partsNotInStorage;
            }
        }
        // B4
        public ICollection<Tuple<string, string, int>> ListAllPartsPreordered()
        {
            var connectionString = _context.Database.GetConnectionString();
            using (SqlConnection connection = new(connectionString))
            {
                connection.Open();
                SqlCommand command = new("dbo.ListAllPartsPreordered", connection);
                List<Tuple<string, string, int>> partsPreordered = new();
                command.CommandType = CommandType.StoredProcedure;
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Tuple<string, string, int> partNameProjNamePreorderCount = new
                    (
                        reader["PartName"].ToString(),
                        reader["ProjectName"].ToString(),
                        (int)reader["PartCount"]
                    );
                    partsPreordered.Add(partNameProjNamePreorderCount);
                }
                return partsPreordered;
            }
        }
        // not required functions
        public int UpdatePartCountPerCompartment(int partId, int newCountPerCompartment)
        {
            var connectionString = _context.Database.GetConnectionString();
            try
            {
                using (SqlConnection connection = new(connectionString))
                {
                    SqlCommand command = new("UpdatePartCountPerCompartment", connection);

                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@partId", partId);
                    command.Parameters.AddWithValue("@newCountPerCompartment", newCountPerCompartment);
                    connection.Open();
                    command.ExecuteNonQuery();
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
    }
}
