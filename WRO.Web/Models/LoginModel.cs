using System.ComponentModel.DataAnnotations;

namespace WRO.Web.Models;

public class LoginModel
{
    [Display(Name = "display_email")]
    [Required(ErrorMessage = "required")]
    [EmailAddress(ErrorMessage = "email_address")]
    public string Email { get; set; } = string.Empty;

    [Display(Name = "display_password")]
    [Required(ErrorMessage = "required")]
    [DataType(DataType.Password)]
    public string Password { get; set; } = string.Empty;

    [Display(Name = "display_remember_me")]
    public bool RememberMe { get; set; }
}
