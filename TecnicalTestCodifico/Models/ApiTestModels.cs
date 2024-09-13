using Microsoft.AspNetCore.Mvc;

namespace TecnicalTestCodifico.Models
{
    public class ApiTestModels
    {
        public class response
        {
            public string message { get; set;}
            public object dataResult { get; set;}
        }

        public class CustomerDatePredicated
        {
            public int custid { get; set;}
            public string CustomerName { get; set;}
            public string LastOrderDate { get; set; }
            public string NextPredicatedOrder { get; set; }
        }

        public class ClientOrders
        {
            public int OrderId { get; set; }
            public string RequiredDate { get; set;}
            public string ShippedDate { get; set;}
            public string ShipName { get; set;}
            public string shipaddress { get; set; }
            public string shipcity { get; set; }
        }

        public class Employees
        {
            public int EmpId { get; set; }
            public string FullName { get; set; }
        }

        public class Shippers
        {
            public int ShipperId { get; set; }
            public string CompanyName { get; set; }
        }

        public class Products
        {
            public int ProductId { get; set; }
            public string ProductName { get; set; }
        }

        public class newOrder
        {
            public int custid { get; set;}
            public int empid { get; set; }
            public string orderdate { get; set; }
            public string requireddate { get; set; }
            public string? shippeddate { get; set; }
            public int shipperid { get; set; }
            public decimal freight { get; set; }
            public string shipname { get; set; }
            public string shipaddress { get; set; }
            public string shipcity { get; set; }
            public string shipcountry { get; set; }
            public orderDetail orderDetail { get; set; }
        }

        public class orderDetail
        {
            public int productid { get; set; }
            public decimal unitprice { get; set; }
            public int qty { get; set; }
            public decimal discount { get; set; }
        }

    }
}
