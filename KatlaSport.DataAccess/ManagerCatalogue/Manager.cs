using System.Collections.Generic;
using KatlaSport.DataAccess.OrderCatalogue;

namespace KatlaSport.DataAccess.ManagerCatalogue
{
    /// <summary>
    /// Represent a manager.
    /// </summary>
    public class Manager
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Phone { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
