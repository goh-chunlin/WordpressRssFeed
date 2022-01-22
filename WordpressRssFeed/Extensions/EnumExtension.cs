using System.Runtime.Serialization;
using WordpressRssFeed.Enums;

namespace WordpressRssFeed.Extensions
{
    internal static class EnumExtension
    {
        public static string XmlLabel(this XmlElement element) 
        {
            return element.ToEnumMemberAttrValue();
        }
        public static string XmlLabel(this XmlAttribute attribute)
        {
            return attribute.ToEnumMemberAttrValue();
        }

        public static string ToEnumMemberAttrValue(this Enum enumValue)
        {
            var attr = enumValue.GetType().GetMember(enumValue.ToString()).FirstOrDefault()?.
                GetCustomAttributes(false).OfType<EnumMemberAttribute>().FirstOrDefault();

            if (attr == null) return enumValue.ToString();

            return attr.Value ?? enumValue.ToString();
        }
    }
}
