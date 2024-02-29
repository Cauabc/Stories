using FluentValidation;
using Stories.API.Commands;
using Stories.API.Queries;

namespace Stories.API.Validators
{
    public class DeleteStoryCommandValidator : AbstractValidator<DeleteStoryCommand>
    {
        public DeleteStoryCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
