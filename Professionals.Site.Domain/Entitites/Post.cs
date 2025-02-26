using System;
using System.Collections.Generic;

namespace Professionals.Site.Domain.Entitites;

public partial class Post
{
    public int PostId { get; set; }

    public string? PostName { get; set; }

    public int DepartmentId { get; set; }

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
