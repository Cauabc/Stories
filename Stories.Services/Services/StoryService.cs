using Stories.Infrastructure.Data;
using Stories.Infrastructure.Models;

namespace Stories.Services.Services;

public class StoryService(ApplicationDataContext context)
{
    private readonly ApplicationDataContext _context = context;
}
