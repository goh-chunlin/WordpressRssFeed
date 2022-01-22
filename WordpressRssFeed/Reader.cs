using System.Globalization;
using System.Xml.Linq;
using WordpressRssFeed.Enums;
using WordpressRssFeed.Extensions;
using WordpressRssFeed.Modals;

namespace WordpressRssFeed
{
    public class Reader
    {
        string rssDateTimeFormat = "ddd, dd MMM yyyy HH:mm:ss zzz";

        public BlogChannel RetriveBlogFeeds(string rssFeedUrl) 
        {
            XDocument xDoc = XDocument.Load(rssFeedUrl);

            XNamespace media = "http://search.yahoo.com/mrss/";

            var channel = new BlogChannel();

            var channelElement = xDoc.Descendants(XmlElement.Channel.XmlLabel()).FirstOrDefault();

            if (channelElement != null)
            {
                channel.Link = channelElement.Element(XmlElement.Link.XmlLabel())?.Value;
                channel.Title = channelElement.Element(XmlElement.Title.XmlLabel())?.Value;
                channel.Description = channelElement.Element(XmlElement.Description.XmlLabel())?.Value;

                if (channelElement.Element(XmlElement.BuiltAt.XmlLabel()) != null)
                {
                    channel.BuiltAt = DateTimeOffset.ParseExact(channelElement.Element(XmlElement.BuiltAt.XmlLabel())!.Value,
                        rssDateTimeFormat, CultureInfo.InvariantCulture, DateTimeStyles.None);
                }
            }

            foreach (XElement i in xDoc.Descendants(XmlElement.Item.XmlLabel())) 
            {
                var newBlogFeed = new BlogFeed
                {
                    Link = i.Element(XmlElement.Link.XmlLabel())?.Value,
                    Title = i.Element(XmlElement.Title.XmlLabel())?.Value,
                    ThumbnailUrl = i.Descendants(media + XmlElement.Content.XmlLabel()).Where(img => img.Attribute(XmlAttribute.Url.XmlLabel()) != null && !img.Attribute(XmlAttribute.Url.XmlLabel())!.Value.Contains("gravatar.com")).FirstOrDefault()?.Attribute(XmlAttribute.Url.XmlLabel())?.Value,
                    Description = i.Element(XmlElement.Description.XmlLabel())?.Value
                };

                if (i.Element(XmlElement.PublishedAt.XmlLabel()) != null) 
                {
                    newBlogFeed.PublishedAt = DateTimeOffset.ParseExact(i.Element(XmlElement.PublishedAt.XmlLabel())!.Value,
                        rssDateTimeFormat, CultureInfo.InvariantCulture, DateTimeStyles.None);
                }

                channel.Feeds.Add(newBlogFeed);
            }

            return channel;
        }
    }
}