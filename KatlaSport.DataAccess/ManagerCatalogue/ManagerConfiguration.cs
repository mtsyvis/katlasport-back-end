using System.Data.Entity.ModelConfiguration;

namespace KatlaSport.DataAccess.ManagerCatalogue
{
    public class ManagerConfiguration : EntityTypeConfiguration<Manager>
    {
        public ManagerConfiguration()
        {
            ToTable("managers");
            HasKey(i => i.Id);
            Property(i => i.Id).HasColumnName("manager_id");
            Property(i => i.Name).HasColumnName("manager_name").IsRequired().HasMaxLength(300);
            Property(i => i.Phone).HasColumnName("manager_phone").IsRequired().HasMaxLength(20);
        }
    }
}
