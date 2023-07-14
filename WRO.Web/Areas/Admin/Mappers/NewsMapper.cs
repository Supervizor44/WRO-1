using System.Linq.Expressions;
using WRO.Web.Areas.Admin.Models.News;
using WRO.Web.Data.Entities.NewsAggregate;

namespace WRO.Web.Areas.Admin.Mappers;

public static class NewsMapper
{
    public static Expression<Func<News, UpsertNewsModel>> ProjectToUpsertModel(string culture) =>
        news => new UpsertNewsModel
        {
            Title = news.Contexts.First(c => c.Culture == culture).Title,
            Body = news.Contexts.First(c => c.Culture == culture).Body
        };
}
