using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using DatabaseInteractor.Models;
using DatabaseInteractor.Models.Enums;

namespace DatabaseInteractor.Repository.AdoRepository
{
    public class OrderRepository : IRepositoryAsync<Order>
    {
        private readonly string _connectionString;
        private const string _tableName = "Order";

        public OrderRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<int> CreateAsync(Order model)
        {
            int idOfCreated = 0;
            await using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                string commandString = $"INSERT INTO {_tableName} (Status, CreatedDate, UpdatedDate, ProductId) " +
                "VALUES (@Status, @CreatedDate, @UpdatedDate, @ProductId); SELECT SCOPE_IDENTITY();";

                await using var command = new SqlCommand(commandString, connection);
                command.Parameters.AddWithValue("@Status", model.Status);
                command.Parameters.AddWithValue("@CreatedDate", model.CreatedDate);
                command.Parameters.AddWithValue("@UpdatedDate", model.UpdatedDate);
                command.Parameters.AddWithValue("@ProductId", model.ProductId);

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
            await using var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();
            string commandString = $"DELETE FROM {_tableName} WHERE Id = @ID";

            await using var command = new SqlCommand(commandString, connection);
            command.Parameters.AddWithValue("@ID", id);
            await command.ExecuteNonQueryAsync();
        }

        public IQueryable<Order> GetAll()
        {
            var returnedList = new List<Order>();
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string commandString = $"SELECT Id, Status, CreatedDate, UpdatedDate, ProductId FROM [{_tableName}]";

                using var command = new SqlCommand(commandString, connection);
                using var reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        returnedList.Add(
                            new Order
                            {
                                Id = (int)reader["Id"],
                                Status = (Status)Enum.Parse(typeof(Status), reader["Status"].ToString()),
                                CreatedDate = DateTime.Parse(reader["CreatedDate"].ToString()),
                                UpdatedDate = DateTime.Parse(reader["UpdatedDate"].ToString()),
                                ProductId = (int)reader["ProductId"],
                            });
                    }
                }
            }

            return returnedList.AsQueryable();
        }

        public IQueryable<Order> GetAll(Dictionary<string, object> properties)
        {
            var returnedList = new List<Order>();
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using var command = new SqlCommand("FilterBy", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                foreach (var prop in properties)
                {
                    command.Parameters.AddWithValue("@" + prop.Key, prop.Value);
                }

                using var reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        returnedList.Add(
                            new Order
                            {
                                Id = (int)reader["Id"],
                                Status = (Status)Enum.Parse(typeof(Status), reader["Status"].ToString()),
                                CreatedDate = DateTime.Parse(reader["CreatedDate"].ToString()),
                                UpdatedDate = DateTime.Parse(reader["UpdatedDate"].ToString()),
                                ProductId = (int)reader["ProductId"],
                            });
                    }
                }
            }

            return returnedList.AsQueryable();
        }

        public async Task<Order> GetByIdAsync(int id)
        {
            Order returnedEntity = null;
            await using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                string commandString = $"SELECT Id,Status, CreatedDate, UpdatedDate, ProductId FROM {_tableName} WHERE Id = @ID";

                await using var command = new SqlCommand(commandString, connection);
                command.Parameters.AddWithValue("@ID", id);

                await using var reader = await command.ExecuteReaderAsync();
                while (await reader.ReadAsync())
                {
                    returnedEntity = new Order
                    {
                        Id = id,
                        Status = (Status)Enum.Parse(typeof(Status), reader["Status"].ToString()),
                        CreatedDate = DateTime.Parse(reader["CreatedDate"].ToString()),
                        UpdatedDate = DateTime.Parse(reader["UpdatedDate"].ToString()),
                        ProductId = (int)reader["ProductId"],
                    };
                }
            }

            return returnedEntity;
        }

        public async Task UpdateAsync(Order model)
        {
            await using var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();
            string commandString = $"UPDATE {_tableName} " +
            "SET Status = @Status, CreatedDate = @CreatedDate, UpdatedDate = @UpdatedDate, ProductId = @ProductId " +
            "WHERE Id = @ID";

            await using var command = new SqlCommand(commandString, connection);

            command.Parameters.AddWithValue("@ID", model.Id);
            command.Parameters.AddWithValue("@Status", model.Status);
            command.Parameters.AddWithValue("@CreatedDate", model.CreatedDate);
            command.Parameters.AddWithValue("@UpdatedDate", model.UpdatedDate);
            command.Parameters.AddWithValue("@ProductId", model.ProductId);
            await command.ExecuteNonQueryAsync();
        }
    }
}
