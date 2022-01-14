namespace WordpressRssFeed.Modals
{
    public class BlogFeed
    {
        public string? Id { get; set; }

        public string? Title { get; set; }

        public string? Description { get; set; }

        public DateTimeOffset PublishedAt { get; set; }

        public string? ThumbnailUrl { get; set; }
    }
}
