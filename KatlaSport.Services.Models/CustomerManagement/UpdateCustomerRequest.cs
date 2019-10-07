using FluentValidation.Attributes;

namespace KatlaSport.Services.CustomerManagement
{
    [Validator(typeof(UpdateCustomerRequestValidator))]
    public class UpdateCustomerRequest
    {
        /// <summary>
        /// Gets or sets a customer address.
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Gets or sets a customer phone.
        /// </summary>
        public string Phone { get; set; }
    }
}
