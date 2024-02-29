using MediatR;

namespace Stories.API.Commands
{
    public class CreateAccountCommand : IRequest<Guid>
    {
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
