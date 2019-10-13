using FluentValidation.Attributes;

namespace KatlaSport.Services.ManagerControl
{
    [Validator(typeof(UpdateManagerRequestValidator))]
    public class UpdateManagerRequest
    {
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
        /// Gets or sets a value indicating whether a product category is deleted.
        /// </summary>
        public bool IsDeleted { get; set; }
    }
}
