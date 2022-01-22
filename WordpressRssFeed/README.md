[![Build status](https://dev.azure.com/gohchunlin/WordpressRssFeed/_apis/build/status/WordpressRssFeed-ASP.NET%20Core-CI)](https://dev.azure.com/gohchunlin/WordpressRssFeed/_build/latest?definitionId=18)
[![NuGet Release](https://img.shields.io/nuget/v/WordpressRssFeed.svg?label=WordpressRssFeed)](https://www.nuget.org/packages/WordpressRssFeed)

## 1. About

This library is to retrieve the basic information of posts in a given Wordpress blog.

## 2. How to Use

```csharp
var blogChannel = new Reader().RetriveBlogFeeds("<Wordpress feed URL>");
```

The code above will return an object of `BlogChannel` which contains the following information.

| Property | Data Type | Description  |
|-|-|-|
| Link | string | Absolute URL of the blog. |
| Title | string | Title of the blog. |
| Description | string | Description of the blog. |
| BuiltAt | DateTimeOffSet | The last date and time this RSS feed is built at. |
| Feeds | List<BlogFeed> | A list of BlogFeed objects for the articles in the blog. |

## 3. BlogFeed

The `BlogFeed` object contains the basic information as well as the content of an article (aka post) in the blog.
Currently, it has the following properties.

| Property | Data Type | Description  |
|-|-|-|
| Link | string | Absolute URL of the article. |
| Title | string | Title of the article. |
| Description | string | Full content of the article. |
| PublishedAt | DateTimeOffSet |The date the article is published at. |
| ThumbnailUrl | string | Absolute URL of the thumbnail used by the article. |

## 4. Release Notes

**22nd Jan 2022**

- Return `BlogChannel` object instead of a list of `BlogFeed` objects so that blog info can be returned as well;
- Corrected the way of parsing the datetime in the RSS feed.

**14th Jan 2022**

- Initial release.

## 5. Feedback

Bug reports and contributions are welcome at [Project Issues](https://github.com/goh-chunlin/WordpressRssFeed/issues).