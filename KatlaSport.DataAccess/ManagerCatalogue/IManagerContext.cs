namespace KatlaSport.DataAccess.ManagerCatalogue
{
    /// <summary>
    /// Represents a context for manager domain.
    /// </summary>
    public interface IManagerContext
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
