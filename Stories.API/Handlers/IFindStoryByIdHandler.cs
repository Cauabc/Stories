using Stories.API.Commands.Requests;
using Stories.API.Commands.Response;
using Stories.API.Queries.Requests;
using Stories.API.Queries.Responses;

namespace Stories.API.Handlers
{
    public interface IFindStoryByIdHandler
    {
        Task<FindStoryByIdResponse> Handle(FindStoryByIdRequest request);
    }
}
