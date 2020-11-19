using System.ComponentModel.DataAnnotations;

namespace API.DTOs
{
  public class RegisterDto
  {
    [Required(ErrorMessage = "{0}: Required")]
    public string Username { get; set; }

    [Display(Name="PW")]
    [MinLength(6, ErrorMessage = "{0}: must be at least {1} characters long.")]
    public string Password { get; set; }

    // [EmailAddress]
    // public string Email { get; set; }
  }
}

// https://dzone.com/articles/creating-your-own-validation-attribute-in-mvc-and