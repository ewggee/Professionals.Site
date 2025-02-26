using Professionals.Site.Core.Models;

namespace Professionals.Site.Core.Abstractions
{
    public interface IEmployeeService
    {
        Task<List<EmployeeDto>> GetAllAsync();
    }
}