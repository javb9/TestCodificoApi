using static TecnicalTestCodifico.Models.ApiTestModels;

namespace TecnicalTestCodifico.Interfaces
{
    public interface IApiTestInterface 
    {
        public response GetCustomersPredicatedDate();
        public response GetClientOrders(int idCustomer);
        public response GetEmployees();
        public response GetShippers();
        public response GetProducts();
        public response CreateOrder(newOrder newOrder);
    }
}
