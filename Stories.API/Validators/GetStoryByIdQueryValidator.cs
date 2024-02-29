using FluentValidation;
using Stories.API.Commands;
using Stories.API.Queries;

namespace Stories.API.Validators
{
    public class GetStoryByIdQueryValidator : AbstractValidator<GetStoryByIdQuery>
    {
        public GetStoryByIdQueryValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
