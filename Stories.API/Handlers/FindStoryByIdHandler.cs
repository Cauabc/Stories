using MediatR;
using Stories.API.Queries.Requests;
using Stories.API.Queries.Responses;
using Stories.Services.Services.Story;

namespace Stories.API.Handlers
{
    public class FindStoryByIdHandler(IStoryService service) : IRequestHandler<FindStoryByIdRequest, FindStoryByIdResponse>
    {
        private readonly IStoryService _service = service;
        public async Task<FindStoryByIdResponse> Handle(FindStoryByIdRequest request, CancellationToken cancellationToken)
        {
            var result = await _service.GetById(request.Id);

            if (result == null)
                return null;

            var response = new FindStoryByIdResponse
            {
                Id = result.Id,
                Title = result.Title,
                Description = result.Description,
                Department = result.Department,
                Likes = result.Likes,
                Dislikes = result.Dislikes
            };

            return response;
        }
    }
}
