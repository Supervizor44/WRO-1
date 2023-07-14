using Microsoft.Extensions.Localization;
using OfficeOpenXml;
using OfficeOpenXml.Table;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace WRO.Web.Helpers;

public static class ExcelHelper
{
    static ExcelHelper()
    {
        ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
    }

    public const string ExcelMimeType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";

    public static byte[] SaveAsBytes<T>(IEnumerable<T> collection)
    {
        using ExcelPackage package = new();

        ExcelWorksheet workSheet = package.Workbook.Worksheets.Add("Main");
        ExcelRange cell;

        workSheet.Cells.Style.Numberformat.Format = "dd.mm.yyyy hh:mm:ss";

        cell = workSheet.Cells["A1"];
        cell.LoadFromCollection(collection, PrintHeaders: true, TableStyles.Light14).AutoFitColumns();

        return package.GetAsByteArray();
    }

    public static byte[] SaveAsBytes<T>(IEnumerable<T> collection, IStringLocalizer<Lang> localizer)
    {
        IEnumerable<IDictionary<string, object>> _ = LocalizeProperties(collection, localizer);
        return SaveAsBytes(_);
    }

    private static IEnumerable<IDictionary<string, object>> LocalizeProperties<T>(IEnumerable<T> collection,
        IStringLocalizer<Lang> localizer)
    {
        List<Dictionary<string, object>> output = new();

        var props = typeof(T).GetProperties();

        foreach (T item in collection)
        {
            Dictionary<string, object> dic = new();

            foreach (var prop in props)
            {
                var attr = prop.GetCustomAttribute<DisplayAttribute>();

                if (attr is not null && attr.Name is not null)
                {
                    dic[localizer[attr.Name]] = prop.GetValue(item)!;
                }
            }
            output.Add(dic);
        }
        return output;
    }
}

