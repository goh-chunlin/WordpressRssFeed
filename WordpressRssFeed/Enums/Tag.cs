using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WordpressRssFeed.Enums
{
    public enum XmlElement
    {
        [EnumMember(Value = "channel"      )] Channel,
        [EnumMember(Value = "item"         )] Item,
        [EnumMember(Value = "link"         )] Link,
        [EnumMember(Value = "title"        )] Title,
        [EnumMember(Value = "content"      )] Content,
        [EnumMember(Value = "description"  )] Description,
        [EnumMember(Value = "pubDate"      )] PublishedAt,
        [EnumMember(Value = "lastBuildDate")] BuiltAt,
    }

    public enum XmlAttribute
    {
        [EnumMember(Value = "url")] Url,
    }
}
