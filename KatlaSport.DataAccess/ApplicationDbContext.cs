using System.Data.Entity;
using System.Reflection;
using KatlaSport.DataAccess.CustomerCatalogue;
using KatlaSport.DataAccess.Migrations;
using KatlaSport.DataAccess.ProductCatalogue;
using KatlaSport.DataAccess.ProductStore;
using KatlaSport.DataAccess.ProductStoreHive;

namespace KatlaSport.DataAccess
{
    using KatlaSport.DataAccess.ManagerCatalogue;
    using KatlaSport.DataAccess.OrderCatalogue;

    /// <summary>
    /// Represents an application database context.
    /// </summary>
    internal sealed class ApplicationDbContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationDbContext"/> class.
        /// </summary>
        public ApplicationDbContext()
            : base("AzureConnection")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ApplicationDbContext, Configuration>(true));

            // DatabaseLogger = databaseLogger;

            // if (DatabaseLogger != null)
            // {
            //    Database.Log = DatabaseLogger.LogDatabaseCall;
            // }
        }

        /// <summary>
        /// Gets or sets a database logger.
        /// </summary>
        public IDatabaseLogger DatabaseLogger { get; set; }

        /// <summary>
        /// Gets or sets a <see cref="DbSet"/> for <see cref="ProductCategory"/>.
        /// </summary>
        public DbSet<ProductCategory> ProductCategories { get; set; }

        /// <summary>
        /// Gets or sets a <see cref="DbSet"/> for <see cref="CatalogueProduct"/>.
        /// </summary>
        public DbSet<CatalogueProduct> CatalogueProducts { get; set; }

        /// <summary>
        /// Gets or sets a <see cref="DbSet"/> for <see cref="StoreHive"/>.
        /// </summary>
        public DbSet<StoreHive> StoreHives { get; set; }

        /// <summary>
        /// Gets or sets a <see cref="DbSet"/> for <see cref="StoreHiveSection"/>.
        /// </summary>
        public DbSet<StoreHiveSection> HiveSections { get; set; }

        /// <summary>
        /// Gets or sets a <see cref="DbSet"/> for <see cref="StoreItem"/>.
        /// </summary>
        public DbSet<StoreItem> StoreItems { get; set; }

        /// <summary>
        /// Gets or sets a <see cref="DbSet"/> for <see cref="StoreHiveSectionCategory"/>.
        /// </summary>
        public DbSet<StoreHiveSectionCategory> SectionCategories { get; set; }

        /// <summary>
        /// Gets or sets a <see cref="DbSet"/> for <see cref="Customer"/>.
        /// </summary>
        public DbSet<Customer> Customers { get; set; }

        /// <summary>
        /// Gets or sets the managers.
        /// </summary>
        /// <value>
        /// The managers.
        /// </value>
        public DbSet<Manager> Managers { get; set; }

        /// <summary>
        /// Gets or sets the orders.
        /// </summary>
        /// <value>
        /// The orders.
        /// </value>
        public DbSet<Order> Orders { get; set; }

        /// <summary>
        /// Gets or sets the order statuses.
        /// </summary>
        /// <value>
        /// The order statuses.
        /// </value>
        public DbSet<OrderStatus> OrderStatuses { get; set; }

        /// <summary>
        /// Gets or sets the order product items.
        /// </summary>
        /// <value>
        /// The order product items.
        /// </value>
        public DbSet<OrderProductItem> OrderProductItems { get; set; }

        /// <summary>
        /// Overrides base method.
        /// </summary>
        /// <param name="modelBuilder"><see cref="DbModelBuilder"/>.</param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.AddFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }
    }
}
