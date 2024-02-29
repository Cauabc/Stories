using MediatR;
using Stories.API.Application.ViewModels;
using Stories.Services.Services.Account;

namespace Stories.API.Queries
{
    public class GetAllUsersQueryHandler(IAccountService service) : IRequestHandler<GetAllUsersQuery, IEnumerable<AccountViewModel>>
    {
        private readonly IAccountService _service = service;

        public async Task<IEnumerable<AccountViewModel>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var result = await _service.GetAll();

            return result.Select(s => new AccountViewModel
            {
                Id = s.Id,
                Name = s.Name,
                Email = s.Email,
            });
        }
    }
}
