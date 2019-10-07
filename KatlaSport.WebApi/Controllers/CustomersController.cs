using System.Web.Http;

namespace KatlaSport.WebApi.Controllers
{
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;
    using System.Web.Http.Cors;

    using KatlaSport.Services.CustomerManagement;
    using KatlaSport.WebApi.CustomFilters;

    using Microsoft.Web.Http;

    using Swashbuckle.Swagger.Annotations;

    [ApiVersion("1.0")]
    [RoutePrefix("api/customers")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [CustomExceptionFilter]
    [SwaggerResponseRemoveDefaults]
    public class CustomersController : ApiController
    {
        private readonly ICustomerManagementService _customerService;

        public CustomersController(ICustomerManagementService customerManagementService)
        {
            _customerService = customerManagementService;
        }

        [HttpGet]
        [Route("show")]
        [SwaggerResponse(HttpStatusCode.OK, Description = "Returns a list of customers.", Type = typeof(CustomerFullInfo[]))]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public async Task<IHttpActionResult> GetCustomers([FromUri] int start = 0, [FromUri] int amount = 100)
        {
            var customers = await _customerService.GetCustomersAsync(start, amount);
            return Ok(customers);
        }

        [HttpGet]
        [Route("show/{id:int:min(1)}")]
        [SwaggerResponse(HttpStatusCode.OK, Description = "Returns a customer.", Type = typeof(CustomerFullInfo))]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public async Task<IHttpActionResult> GetCustomer([FromUri] int id)
        {
            var customer = await _customerService.GetCustomerAsync(id);
            return Ok(customer);
        }

        [HttpPost]
        [Route("create")]
        [SwaggerResponse(HttpStatusCode.Created, Description = "Creates a new customer.")]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        [SwaggerResponse(HttpStatusCode.Conflict)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public async Task<IHttpActionResult> AddCustomer([FromBody] UpdateCustomerRequest createRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var customer = await _customerService.CreateCustomerAsync(createRequest);
            var location = $"/api/customers/create/{customer.Id}";
            return Created<CustomerFullInfo>(location, customer);
        }

        [HttpPost]
        [Route("update/{id:int:min(1)}")]
        [SwaggerResponse(HttpStatusCode.NoContent, Description = "Updates an existed customer.")]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        [SwaggerResponse(HttpStatusCode.Conflict)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public async Task<IHttpActionResult> UpdateCustomer([FromUri] int id, [FromBody] UpdateCustomerRequest updateRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _customerService.UpdateCustomerAsync(id, updateRequest);
            return ResponseMessage(Request.CreateResponse(HttpStatusCode.NoContent));
        }

        [HttpPost]
        [Route("destroy/{id:int:min(1)}")]
        [SwaggerResponse(HttpStatusCode.NoContent, Description = "Deletes an existed customer.")]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        [SwaggerResponse(HttpStatusCode.Conflict)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public async Task<IHttpActionResult> DeleteCustomer([FromUri] int id)
        {
            await _customerService.DeleteCustomerAsync(id);
            return ResponseMessage(Request.CreateResponse(HttpStatusCode.NoContent));
        }
    }
}
