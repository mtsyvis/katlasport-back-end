using System;
using System.Net;
using System.Web.Http;

namespace KatlaSport.WebApi.Controllers
{
    using System.Net.Http;
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

        [HttpGet]
        [Route("orderId:int:min(1)")]
        [SwaggerResponse(HttpStatusCode.OK, Description = "Returns a list of order.", Type = typeof(OrderListItem))]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public async Task<IHttpActionResult> GetOrder([FromUri] int orderId)
        {
            var order = await _orderService.GetOrderAsync(orderId);

            return this.Ok(order);
        }

        [HttpGet]
        [Route("{customerId:int:min(1)}/orders")]
        [SwaggerResponse(HttpStatusCode.OK, Description = "Returns a list of orders by customer.", Type = typeof(OrderListItem[]))]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public async Task<IHttpActionResult> GetOrdersByCustomer([FromUri] int customerId)
        {
            var orders = await _orderService.GetOrdersByCustomerAsync(customerId);

            return Ok(orders);
        }

        [HttpGet]
        [Route("{orderId:int:min(1)}/products")]
        [SwaggerResponse(HttpStatusCode.OK, Description = "Returns a list of products info.", Type = typeof(OrderProductListItem[]))]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public async Task<IHttpActionResult> GetProductsInfo([FromUri] int orderId)
        {
            var productsInfo = await _orderService.GetProductsInfo(orderId);

            return Ok(productsInfo);
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

        // [HttpPut]
        // [Route("{id:int:min(1)}")]
        // [SwaggerResponse(HttpStatusCode.NoContent, Description = "Updates an existed order.")]
        // [SwaggerResponse(HttpStatusCode.BadRequest)]
        // [SwaggerResponse(HttpStatusCode.Conflict)]
        // [SwaggerResponse(HttpStatusCode.NotFound)]
        // [SwaggerResponse(HttpStatusCode.InternalServerError)]
        // public async Task<IHttpActionResult> UpdateOrder([FromUri] int id, [FromBody] UpdateOrderRequest updateRequest)
        // {
        //     if (!ModelState.IsValid)
        //     {
        //         return this.BadRequest(ModelState);
        //     }
        //
        //     await _orderService.UpdateOrderAsync(id, updateRequest);
        //     return ResponseMessage(Request.CreateResponse(HttpStatusCode.NoContent));
        // }

        [HttpDelete]
        [Route("{id:int:min(1)}")]
        [SwaggerResponse(HttpStatusCode.NoContent, Description = "Deletes an existed order.")]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        [SwaggerResponse(HttpStatusCode.Conflict)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public async Task<IHttpActionResult> DeleteOrder([FromUri] int id)
        {
            await this._orderService.DeleteOrderAsync(id);
            return ResponseMessage(Request.CreateResponse(HttpStatusCode.NoContent));
        }

        [HttpPut]
        [Route("{id:int:min(1)}")]
        [SwaggerResponse(HttpStatusCode.NoContent, Description = "Adding a product to existed order.")]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        [SwaggerResponse(HttpStatusCode.Conflict)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public async Task<IHttpActionResult> AddProductToOrder([FromUri] int id, [FromBody] OrderProductListItem orderProduct)
        {
            await _orderService.AddProductToOrder(id, orderProduct);
            return ResponseMessage(Request.CreateResponse(HttpStatusCode.NoContent));
        }
    }
}
