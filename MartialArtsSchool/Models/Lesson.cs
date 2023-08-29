using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MartialArtsSchool.Models;

public partial class Lesson
{
    public int IdLesson { get; set; }

    [Required, MinLength(2, ErrorMessage = "Należy wpisać minimum 2 znaki"),
     MaxLength(8, ErrorMessage = "Wpisano zbyt wiele znaków"),
     RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Proszę użyć tylko liter, bez znaków specjalnych. Proszę o podanie tylko pierwszego imienia")]
    public string Name { get; set; } = null!;

    [MinLength(20, ErrorMessage = "Należy wpisać minimum 20 znaków"),
     MaxLength(255, ErrorMessage = "Wpisano zbyt wiele znaków")]
    public string Description { get; set; } = null!;

    public virtual ICollection<Member> IdMemebers { get; } = null!;
}
