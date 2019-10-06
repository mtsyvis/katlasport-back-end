namespace KatlaSport.DataAccess.OrderCatalogue
{
    /// <summary>
    /// Represents a context for order catalogue domain.
    /// </summary>
    public interface IOrderCatalogueContext : IAsyncEntityStorage
    {
        /// <summary>
        /// Gets the orders.
        /// </summary>
        /// <value>
        /// The orders.
        /// </value>
        IEntitySet<Order> Orders { get; }

        /// <summary>
        /// Gets the order statuses.
        /// </summary>
        /// <value>
        /// The order statuses.
        /// </value>
        IEntitySet<OrderStatus> OrderStatuses { get; }
    }
}
