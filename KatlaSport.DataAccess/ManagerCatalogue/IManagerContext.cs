namespace KatlaSport.DataAccess.ManagerCatalogue
{
    /// <summary>
    /// Represents a context for manager domain.
    /// </summary>
    public interface IManagerContext : IAsyncEntityStorage
    {
        /// <summary>
        /// Gets the managers.
        /// </summary>
        /// <value>
        /// The managers.
        /// </value>
        IEntitySet<Manager> Managers { get; }
    }
}
