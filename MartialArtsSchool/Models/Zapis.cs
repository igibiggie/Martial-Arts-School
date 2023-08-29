using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MartialArtsSchool.Models;

public partial class Zapis
{
    public int IdLesson { get; set; }

    public int IdMemeber { get; set; }

    public virtual ICollection<Member> IdLessons { get; } = null!;

    public virtual ICollection<Member> IdMemebers { get; } = null!;
}
