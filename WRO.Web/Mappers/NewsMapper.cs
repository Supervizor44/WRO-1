using System.Linq.Expressions;
using WRO.Web.Data.Entities.NewsAggregate;
using WRO.Web.Models.News;
namespace WRO.Web.Mappers;

public static class NewsMapper
{
    public static Expression<Func<News, SingleNewsModel>> ProjectToSingleModel(string culture) =>
        news => new SingleNewsModel
        {
            Id = news.Id,
            Created = news.Created,
            LastModified = news.LastModified,
            Title = news.Contexts.First(c => c.Culture == culture).Title,
            Body = news.Contexts.First(c => c.Culture == culture).Body,
            ImagePath = news.Image.Path
        };

    public static Expression<Func<News, ListNewsModel>> ProjectToListModel(string culture) =>
        news => new ListNewsModel
        {
            Id = news.Id,
            LastModified = news.LastModified ?? news.Created,
            Title = news.Contexts.First(c => c.Culture == culture).Title,
            ShortBody = $"{news.Contexts.First(c => c.Culture == culture).Body.Substring(0, 300)}...",
            ImagePath = news.Image.Path
        };
}
