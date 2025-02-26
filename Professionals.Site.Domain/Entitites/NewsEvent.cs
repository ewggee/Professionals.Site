using System;
using System.Collections.Generic;

namespace Professionals.Site.Domain.Entitites;

public partial class NewsEvent
{
    public int NewsEventId { get; set; }

    public string Title { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public int AuthorId { get; set; }

    public string Text { get; set; } = null!;

    public virtual Employee Author { get; set; } = null!;
}
