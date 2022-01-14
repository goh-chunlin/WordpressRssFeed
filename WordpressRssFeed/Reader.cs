using System.Globalization;
using System.Xml.Linq;
using WordpressRssFeed.Modals;

namespace WordpressRssFeed
{
    public class Reader
    {
        public List<BlogFeed> RetriveBlogFeeds(string rssFeedUrl) 
        {
            XDocument xDoc = XDocument.Load(rssFeedUrl);

            XNamespace media = "http://search.yahoo.com/mrss/";

            List<BlogFeed> blogFeeds = new List<BlogFeed>();
            foreach (XElement i in xDoc.Descendants("item")) 
            {
                var newBlogFeed = new BlogFeed
                {
                    Id = i.Element("link")?.Value,
                    Title = i.Element("title")?.Value,
                    ThumbnailUrl = i.Descendants(media + "content").Where(img => img.Attribute("url") != null && !img.Attribute("url")!.Value.Contains("gravatar.com")).FirstOrDefault()?.Attribute("url")?.Value,
                    Description = i.Element("description")?.Value
                };

                if (i.Element("pubDate") != null) 
                {
                    newBlogFeed.PublishedAt = DateTimeOffset.ParseExact(
                        i.Element("pubDate")!.Value.Replace("GMT", "+00:00"),
                        "ddd, dd MMM yyyy HH:mm:ss zzz",
                        CultureInfo.InvariantCulture);
                }

                blogFeeds.Add(newBlogFeed);
            }

            return blogFeeds;
        }
    }
}