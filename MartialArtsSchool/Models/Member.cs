using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MartialArtsSchool.Models;

public partial class Member
{
    public int IdMemeber { get; set; }

    public string FirstName { get; set; } = null!;

    [MinLength(5)]
    public string LastName { get; set; } = null!;

    public DateTime BirthDate { get; set; }

    public virtual ICollection<Lesson> IdLessons { get; } = new List<Lesson>();
}
