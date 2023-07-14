using System.ComponentModel.DataAnnotations;

namespace WRO.Web.Models.News;

public class ListNewsModel
{
    public Guid Id { get; set; }

    [Display(Name = "display_title")]
    public string Title { get; set; } = string.Empty;

    [Display(Name = "display_short_body")]
    public string ShortBody { get; set; } = string.Empty;

    [Display(Name = "display_last_modified")]
    public DateTime LastModified { get; set; }

    [DataType(DataType.ImageUrl)]
    public string ImagePath { get; set; } = string.Empty;
}