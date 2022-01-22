using NUnit.Framework;
using System;
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
        public void TestChannelInfo()
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
            var blogChannel = new Reader().RetriveBlogFeeds(blogRssFeedUrl);

            // Assert
            Assert.AreEqual("https://cuteprogramming.wordpress.com", blogChannel.Link);
            Assert.AreEqual("cuteprogramming", blogChannel.Title);
            Assert.AreEqual("Programming can be cute.", blogChannel.Description);
            Assert.AreEqual(new DateTimeOffset(2022, 1, 9, 3, 56, 30, new TimeSpan(0)), blogChannel.BuiltAt);
        }

        [Test]
        public void TestFeedCount()
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
            var blogChannel = new Reader().RetriveBlogFeeds(blogRssFeedUrl);

            // Assert
            Assert.AreEqual(10, blogChannel.Feeds.Count);
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