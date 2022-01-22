namespace WordpressRssFeed.Modals
{
    public class BlogFeed
    {
        /// <summary>
        /// Absolute URL of the article.
        /// </summary>
        public string? Link { get; set; }

        /// <summary>
        /// Title of the article.
        /// </summary>
        public string? Title { get; set; }

        /// <summary>
        /// Full content of the article.
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// The date the article is published at.
        /// </summary>
        public DateTimeOffset PublishedAt { get; set; }

        /// <summary>
        /// Absolute URL of the thumbnail used by the article.
        /// </summary>
        public string? ThumbnailUrl { get; set; }
    }
}
