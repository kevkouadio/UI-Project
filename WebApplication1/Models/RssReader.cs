using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Xml;
namespace WebApplication1.Models
{
    public static class RssReader
    {
            public static IEnumerable<RssFeed> GetFeed()

            {
                string RSSURL = "https://www.theverge.com/rss/front-page/index.xml";

            List<RssFeed> feeds = new List<RssFeed>();
            XmlTextReader reader = new XmlTextReader(RSSURL);
            SyndicationFeed feed = SyndicationFeed.Load(reader);


            if (feed != null)
            {
                feeds.AddRange(feed.Items.Select(i => new RssFeed
                {
                    Title = i.Title.Text,
                    Published = i.PublishDate.DateTime.ToUniversalTime().ToString(CultureInfo.InvariantCulture),
                    ImageURL = ((TextSyndicationContent)i.Content).Text,
                    DescriptionMarkup = ((TextSyndicationContent)i.Content).Text,
                    Author = i.Authors.FirstOrDefault().Name,
                }));
            }
            return feeds;
        }
    }

        
}
