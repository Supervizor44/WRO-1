using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace WRO.Web.Controllers.Extensions;

public static class TempDataExtensions
{
    public static void Alert(this ITempDataDictionary tempData, string message, string type, string title = "")
    {
        tempData["ToastrMessage"] = message;
        tempData["ToastrType"] = type;
        tempData["ToastrTitle"] = title;
    }

    public static void AlertSuccess(this ITempDataDictionary tempData, string message, string title = "")
    {
        tempData.Alert(message, "success", title);
    }

    public static void AlertError(this ITempDataDictionary tempData, string message, string title = "")
    {
        tempData.Alert(message, "error", title);
    }
}
