using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stories.Infrastructure.Models;

public class Vote
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public Guid StoryId { get; set; }
    public Story Story { get; set; }
    public Guid AccountId { get; set; }
    public Account Account { get; set; }
    public bool Upvote { get; set; }
}
