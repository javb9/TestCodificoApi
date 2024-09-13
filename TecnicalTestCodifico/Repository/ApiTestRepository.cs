using TecnicalTestCodifico.Interfaces;
using TecnicalTestCodifico.Models;
using static TecnicalTestCodifico.Models.ApiTestModels;
using TecnicalTestCodifico.DbConnection;
using System.Data.Common;
using System.Data.SqlClient;

namespace TecnicalTestCodifico.Repository
{
    public class ApiTestRepository : IApiTestInterface
    {
        private response resp = new response();
        private BDConnection _dbConnection;
        public ApiTestRepository(BDConnection dbConnection) 
        {
            _dbConnection = dbConnection;
        }

        public response GetCustomersPredicatedDate()
        {
            List<CustomerDatePredicated> CustomerDatePredicated = new List<CustomerDatePredicated>();

            try
            {

                using (SqlConnection connection = _dbConnection.GetConnection())
                {
                    _dbConnection.OpenConnection(connection);
                    string query = $@"WITH DiferenciaDias AS (
                                                SELECT 
                                                    orders.custid,
                                                    orders.orderdate,
                                                    DATEDIFF(DAY, LAG(orders.orderdate) OVER (PARTITION BY orders.custid ORDER BY orders.orderdate), orders.orderdate) AS DiasEntreOrdenes
                                                FROM Sales.Orders orders
                                            ), PromedioDias AS (
                                                SELECT 
                                                    custid,
                                                    AVG(DiasEntreOrdenes) AS PromedioDiasEntreOrdenes,
                                                    MAX(orderdate) AS UltimaFechaOrden
                                                FROM DiferenciaDias
                                                GROUP BY custid
                                            )
                                            SELECT 
                                                cust.custid,
	                                            cust.contactname CustomerName,
	                                            promDias.UltimaFechaOrden LastOrderDate,
                                                DATEADD(DAY, ISNULL(PromedioDiasEntreOrdenes, 0), UltimaFechaOrden) AS NextPredicatedOrder
                                            FROM PromedioDias promDias
                                            inner join Sales.Customers cust on  cust.custid = promDias.custid";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                CustomerDatePredicated customer =  new CustomerDatePredicated();
                                customer.custid = reader.GetInt32(0);
                                customer.CustomerName = reader.GetString(1);
                                customer.LastOrderDate = reader.GetDateTime(2).ToString();
                                customer.NextPredicatedOrder = reader.GetDateTime(3).ToString();
                                CustomerDatePredicated.Add(customer);
                            }
                        }
                    }

                    _dbConnection.CloseConnection(connection);

                    resp.message = "Data found.";
                    resp.dataResult = CustomerDatePredicated;

                    return resp;

                }
            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public response GetClientOrders(int idCustomer)
        {
            List<ClientOrders> ClientOrders = new List<ClientOrders>();

            try
            {

                using (SqlConnection connection = _dbConnection.GetConnection())
                {
                    _dbConnection.OpenConnection(connection);
                    string query = $@"select orderid, requireddate, shippeddate, shipname, shipaddress, shipcity from Sales.Orders where custid = {idCustomer}";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                ClientOrders order = new ClientOrders();
                                order.OrderId = reader.GetInt32(0);
                                order.RequiredDate = reader.GetDateTime(1).ToString();
                                order.ShippedDate = reader.IsDBNull(2) ? null : reader.GetDateTime(2).ToString();
                                order.ShipName = reader.GetString(3);
                                order.shipaddress = reader.GetString(4);
                                order.shipcity = reader.GetString(5);
                                ClientOrders.Add(order);
                            }
                        }
                    }

                    _dbConnection.CloseConnection(connection);

                    resp.message = "Data found.";
                    resp.dataResult = ClientOrders;

                    return resp;

                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public response GetEmployees()
        {
            List<Employees> Employees = new List<Employees>();

            try
            {

                using (SqlConnection connection = _dbConnection.GetConnection())
                {
                    _dbConnection.OpenConnection(connection);
                    string query = $@"select empid, firstname + ' ' + lastname as FullName from hr.Employees";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Employees Employee = new Employees();
                                Employee.EmpId = reader.GetInt32(0);
                                Employee.FullName = reader.GetString(1);
                                Employees.Add(Employee);
                            }
                        }
                    }

                    _dbConnection.CloseConnection(connection);

                    resp.message = "Data found.";
                    resp.dataResult = Employees;

                    return resp;

                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public response GetShippers()
        {
            List<Shippers> Shippers = new List<Shippers>();

            try
            {

                using (SqlConnection connection = _dbConnection.GetConnection())
                {
                    _dbConnection.OpenConnection(connection);
                    string query = $@"select shipperid, companyname from Sales.Shippers";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Shippers Shipper = new Shippers();
                                Shipper.ShipperId = reader.GetInt32(0);
                                Shipper.CompanyName = reader.GetString(1);
                                Shippers.Add(Shipper);
                            }
                        }
                    }

                    _dbConnection.CloseConnection(connection);

                    resp.message = "Data found.";
                    resp.dataResult = Shippers;

                    return resp;

                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public response GetProducts()
        {
            List<Products> Products = new List<Products>();

            try
            {

                using (SqlConnection connection = _dbConnection.GetConnection())
                {
                    _dbConnection.OpenConnection(connection);
                    string query = $@"select productid, productname from Production.Products";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Products Product = new Products();
                                Product.ProductId = reader.GetInt32(0);
                                Product.ProductName = reader.GetString(1);
                                Products.Add(Product);
                            }
                        }
                    }

                    _dbConnection.CloseConnection(connection);

                    resp.message = "Data found.";
                    resp.dataResult = Products;

                    return resp;

                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public response CreateOrder(newOrder newOrder)
        {
            
            try
            {

                using (SqlConnection connection = _dbConnection.GetConnection())
                {
                    _dbConnection.OpenConnection(connection);
                    string query = @"
                        declare @idOrderCreated int = 0;
            
                        insert into Sales.Orders (custid, empid, orderdate, requireddate, shippeddate, shipperid, freight, shipname, shipaddress, shipcity, shipcountry)
                        values (@custid, @empid, @orderdate, @requireddate, @shippeddate, @shipperid, @freight, @shipname, @shipaddress, @shipcity, @shipcountry);

                        set @idOrderCreated = scope_identity();

                        insert into Sales.OrderDetails (orderid, productid, unitprice, qty, discount)
                        values (@idOrderCreated, @productid, @unitprice, @qty, @discount);";

                    SqlCommand command = new SqlCommand(query, connection);

                    command.Parameters.AddWithValue("@custid", newOrder.custid);
                    command.Parameters.AddWithValue("@empid", newOrder.empid);
                    command.Parameters.AddWithValue("@orderdate", newOrder.orderdate);
                    command.Parameters.AddWithValue("@requireddate", newOrder.requireddate);
                    command.Parameters.AddWithValue("@shippeddate", (object)newOrder.shippeddate ?? DBNull.Value); 
                    command.Parameters.AddWithValue("@shipperid", newOrder.shipperid);
                    command.Parameters.AddWithValue("@freight", newOrder.freight);
                    command.Parameters.AddWithValue("@shipname", newOrder.shipname);
                    command.Parameters.AddWithValue("@shipaddress", newOrder.shipaddress);
                    command.Parameters.AddWithValue("@shipcity", newOrder.shipcity);
                    command.Parameters.AddWithValue("@shipcountry", newOrder.shipcountry);

                    // Parámetros para OrderDetails
                    command.Parameters.AddWithValue("@productid", newOrder.orderDetail.productid);
                    command.Parameters.AddWithValue("@unitprice", newOrder.orderDetail.unitprice);
                    command.Parameters.AddWithValue("@qty", newOrder.orderDetail.qty);
                    command.Parameters.AddWithValue("@discount", newOrder.orderDetail.discount);

                    command.ExecuteNonQuery();


                    _dbConnection.CloseConnection(connection);
                    resp.message = "Order created succesfull";
                    resp.dataResult = null;

                    return resp;

                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
