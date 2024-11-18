using System;

namespace CrudApp.Models;

public class UpdateUserDto
{
    public required string Name { get; set; }
    public required string Email { get; set; }
    public string? Phone { get; set; }
    public decimal Age { get; set; }
}
