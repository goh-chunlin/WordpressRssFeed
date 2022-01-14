using NUnit.Framework;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;
using WireMock.Server;

namespace WordpressRssFeed.Test
{
    public class Tests
    {
        /// <summary>
        /// The _stub server
        /// </summary>
        private WireMockServer _stubServer;
        

        [SetUp]
        public void Setup()
        {
            _stubServer = WireMockServer.Start();
        }

        [Test]
        public void Test1()
        {
            // Arrange
            _stubServer.Given(
                Request.Create().WithPath("/valid-blog-feeds").UsingGet())
                .RespondWith(Response.Create()
                    .WithStatusCode(200)
                    .WithHeader("Content-Type", "application/xml")
                    .WithBodyFromFile("SupportingDocuments/cuteprogramming.wordpress.com.xml"));

            string blogRssFeedUrl = $"http://localhost:{_stubServer.Ports[0]}/valid-blog-feeds";

            // Act
            var blogFeeds = new Reader().RetriveBlogFeeds(blogRssFeedUrl);

            // Assert
            Assert.AreEqual(10, blogFeeds.Count);
        }

        [TearDown]
        public void TearDown() 
        {
            try
            {
                _stubServer.Stop();
            }
            catch { }
        }
    }
}