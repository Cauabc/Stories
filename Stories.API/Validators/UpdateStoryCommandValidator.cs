using FluentValidation;
using Stories.API.Commands;

namespace Stories.API.Validators
{
    public sealed class UpdateStoryCommandValidator : AbstractValidator<UpdateStoryCommand>
    {
        public UpdateStoryCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty();

            RuleFor(x => x.Title).NotEmpty().MaximumLength(50);

            RuleFor(x => x.Description).NotEmpty().MaximumLength(150);

            RuleFor(x => x.Department).NotEmpty().MaximumLength(30);
        }
    }
}
