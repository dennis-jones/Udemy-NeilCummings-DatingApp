using System;
using System.ComponentModel.DataAnnotations;

namespace API.DTOs
{
  public class RegisterDto
  {
    [Display(Name="User Name")]
    [Required(ErrorMessage = "{0}: required")] public string Username { get; set; }
    
    [Required(ErrorMessage = "{0}: required")] public string KnownAs { get; set; }
    [Required(ErrorMessage = "{0}: required")] public string Gender { get; set; }
    [Required(ErrorMessage = "{0}: required")] public DateTime DateOfBirth { get; set; }
    [Required(ErrorMessage = "{0}: required")] public string City { get; set; }
    [Required(ErrorMessage = "{0}: required")] public string Country { get; set; }

    [StringLength(8, MinimumLength = 4, ErrorMessage = "{0}: must be between {2} and {1} characters long")]
    [Required(ErrorMessage = "{0}: required")] public string Password { get; set; }

  }
}

// https://dzone.com/articles/creating-your-own-validation-attribute-in-mvc-and