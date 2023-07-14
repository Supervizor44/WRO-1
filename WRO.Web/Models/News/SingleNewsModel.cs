using System.ComponentModel.DataAnnotations;

namespace WRO.Web.Models.News;

public class SingleNewsModel
{
    public Guid Id { get; set; }

    [Display(Name = "display_title")]
    public string Title { get; set; } = string.Empty;

    [Display(Name = "display_body")]
    public string Body { get; set; } = string.Empty;

    [Display(Name = "display_created")]
    public DateTime Created { get; set; }

    [Display(Name = "display_last_modified")]
    public DateTime? LastModified { get; set; }

    [DataType(DataType.ImageUrl)]
    public string ImagePath { get; set; } = string.Empty;
}
