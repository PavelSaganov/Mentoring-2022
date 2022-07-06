# Mentoring 2022
 
# How to start tests
 - Change **Data Source** in connection strings
 ### NHibernateTests
 ```
 20     private const string connectionStringToCreateDB = "Data Source=EPBYGOMW0254;Integrated Security=True";
 21     private const string connectionString = Data Source=EPBYGOMW0254;Initial Catalog=ProductDB;Integrated Security=True";
 ```
 ### AdoRepositoryTests
 ```
 18     private const string connectionStringToCreateDB = "Data Source=EPBYGOMW0254;Integrated Security=True";
 19     private const string connectionString = "Data Source=EPBYGOMW0254;Initial Catalog=ProductDB;Integrated Security=True";
 ```
