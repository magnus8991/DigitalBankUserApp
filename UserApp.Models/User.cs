using System;

namespace UserApp.Models;

public class User
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public DateTime BirthDate { get; set; }
    public char Gender { get; set; }
}