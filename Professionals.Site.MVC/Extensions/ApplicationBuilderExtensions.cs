using Microsoft.EntityFrameworkCore;
using Professionals.Site.Core.Abstractions;
using Professionals.Site.Core.Services;
using Professionals.Site.Domain;

namespace Professionals.Site.MVC.Extensions;

public static class ApplicationBuilderExtensions
{
    public static WebApplicationBuilder AddData(this WebApplicationBuilder builder)
    {
        builder.Services.AddDbContext<ProfessionalsContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

        return builder;
    }

    public static WebApplicationBuilder AddServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IEmployeeService, EmployeeService>();
        builder.Services.AddScoped<INewsService, NewsService>();

        return builder;
    }
}