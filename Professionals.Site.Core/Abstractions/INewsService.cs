using Professionals.Site.Core.Models;

namespace Professionals.Site.Core.Abstractions
{
    public interface INewsService
    {
        Task<List<NewsDto>> GetAllNewsAsync();
        Task<List<NewsEventDto>> GetAllNewsEventAsync();
    }
}