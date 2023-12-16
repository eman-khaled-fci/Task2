namespace WebApi.Models;

using System.ComponentModel.DataAnnotations;

public class AuthenticateLoginModel
{
    [Required]
    public string Username { get; set; }

    [Required]
    public string Password { get; set; }
}
