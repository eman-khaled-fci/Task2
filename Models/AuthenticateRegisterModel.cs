namespace WebApi.Models;

using System.ComponentModel.DataAnnotations;

public class AuthenticateRegisterModel
{

    [Required]
    public int Id { get; set; }

    [Required]
    public string FirstName { get; set; }

    [Required]
    public string LastName { get; set; }

    [Required]
    public string Username { get; set; }

    [Required]
    public string Password { get; set; }

}
