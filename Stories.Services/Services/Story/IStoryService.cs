using Stories.Services.DTOs;

namespace Stories.Services.Services.Story;

public interface IStoryService
{
    Task<IEnumerable<StoryDTO>> GetAll();
    Task<StoryDTO> GetById(Guid id);
    Task<Guid> Create(string title, string description, string department);
    bool Delete(Guid id);
    bool Update(Guid id, string title, string description, string department);
    void PostVote(Guid storyId, Guid accountId, bool upvote);
}
