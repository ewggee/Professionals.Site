using System;
using System.Collections.Generic;

namespace Professionals.Site.Domain.Entitites;

public partial class Employee
{
    public int EmployeeId { get; set; }

    public string LastName { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string? MiddleName { get; set; }

    public string FullName => $"{LastName} {FirstName} {MiddleName}";

    public DateOnly? BitrhDate { get; set; }

    public int PostId { get; set; }

    public int QualificationLevelId { get; set; }

    public DateOnly StartWorkDate { get; set; }

    public DateOnly? EndWorkDate { get; set; }

    public string WorkPhone { get; set; } = null!;

    public string PersonalPhone { get; set; } = null!;

    public int? ManagerId { get; set; }

    public int OfficeId { get; set; }

    public string CorporativeEmail { get; set; } = null!;

    public string Password { get; set; } = null!;

    public virtual ICollection<Employee> InverseManager { get; set; } = new List<Employee>();

    public virtual Employee? Manager { get; set; }

    public virtual ICollection<NewsEvent> NewsEvents { get; set; } = new List<NewsEvent>();

    public virtual Post Post { get; set; } = null!;
}
