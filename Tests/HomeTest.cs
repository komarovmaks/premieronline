using NUnit.Framework;
 
namespace Tests.Tests;
 
public class HomeTests : BaseTest
{
    [Test]
    public async Task OpenHomePage()
    {
        await Page.GotoAsync("https://www.premieronline.com/");
 
        //await Expect(Page).ToHaveURLAsync("https://www.premieronline.com/");
        Assert.That(Page.Url, Is.EqualTo("https://www.premieronline.com/"));
 
        var title = await Page.TitleAsync();
        
        Assert.That(title, Is.Not.Empty);     
        
        //TestContext.WriteLine($"Title: {title}");     
        Console.WriteLine(title);
        
        Assert.That(title, Does.Contain("Premier Online - leading provider of online event registration for sports events"));
        
        //var logo = Page.Locator(".uk-logo");
        //var logo = Page.Locator("a:has(img[alt='Premiere Online'])");
        var logo = Page.Locator("img[alt='Premiere Online']");

        Assert.That(await logo.IsVisibleAsync(), Is.True);
        
        var href = await logo.GetAttributeAsync("href");
        //Assert.That(href, Is.EqualTo("https://www.premieronline.com"));

        //var signIn = Page.Locator("a:has-text('Sign in')").First;
        var signIn = Page.Locator("a:has-text('Sign in')").Nth(0);
        Assert.That(await signIn.IsVisibleAsync(), Is.True);
        Assert.That(await signIn.IsEnabledAsync(), Is.True);

        var events = Page.Locator("a:has-text('Events')").First;
        Assert.That(await events.IsEnabledAsync(), Is.True);
        Assert.That(await events.IsVisibleAsync(), Is.True);

        var ratings = Page.Locator("header.uk-sticky.uk-sticky-fixed > nav.uk-navbar-container.boundary-align > div.uk-navbar-left > ul.uk-navbar-nav.hidden > li:nth-child(2) > a");
        Assert.That(await ratings.IsEnabledAsync(), Is.True);
        Assert.That(await ratings.IsVisibleAsync(), Is.True);

        var help = Page.Locator("a[href=\"https://www.premieronline.com/help\"]").First;
        //var help = Page.Locator("nav a").Nth(2);
        Assert.That(await help.IsEnabledAsync(), Is.True);
        Assert.That(await help.IsVisibleAsync(), Is.True);
    }
}