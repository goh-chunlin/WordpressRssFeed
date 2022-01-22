using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordpressRssFeed.Modals
{
    public class BlogChannel
    {
        /// <summary>
        /// Absolute URL of the blog.
        /// </summary>
        public string? Link { get; set; }

        /// <summary>
        /// Title of the blog.
        /// </summary>
        public string? Title { get; set; }

        /// <summary>
        /// Description of the blog.
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// The last date and time this RSS feed is built at.
        /// </summary>
        public DateTimeOffset BuiltAt { get; set; }

        /// <summary>
        /// A list of BlogFeed objects for the articles in the blog.
        /// </summary>
        public List<BlogFeed> Feeds { get; set; } = new List<BlogFeed>();
    }
}
