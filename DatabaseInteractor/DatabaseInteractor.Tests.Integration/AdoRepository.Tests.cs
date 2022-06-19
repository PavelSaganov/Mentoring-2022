using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using DatabaseInteractor.Models;
using DatabaseInteractor.Models.Enums;
using DatabaseInteractor.Repository;
using DatabaseInteractor.Repository.AdoRepository;
using NUnit.Framework;
using FluentAssertions;
using System.Threading.Tasks;

namespace DatabaseInteractor.Tests.Integration
{
    public class Tests
    {
        private const string connectionStringToCreateDB = "Data Source=DESKTOP-ER2HSUN;Integrated Security=True";
        private const string connectionString = "Data Source=DESKTOP-ER2HSUN;Initial Catalog=ProductDB;Integrated Security=True";
        private IRepositoryAsync<Order> orderRepository;
        private IRepositoryAsync<Product> productRepository;
        private List<Order> baseOrderList;
        private List<Product> baseProductList;

        [SetUp]
        public void Setup()
        {
            #region Create db
            using var myConn = new SqlConnection(connectionStringToCreateDB);
            string createScript = "CREATE DATABASE ProductDB";

            var myCommand = new SqlCommand(createScript, myConn);
            myConn.Open();
            myCommand.ExecuteNonQuery();
            #endregion

            #region Initialize db
            var createTablesScript = File.ReadAllText("../../../CreateTables.sql");
            var createTablesCommand = new SqlCommand(createTablesScript, myConn);
            createTablesCommand.ExecuteNonQuery();

            var createProceduresScript = File.ReadAllText("../../../CreateProcedures.sql");
            var createProceduresCommand = new SqlCommand(createProceduresScript, myConn);
            createProceduresCommand.ExecuteNonQuery();

            var fillDbScript = File.ReadAllText("../../../FillDB.sql");
            var fillDbCommand = new SqlCommand(fillDbScript, myConn);
            fillDbCommand.ExecuteNonQuery();
            #endregion

            #region Set Repositories
            orderRepository = new OrderRepository(connectionString);
            productRepository = new ProductRepository(connectionString);
            #endregion

            #region Set base test data
            baseOrderList = new List<Order>()
            {
                new Order()
                {
                    Id = 1,
                    CreatedDate = DateTime.Parse("2/1/1998 12:00:00 AM"),
                    UpdatedDate = DateTime.Parse("2/1/1998 12:00:00 AM"),
                    Status = Status.InProgress,
                    ProductId = 1,
                },
                new Order()
                {
                    Id = 2,
                    CreatedDate = DateTime.Parse("2/1/1998 12:00:00 AM"),
                    UpdatedDate = DateTime.Parse("2/1/1998 12:00:00 AM"),
                    Status = Status.Loading,
                    ProductId = 2,
                },
                new Order()
                {
                    Id = 3,
                    CreatedDate = DateTime.Parse("2/1/1998 12:00:00 AM"),
                    UpdatedDate = DateTime.Parse("2/1/1998 12:00:00 AM"),
                    Status = Status.Unloading,
                    ProductId = 3,
                },
                new Order()
                {
                    Id = 4,
                    CreatedDate = DateTime.Parse("2/1/1998 12:00:00 AM"),
                    UpdatedDate = DateTime.Parse("2/1/1998 12:00:00 AM"),
                    Status = Status.InProgress,
                    ProductId = 1,
                },
                new Order()
                {
                    Id = 5,
                    CreatedDate = DateTime.Parse("2/1/1998 12:00:00 AM"),
                    UpdatedDate = DateTime.Parse("2/1/1998 12:00:00 AM"),
                    Status = Status.Arrived,
                    ProductId = 1,
                },
                new Order()
                {
                    Id = 6,
                    CreatedDate = DateTime.Parse("2/1/1998 12:00:00 AM"),
                    UpdatedDate = DateTime.Parse("2/1/1998 12:00:00 AM"),
                    Status = Status.Unloading,
                    ProductId = 4,
                },
                new Order()
                {
                    Id = 7,
                    CreatedDate = DateTime.Parse("2/1/1998 12:00:00 AM"),
                    UpdatedDate = DateTime.Parse("2/1/1998 12:00:00 AM"),
                    Status = Status.Arrived,
                    ProductId = 4,
                },
            };
            baseProductList = new List<Product>()
            {
                new Product()
                {
                    Id = 1,
                    Name = "Prod1",
                    Description = "Desc1",
                    Weight = 3,
                    Height = 3,
                    Width = 5,
                    Length = 5
                },
                new Product()
                {
                    Id = 2,
                    Name = "Prod2",
                    Description = "Desc2",
                    Weight = 2,
                    Height = 2,
                    Width = 2,
                    Length = 2
                },
                new Product()
                {
                    Id = 3,
                    Name = "Prod3",
                    Description = string.Empty,
                    Weight = 3,
                    Height = 3,
                    Width = 3,
                    Length = 3
                },
                new Product()
                {
                    Id = 4,
                    Name = "Prod4",
                    Description = "Desc4",
                    Weight = 4,
                    Height = 4,
                    Width = 4,
                    Length = 4
                },
                new Product()
                {
                    Id = 5,
                    Name = "Prod5",
                    Description = string.Empty,
                    Weight = 5,
                    Height = 5,
                    Width = 5,
                    Length = 5
                }
            };
            #endregion

            myConn.Close();
        }

        [Test]
        public void GetAll_Valid_ReturnsListOfOrders()
        {
            // Arrange
            var expected = baseOrderList;

            // Act
            var actual = orderRepository.GetAll().ToList();

            // Assert
            actual.Should().BeEquivalentTo(expected);
        }

        [Test]
        public void GetAll_Valid_ReturnsListOfOrdersFilteredByProperties()
        {
            // Arrange
            var expected = baseOrderList.Where(o => o.Status == Status.Loading && o.ProductId == 2).ToList();
            var properties = new Dictionary<string, object>()
            {
                { "Status", 1 },
                { "ProductId", 2 }
            };

            // Act
            var actual = orderRepository.GetAll(properties).ToList();

            // Assert
            actual.Should().BeEquivalentTo(expected);
        }

        [Test]
        public void GetAll_Valid_ReturnsListOfProducts()
        {
            // Arrange
            var expected = baseProductList;

            // Act
            var actual = productRepository.GetAll().ToList();

            // Assert
            actual.Should().BeEquivalentTo(expected);
        }

        [Test]
        public async Task Create_Valid_ReturnsListWithCreatedProduct()
        {
            // Arrange
            var newModel = new Product() { Description = "NewProd", Height = 0, Length = 0, Name = "NewProd", Weight = 0, Width = 0 };

            // Act
            var idOfCreated = await productRepository.CreateAsync(newModel);
            var actual = await productRepository.GetByIdAsync(idOfCreated);

            // Assert
            actual.Should().BeEquivalentTo(newModel);
        }

        [Test]
        public async Task GetById_Valid_ReturnsOrderWithId_1()
        {
            // Arrange
            int id = 1;

            var expected = new Order()
            {
                Id = 1,
                CreatedDate = DateTime.Parse("2/1/1998 12:00:00 AM"),
                UpdatedDate = DateTime.Parse("2/1/1998 12:00:00 AM"),
                Status = Status.InProgress,
                ProductId = 1,
            };

            // Act
            var actual = await orderRepository.GetByIdAsync(id);

            // Assert
            actual.Should().BeEquivalentTo(expected);
        }



        [Test]
        public async Task Delete_Valid_ReturnsListWithoutOrder()
        {
            // Arrange
            var id = 5;

            var expected = baseOrderList;
            expected.RemoveAt(id - 1);

            // Act
            await orderRepository.DeleteAsync(id);
            var actual = orderRepository.GetAll().ToList();

            // Assert
            actual.Should().BeEquivalentTo(expected);
        }

        [Test]
        public async Task GetById_Valid_ReturnsProductWithId_1()
        {
            // Arrange
            int id = 1;

            var expected = new Product()
            {
                Id = id,
                Name = "Prod1",
                Description = "Desc1",
                Weight = 3,
                Height = 3,
                Width = 5,
                Length = 5
            };

            // Act
            var actual = await productRepository.GetByIdAsync(id);

            // Assert
            actual.Should().BeEquivalentTo(expected);
        }



        [Test]
        public async Task Delete_Valid_ReturnsListWithoutProduct()
        {
            // Arrange
            var id = 5;

            var expected = baseProductList;
            expected.RemoveAt(id - 1);

            // Act
            await productRepository.DeleteAsync(id);
            var actual = productRepository.GetAll().ToList();

            // Assert
            actual.Should().BeEquivalentTo(expected);
        }


        [TearDown]
        public void TearDown()
        {
            using var myConn = new SqlConnection(connectionString);
            string dropScript = "DROP DATABASE ProductDB";

            var myCommand = new SqlCommand(dropScript, myConn);
            myConn.Open();
            myCommand.ExecuteNonQuery();
        }
    }
}