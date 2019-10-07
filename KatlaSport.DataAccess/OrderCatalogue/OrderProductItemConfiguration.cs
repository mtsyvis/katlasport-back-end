using System.Data.Entity.ModelConfiguration;

namespace KatlaSport.DataAccess.OrderCatalogue
{
    public class OrderProductItemConfiguration : EntityTypeConfiguration<OrderProductItem>
    {
        public OrderProductItemConfiguration()
        {
            ToTable("order_product_item");
            HasKey(i => new { i.OrderId, i.ItemId });
            HasRequired(i => i.Item).WithMany(i => i.Orders).HasForeignKey(i => i.ItemId);
            HasRequired(i => i.Order).WithMany(i => i.Products).HasForeignKey(i => i.OrderId);
            Property(i => i.OrderId).HasColumnName("order_product_item_order_id");
            Property(i => i.ItemId).HasColumnName("order_product_item_product_id");
            Property(i => i.Amount).HasColumnName("order_product_item_amount").IsRequired();
        }
    }
}
