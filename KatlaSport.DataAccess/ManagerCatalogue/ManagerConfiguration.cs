using System.Data.Entity.ModelConfiguration;

namespace KatlaSport.DataAccess.ManagerCatalogue
{
    public class ManagerConfiguration : EntityTypeConfiguration<Manager>
    {
        public ManagerConfiguration()
        {
            ToTable("managers");
            HasKey(i => i.Id);
            HasOptional(i => i.BosManager).WithMany(i => i.Subordinates).HasForeignKey(i => i.ParentId)
                .WillCascadeOnDelete(false);
            Property(i => i.ParentId).HasColumnName("manager_parent_id").IsOptional();
            Property(i => i.Id).HasColumnName("manager_id");
            Property(i => i.Name).HasColumnName("manager_name").IsRequired().HasMaxLength(300);
            Property(i => i.Phone).HasColumnName("manager_phone").IsRequired().HasMaxLength(20);
            Property(i => i.IsDeleted).HasColumnName("deleted").IsRequired();
            Property(i => i.PhotoUrl).HasColumnName("manager_photo_url").IsOptional();
        }
    }
}
