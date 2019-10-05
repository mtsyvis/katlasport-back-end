using KatlaSport.DataAccess.ProductStore;

namespace KatlaSport.DataAccess.OrderStoreItem
{
    using KatlaSport.DataAccess.OrderCatalogue;

    public class OrderStoreItem
    {
        public int Id { get; set; }

        public int OrderId { get; set; }

        public int ItemId { get; set; }

        public int Amount { get; set; }

        public virtual Order ProgressOrder { get; set; }

        public virtual StoreItem Item { get; set; }
    }
}
