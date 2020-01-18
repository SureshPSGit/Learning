using ExampleMediatR.Commands;
using FluentValidation;

namespace ExampleMediatR.Validation
{
    public class CreateCustomerOrderCommandValidator : AbstractValidator<CreateCustomerOrderCommand>
    {
        public CreateCustomerOrderCommandValidator()
        {
            RuleFor(x => x.CustomerId)
                .NotEmpty();
            
            RuleFor(x => x.ProductId)
                .NotEmpty();
        }
    }
}