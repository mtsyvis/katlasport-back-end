namespace KatlaSport.Services.OrderManagement
{
    public class OrderProductListItem
    {
        public int ItemId { get; set; }

        public string ProductName { get; set; }

        public decimal? ProductPrice { get; set; }

        public int Amount { get; set; }
    }
}
