using System.ComponentModel.DataAnnotations;

namespace WRO.Web.Areas.Admin.Models.ContactUs
{
    public class ContactUsModel
    {
        // [Display(Name = "display_phone_number")]
        [Required(ErrorMessage = "required")]
        [Phone(ErrorMessage = "phone_number")]
        public string PhoneNumber { get; set; } = string.Empty;

        // [Display(Name = "display_facebook_link")]
        [Required(ErrorMessage = "required")]
        public string Facebooklink { get; set; } = string.Empty;

        // [Display(Name = "display_instagram_link")]
        [Required(ErrorMessage = "required")]
        public string Instagramlink { get; set; } = string.Empty.ToString();
    }
}
