namespace Professionals.Site.Core.Models
{
    public class NewsDto
    {
        public int NewsId { get; set; }

        public required string Title { get; set; }

        public required DateTime CreatedAt { get; set; }

        public required string Description { get; set; }

        public byte[]? Picture { get; set; }

        public required string PicturePath { get; set; }
    }
}
