using MediatR;
using Stories.API.Commands.Requests;
using Stories.API.Commands.Response;
using Stories.Services.Services.Story;

namespace Stories.API.Handlers
{
    public class DeleteStoryByIdHandler(IStoryService service) : IRequestHandler<DeleteStoryByIdRequest, DeleteStoryByIdResponse>
    {
        private readonly IStoryService _service = service;

        public async Task<DeleteStoryByIdResponse> Handle(DeleteStoryByIdRequest request, CancellationToken cancellationToken)
        {
            var isSucceded = await _service.Delete(request.Id);

            return new DeleteStoryByIdResponse { IsSucceded = isSucceded };
        }
    }
}
