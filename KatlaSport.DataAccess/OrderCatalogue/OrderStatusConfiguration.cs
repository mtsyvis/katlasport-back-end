using System.Data.Entity.ModelConfiguration;

namespace KatlaSport.DataAccess.OrderCatalogue
{
    public class OrderStatusConfiguration : EntityTypeConfiguration<OrderStatus>
    {
        public OrderStatusConfiguration()
        {
            ToTable("order_statuses");
            HasKey(i => i.Id);
            Property(i => i.Id).HasColumnName("order_status_id");
            Property(i => i.Name).HasColumnName("order_status_name").IsRequired();
        }
    }
}
