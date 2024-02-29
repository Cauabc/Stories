using MediatR;
using Stories.API.Application.ViewModels;

namespace Stories.API.Queries
{
    public class GetAllUsersQuery : IRequest<IEnumerable<AccountViewModel>>
    {
    }
}
