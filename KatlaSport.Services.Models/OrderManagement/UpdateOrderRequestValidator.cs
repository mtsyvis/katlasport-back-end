using FluentValidation;

namespace KatlaSport.Services.OrderManagement
{
    /// <summary>
    /// Represents a validator for <see cref="UpdateOrderRequest"/>
    /// </summary>
    /// <seealso cref="FluentValidation.AbstractValidator{KatlaSport.Services.OrderManagement.UpdateOrderRequest}" />
    public class UpdateOrderRequestValidator : AbstractValidator<UpdateOrderRequest>
    {
        public UpdateOrderRequestValidator()
        {
            RuleFor(r => r.Description).Length(0, 300);
        }
    }
}
