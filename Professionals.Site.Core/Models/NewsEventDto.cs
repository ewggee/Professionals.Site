namespace Professionals.Site.Core.Models;

public class NewsEventDto
{
    public int NewsEventId { get; set; }

    public required string Title { get; set; }

    public required DateTime CreatedAt { get; set; }

    public int AuthorId { get; set; }

    public required string Text { get; set; }

    public required string AuthorFullName { get; set; } 
}
