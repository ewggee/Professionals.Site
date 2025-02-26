using Microsoft.AspNetCore.Mvc;
using Professionals.Site.Core.Abstractions;

namespace Professionals.Site.MVC.Controllers
{
    public class HomeController(IEmployeeService employeeService, INewsService newsService) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var employees = await employeeService.GetAllAsync();

            var news = await newsService.GetAllNewsAsync();

            var newsEvents = await newsService.GetAllNewsEventAsync();

            ViewBag.Employees = employees;
            ViewBag.News = news;
            ViewBag.NewsEvents = newsEvents;

            return View();
        }
    }
}
