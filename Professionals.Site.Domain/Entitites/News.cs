using System;
using System.Collections.Generic;

namespace Professionals.Site.Domain.Entitites;

public partial class News
{
    public int NewsId { get; set; }

    public string Title { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public string Description { get; set; } = null!;

    public byte[] Picture { get; set; } = null!;

    public string? PicturePath { get; set; }
}
