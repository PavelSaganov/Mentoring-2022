using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseInteractor.Models;

namespace DatabaseInteractor.Repository.AdoRepository
{
    public class ProductRepository
    {
        private readonly string _connectionString;
        private readonly string _tableName = "Product";

        public ProductRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<int> CreateAsync(Product model)
        {
            int idOfCreated = 0;
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                string commandString = $"INSERT INTO {_tableName} (Name, Description, Weight, Height, Width, Length) " +
                "VALUES (@Name, @Description, @Weight, @Height, @Width, @Length); SELECT SCOPE_IDENTITY();";

                using var command = new SqlCommand(commandString, connection);
                command.Parameters.AddWithValue("@Name", model.Name);
                command.Parameters.AddWithValue("@Description", model.Description);
                command.Parameters.AddWithValue("@Weight", model.Weight);
                command.Parameters.AddWithValue("@Height", model.Height);
                command.Parameters.AddWithValue("@Width", model.Width);
                command.Parameters.AddWithValue("@Length", model.Length);

                object resultOfCommand = await command.ExecuteScalarAsync();
                if (resultOfCommand != null)
                {
                    idOfCreated = Convert.ToInt32(resultOfCommand);
                }
            }

            return idOfCreated;
        }

        public async Task DeleteAsync(int id)
        {
            using var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();
            string commandString = $"DELETE FROM {_tableName} WHERE Id = @ID";

            using var command = new SqlCommand(commandString, connection);
            command.Parameters.AddWithValue("@ID", id);
            await command.ExecuteNonQueryAsync();
        }

        public IQueryable<Product> GetAll()
        {
            var returnedList = new List<Product>();
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string commandString = $"SELECT Id, Name, Description, Weight, Height, Width, Length FROM {_tableName}";

                using var command = new SqlCommand(commandString, connection);
                using var reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        returnedList.Add(
                            new Product
                            {
                                Id = (int)reader["Id"],
                                Name = (string)reader["Name"],
                                Description = (string)reader["Description"],
                                Weight = (int)reader["Weight"],
                                Height = (int)reader["Height"],
                                Width = (int)reader["Width"],
                                Length = (int)reader["Length"],
                            });
                    }
                }
            }

            return returnedList.AsQueryable();
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            Product returnedEntity = null;
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                string commandString = $"SELECT Id, Name, Description, Weight, Height, Width, Length FROM {_tableName} WHERE Id = @ID";

                using var command = new SqlCommand(commandString, connection);
                command.Parameters.AddWithValue("@ID", id);

                using var reader = await command.ExecuteReaderAsync();
                while (await reader.ReadAsync())
                {
                    returnedEntity = new Product
                    {
                        Id = id,
                        Name = (string)reader["Name"],
                        Description = (string)reader["Description"],
                        Weight = (int)reader["Weight"],
                        Height = (int)reader["Height"],
                        Width = (int)reader["Width"],
                        Length = (int)reader["Length"],
                    };
                }
            }

            return returnedEntity;
        }

        public async Task UpdateAsync(Product model)
        {
            using var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();
            string commandString = $"UPDATE {_tableName} " +
            "SET Name = @Name, Description = @Description, Weight = @Weight, Height = @Height, Width = @Width, Length = @Length " +
            "WHERE Id = @ID";

            using var command = new SqlCommand(commandString, connection);

            command.Parameters.AddWithValue("@ID", model.Id);
            command.Parameters.AddWithValue("@Name", model.Name);
            command.Parameters.AddWithValue("@Description", model.Description);
            command.Parameters.AddWithValue("@Weight", model.Weight);
            command.Parameters.AddWithValue("@Height", model.Height);
            command.Parameters.AddWithValue("@Width", model.Width);
            command.Parameters.AddWithValue("@Length", model.Length);
            await command.ExecuteNonQueryAsync();
        }
    }
}
