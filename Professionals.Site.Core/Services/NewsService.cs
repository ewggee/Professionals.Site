using Microsoft.EntityFrameworkCore;
using Professionals.Site.Core.Abstractions;
using Professionals.Site.Core.Models;
using Professionals.Site.Domain;

namespace Professionals.Site.Core.Services
{
    public class NewsService(ProfessionalsContext context) : INewsService
    {
        public async Task<List<NewsDto>> GetAllNewsAsync()
        {
            var news = await context.News.ToListAsync();

            return news.Select(n => new NewsDto
            {
                Description = n.Description,
                CreatedAt = n.CreatedAt,
                PicturePath = n.PicturePath!,
                Title = n.Title
            }).ToList();
        }

        public async Task<List<NewsEventDto>> GetAllNewsEventAsync()
        {
            var newsEvents = await context.NewsEvents
                .Include(ne => ne.Author)
                .ToListAsync();

            return newsEvents.Select(ne => new NewsEventDto
            {
                CreatedAt = ne.CreatedAt,
                Title = ne.Title,
                AuthorFullName = ne.Author.FullName,
                Text = ne.Text
            }).ToList();
        }
    }
}
