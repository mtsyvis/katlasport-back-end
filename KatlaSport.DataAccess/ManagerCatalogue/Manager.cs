﻿using System.Collections.Generic;
using KatlaSport.DataAccess.OrderCatalogue;

namespace KatlaSport.DataAccess.ManagerCatalogue
{
    /// <summary>
    /// Represent a manager.
    /// </summary>
    public class Manager
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the parent identifier.
        /// </summary>
        /// <value>
        /// The parent identifier.
        /// </value>
        public int? ParentId { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the phone.
        /// </summary>
        /// <value>
        /// The phone.
        /// </value>
        public string Phone { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether a product is deleted.
        /// </summary>
        public bool IsDeleted { get; set; }

        /// <summary>
        /// Gets or sets the photo URL.
        /// </summary>
        /// <value>
        /// The photo URL.
        /// </value>
        public string PhotoUrl { get; set; }

        /// <summary>
        /// Gets or sets the orders.
        /// </summary>
        /// <value>
        /// The orders.
        /// </value>
        public virtual ICollection<Order> Orders { get; set; }

        /// <summary>
        /// Gets or sets the bos manager.
        /// </summary>
        /// <value>
        /// The bos manager.
        /// </value>
        public virtual Manager BosManager { get; set; }

        /// <summary>
        /// Gets or sets the subordinates.
        /// </summary>
        /// <value>
        /// The subordinates.
        /// </value>
        public virtual ICollection<Manager> Subordinates { get; set; }
    }
}
