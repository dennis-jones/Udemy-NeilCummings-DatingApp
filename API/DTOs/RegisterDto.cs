using System.ComponentModel.DataAnnotations;

namespace API.DTOs
{
  public class RegisterDto
  {
    [Display(Name="User Name")]
    [Required(ErrorMessage = "{0}: required")]
    public string Username { get; set; }

    [Required(ErrorMessage = "{0}: required")]
    [StringLength(8, MinimumLength = 4, ErrorMessage = "{0}: must be between {2} and {1} characters long")]
    public string Password { get; set; }

    // [EmailAddress]
    // public string Email { get; set; }
  }
}

// https://dzone.com/articles/creating-your-own-validation-attribute-in-mvc-and