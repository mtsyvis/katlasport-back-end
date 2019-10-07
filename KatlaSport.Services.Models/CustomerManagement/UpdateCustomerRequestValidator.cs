using FluentValidation;

namespace KatlaSport.Services.CustomerManagement
{
    public class UpdateCustomerRequestValidator : AbstractValidator<UpdateCustomerRequest>
    {
        public UpdateCustomerRequestValidator()
        {
        }
    }
}
