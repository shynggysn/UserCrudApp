using System;

namespace CrudApp.Models;

public class AddUserDto
{
    public required string Name { get; set; }
    public required string Email { get; set; }
    public string? Phone { get; set; }
    public decimal Age { get; set; }

}
