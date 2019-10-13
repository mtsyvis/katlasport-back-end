using FluentValidation.Attributes;

namespace KatlaSport.Services.OrderManagement
{
    /// <summary>
    /// Represents a request for creating and updating a order.
    /// </summary>
    [Validator(typeof(UpdateOrderRequest))]
    public class UpdateOrderRequest
    {
        /// <summary>
        /// Gets or sets the customer identifier.
        /// </summary>
        /// <value>
        /// The customer identifier.
        /// </value>
        public int CustomerId { get; set; }

        /// <summary>
        /// Gets or sets the status identifier.
        /// </summary>
        /// <value>
        /// The status identifier.
        /// </value>
        public int StatusId { get; set; }

        /// <summary>
        /// Gets or sets the product identifier.
        /// </summary>
        /// <value>
        /// The product identifier.
        /// </value>
        public int ProductId { get; set; }

        /// <summary>
        /// Gets or sets the product amount.
        /// </summary>
        /// <value>
        /// The product amount.
        /// </value>
        public int ProductAmount { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description { get; set; }
    }
}
