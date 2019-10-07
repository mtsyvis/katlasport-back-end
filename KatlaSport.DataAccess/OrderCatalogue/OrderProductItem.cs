using KatlaSport.DataAccess.ProductStore;

namespace KatlaSport.DataAccess.OrderCatalogue
{
    public class OrderProductItem
    {
        public int OrderId { get; set; }

        public int ItemId { get; set; }

        public int Amount { get; set; }

        public virtual Order Order { get; set; }

        public virtual StoreItem Item { get; set; }
    }
}
