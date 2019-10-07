using System.Collections.Generic;

namespace KatlaSport.DataAccess.OrderCatalogue
{
    /// <summary>
    /// Represents a order status.
    /// </summary>
    public class OrderStatus
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the orders.
        /// </summary>
        /// <value>
        /// The orders.
        /// </value>
        public virtual ICollection<Order> Orders { get; set; }
    }
}
