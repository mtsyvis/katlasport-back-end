using System;
using System.Net;
using System.Web.Http;

namespace KatlaSport.WebApi.Controllers
{
    using System.Threading.Tasks;
    using System.Web.Http.Cors;

    using KatlaSport.Services.OrderManagement;
    using KatlaSport.WebApi.CustomFilters;

    using Microsoft.Web.Http;

    using Swashbuckle.Swagger.Annotations;

    [ApiVersion("1.0")]
    [RoutePrefix("api/orders")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [CustomExceptionFilter]
    [SwaggerResponseRemoveDefaults]
    public class OrderController : ApiController
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService ?? throw new ArgumentNullException(nameof(orderService));
        }

        [HttpGet]
        [Route("")]
        [SwaggerResponse(HttpStatusCode.OK, Description = "Returns a list of orders.", Type = typeof(OrderListItem[]))]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public async Task<IHttpActionResult> GetOrders()
        {
            var orders = await _orderService.GetOrdersAsync();

            return this.Ok(orders);
        }

        [HttpPost]
        [Route("")]
        [SwaggerResponse(HttpStatusCode.Created, Description = "Creates a new order.")]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        [SwaggerResponse(HttpStatusCode.Conflict)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public async Task<IHttpActionResult> AddOrder([FromBody] UpdateOrderRequest createRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var order = await _orderService.CreateOrderAsync(createRequest);
            var location = $"/api/order/{order.Id}";
            return Created<Order>(location, order);
        }
    }
}
