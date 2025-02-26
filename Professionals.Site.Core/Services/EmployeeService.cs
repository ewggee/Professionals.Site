using Microsoft.EntityFrameworkCore;
using Professionals.Site.Core.Abstractions;
using Professionals.Site.Core.Models;
using Professionals.Site.Domain;

namespace Professionals.Site.Core.Services
{
    public class EmployeeService(ProfessionalsContext context) : IEmployeeService
    {
        public async Task<List<EmployeeDto>> GetAllAsync()
        {
            var employees = await context.Employees
                .Include(e => e.Post)
                .ToListAsync();

            return employees.Select(e => new EmployeeDto
            {
                FullName = e.FullName,
                PostName = e.Post.PostName!,
                WorkPhone = e.WorkPhone,
                Email = e.CorporativeEmail,
                BitrhDate = e.BitrhDate!.Value
            }).ToList();
        }
    }
}
