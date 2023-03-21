using System;
using System.Collections.Generic;

namespace MartialArtsSchool.Models;

public partial class Lesson
{
    public int IdLesson { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public virtual ICollection<Member> IdMemebers { get; } = new List<Member>();
}
