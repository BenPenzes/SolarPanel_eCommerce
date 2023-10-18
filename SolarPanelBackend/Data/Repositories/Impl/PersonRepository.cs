using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SolarPanelBackend.Models;
using System.Data;

namespace SolarPanelBackend.Data.Repositories.Impl
{   
    public class PersonRepository : IPersonRepository
    {
        private readonly DataContext _context;
        public PersonRepository(DataContext dataContext)
        {
            this._context = dataContext;
        }
        public int InsertPersonAndLoginInformation(PersonModel personModel) {
            var connectionString = _context.Database.GetConnectionString();
            try
            {
                using (SqlConnection connection = new(connectionString))
                {
                    SqlCommand command = new("InsertPersonAndLoginInformation", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@FirstName", personModel.FirstName);
                    command.Parameters.AddWithValue("@LastName", personModel.LastName);
                    command.Parameters.AddWithValue("@Job", personModel.Job);
                    command.Parameters.AddWithValue("@Email", personModel.LoginInformation.Email);
                    command.Parameters.AddWithValue("@PasswordHash", personModel.LoginInformation.PasswordHash);
                    connection.Open();
                    int personId = (int)command.ExecuteScalar();
                    Console.WriteLine("Success! Person inserted with ID: " + personId);
                    return personId;
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception(ex.Message);
            }
        }
        public KeyValuePair<string, int> CheckLoginInformation(LoginInformationModel loginInformation) // string email, string passwordHash
        {
            var connectionString = _context.Database.GetConnectionString();
            using (SqlConnection connection = new(connectionString))
            {
                SqlCommand command = new("CheckLoginInformation", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Email", loginInformation.Email);
                command.Parameters.AddWithValue("@PasswordHash", loginInformation.PasswordHash);
                SqlParameter outputParameter_userID = new("@Msg_UserID", SqlDbType.Int);
                SqlParameter outputParameter_job = new("@Msg_Job", SqlDbType.VarChar, 50);
                outputParameter_userID.Direction = ParameterDirection.Output;
                outputParameter_job.Direction = ParameterDirection.Output;
                command.Parameters.Add(outputParameter_userID); 
                command.Parameters.Add(outputParameter_job);                
                connection.Open();
                command.ExecuteNonQuery();
                string outputValue = outputParameter_job.Value.ToString(); // job of the person
                int userID_Value = Convert.ToInt32(outputParameter_userID.Value); // id of the person
                return new KeyValuePair<string, int>(outputValue, userID_Value);
            }
        }

    }
}
