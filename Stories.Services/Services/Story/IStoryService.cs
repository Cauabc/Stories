using Stories.Services.DTOs;

namespace Stories.Services.Services.Story;

public interface IStoryService
{
    IEnumerable<StoryDTO> GetAll();
    StoryDTO GetById(Guid id);
    Guid Create(string title, string description, string department);
}
