using MediatR;
using Stories.Services.Services.Account;

namespace Stories.API.Commands
{
    public class CreateAccountCommandHandler(IAccountService service) : IRequestHandler<CreateAccountCommand, Guid>
    {
        private readonly IAccountService _service = service;

        public async Task<Guid> Handle(CreateAccountCommand request, CancellationToken cancellationToken)
        {
            return await _service.Create(request.Name, request.Email);
        }
    }
}
