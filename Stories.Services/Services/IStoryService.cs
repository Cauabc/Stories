using Stories.Services.DTOs;

namespace Stories.Services.Services;

public interface IStoryService
{
    IEnumerable<StoryDTO> GetAll();
}
