using Stories.API.Commands.Requests;
using Stories.API.Commands.Response;

namespace Stories.API.Handlers
{
    public interface ICreateStoryHandler
    {
        Task<CreateStoryResponse> Handle(CreateStoryRequest request);
    }
}
