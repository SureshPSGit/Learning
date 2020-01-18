using FluentValidation;
using ScrutorExample.Commands;

namespace ScrutorExample.Validation
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