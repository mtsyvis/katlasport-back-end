namespace KatlaSport.DataAccess.OrderCatalogue
{
    internal sealed class OrderCatalogueContext : DomainContextBase<ApplicationDbContext>, IOrderCatalogue
    {
        public OrderCatalogueContext(ApplicationDbContext dbContext)
            : base(dbContext)
        {
        }

        public IEntitySet<Order> Orders => GetDbSet<Order>();

        public IEntitySet<OrderStatus> OrderStatuses => GetDbSet<OrderStatus>();
    }
}
