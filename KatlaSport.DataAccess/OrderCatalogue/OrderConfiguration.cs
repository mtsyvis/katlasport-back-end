using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace KatlaSport.DataAccess.OrderCatalogue
{
    public class OrderConfiguration : EntityTypeConfiguration<Order>
    {
        public OrderConfiguration()
        {
            ToTable("order_records");
            HasKey(i => i.Id);
            HasRequired(i => i.Customer).WithMany(i => i.Orders).HasForeignKey(i => i.CustomerId);
            HasRequired(i => i.Manager).WithMany(i => i.Orders).HasForeignKey(i => i.ManagerId);
            HasRequired(i => i.Status).WithMany(i => i.Orders).HasForeignKey(i => i.StatusId);
            HasRequired(i => i.Product).WithMany(i => i.Orders).HasForeignKey(i => i.ProductId);
            Property(i => i.Id).HasColumnName("order_id").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(i => i.OrderDate).HasColumnName("order_date").IsRequired();
            Property(i => i.Description).HasColumnName("order_description").HasMaxLength(300);
            Property(i => i.CustomerId).HasColumnName("order_customer_id");
            Property(i => i.ManagerId).HasColumnName("order_manager_id");
            Property(i => i.StatusId).HasColumnName("order_status_id");
            Property(i => i.ProductId).HasColumnName("order_product_id");
        }
    }
}
