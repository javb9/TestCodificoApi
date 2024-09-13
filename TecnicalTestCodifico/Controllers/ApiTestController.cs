using Microsoft.AspNetCore.Mvc;
using TecnicalTestCodifico.Interfaces;
using static TecnicalTestCodifico.Models.ApiTestModels;

namespace TecnicalTestCodifico.Controllers
{
    [Route("ApiTest")]
    [ApiController]
    public class ApiTestController : Controller
    {
        private IApiTestInterface _apiTestInterface;
        private response resp = new response();
        public ApiTestController(IApiTestInterface apiTestInterface) 
        {
            _apiTestInterface = apiTestInterface;
        }

        /// <summary>
        /// obtener fecha ultima orden y posible orden futura
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetCustomersPredicatedDate")]
        public ActionResult<IEnumerable<response>> GetCustomersPredicatedDate()
        {
            resp = _apiTestInterface.GetCustomersPredicatedDate();

            return Ok(resp);
        }

        /// <summary>
        /// obtener ordenes por cliente
        /// </summary>
        /// <param name="idCustomer"></param>
        /// <returns></returns>
        [HttpGet("GetClientOrders/{idCustomer}")]
        public ActionResult<IEnumerable<response>> GetClientOrders(int idCustomer)
        {
            resp = _apiTestInterface.GetClientOrders(idCustomer);

            return Ok(resp);
        }

        /// <summary>
        /// obtener empleados
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetEmployees")]
        public ActionResult<IEnumerable<response>> GetEmployees()
        {
            resp = _apiTestInterface.GetEmployees();

            return Ok(resp);
        }

        /// <summary>
        /// obtener transportistas
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetShippers")]
        public ActionResult<IEnumerable<response>> GetShippers()
        {
            resp = _apiTestInterface.GetShippers();

            return Ok(resp);
        }

        /// <summary>
        /// obtener productos
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetProducts")]
        public ActionResult<IEnumerable<response>> GetProducts()
        {
            resp = _apiTestInterface.GetProducts();

            return Ok(resp);
        }

        /// <summary>
        /// crear nueva orden
        /// </summary>
        /// <param name="newOrder"></param>
        /// <returns></returns>
        [HttpPost("CreateOrder")]
        public ActionResult<IEnumerable<response>> CreateOrder(newOrder newOrder)
        {
            resp = _apiTestInterface.CreateOrder(newOrder);

            return Ok(resp);
        }
    }
}
