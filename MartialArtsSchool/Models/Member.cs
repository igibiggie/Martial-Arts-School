using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MartialArtsSchool.Models;

public partial class Member
{
    //String today = DateTime.Now.ToString("MM/dd/yyyy");
    //String todayMinus13 = DateTime.Now.AddYears(-13).ToString("MM/dd/yyyy");

    public int IdMemeber { get; set; }

    [Required, MinLength(2, ErrorMessage = "Należy wpisać minimum 2 znaki"), // błędy na ang
     MaxLength(57, ErrorMessage = "Wpisano zbyt wiele znaków"),
     RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Proszę użyć tylko liter")]
    public string FirstName { get; set; } = null!;


    [Required, MinLength(2, ErrorMessage = "Należy wpisać minimum 2 znaki"),
     MaxLength(64, ErrorMessage = "Wpisano zbyt wiele znaków"),
     RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Proszę użyć tylko liter")]
    public string LastName { get; set; } = null!;

    [DataType(DataType.Date),
    Range(typeof(DateTime), "1920-12-01T00:00:00", "2008-12-31T00:00:00",
     ErrorMessage = "Kursant powinien być urodzony pomiędzy {1} a {2}")]
    // zmienić format błędu, ale użyć tej techniki w innym kontrolerze 
    public DateTime BirthDate { get; set ;}

    public virtual ICollection<Lesson> IdLessons { get; } = new List<Lesson>();
}
