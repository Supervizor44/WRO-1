using System.Linq.Expressions;
using WRO.Web.Areas.Admin.Models.ContactUs;
using WRO.Web.Data.Entities;

namespace WRO.Web.Areas.Admin.Mappers;

public static class ContactUsMapper
{
    public static readonly Expression<Func<ContactUs, ContactUsModel>> ProjectToModel =
        contactus => new ContactUsModel
        {
            PhoneNumber = contactus.PhoneNumber,
            Facebooklink = contactus.FacebookLink,
            Instagramlink = contactus.InstagramLink

        };

    public static void MapToContactUs(this ContactUsModel model, ContactUs contactUs)
    {
        contactUs.PhoneNumber = model.PhoneNumber;
        
        contactUs.FacebookLink = model.Facebooklink;

        contactUs.InstagramLink = model.Instagramlink;  
    }
}
