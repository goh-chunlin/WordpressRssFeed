[![Build status](https://dev.azure.com/gohchunlin/WordpressRssFeed/_apis/build/status/WordpressRssFeed-ASP.NET%20Core-CI)](https://dev.azure.com/gohchunlin/WordpressRssFeed/_build/latest?definitionId=18)
[![NuGet Release](https://img.shields.io/nuget/v/WordpressRssFeed.svg?label=WordpressRssFeed)](https://www.nuget.org/packages/WordpressRssFeed)

## 1. About

This library is to retrieve the basic information of posts in a given Wordpress blog.

## 2. How to Use

```csharp
var blogFeeds = new Reader().RetriveBlogFeeds("<Wordpress feed URL>");
```

## 3. Release Notes

**14th Jan 2022**

- Initial release.

## 4. Feedback

Bug reports and contributions are welcome at [Project Issues](https://github.com/goh-chunlin/WordpressRssFeed/issues).