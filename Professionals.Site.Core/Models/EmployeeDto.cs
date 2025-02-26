namespace Professionals.Site.Core.Models
{
    public class EmployeeDto
    {
        public int EmployeeId { get; set; }

        public required string FullName { get; set; }

        public required DateOnly BitrhDate { get; set; }

        public required string PostName { get; set; }

        public required string WorkPhone { get; set; }

        public required string Email { get; set; }
    }
}
