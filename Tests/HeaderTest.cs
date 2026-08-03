using Microsoft.Playwright;
using NUnit.Framework;

 
namespace Tests.Tests;
 
public class HeaderTest : BaseTest
{
    [Test]
    public async Task VerifyHeaderElements()
    {
        var headerComponents = new Pages.HeaderComponents(Page);
        await headerComponents.Open();
        await headerComponents.VerifyHeaderComponents();
    }

    [Test]
    public async Task SearchByEventName()
    {
        var headerComponents = new Pages.HeaderComponents(Page);
        await headerComponents.Open();
        
        await headerComponents.VerifySearchVisible();
        await headerComponents.VerifySearchEnabled();
        await headerComponents.VerifyPlaceholder("Search by Event Name or Organiser");
        await headerComponents.VerifyInputType("search");

        await headerComponents.Search(Data.SearchData.ValidEvent);
        
        await headerComponents.VerifySearchValue(Data.SearchData.ValidEvent);
        await headerComponents.VerifyResultsVisible();
        var count = await headerComponents.GetResultsCount();
        Assert.That(count, Is.GreaterThan(0), "Expected at least one result for a valid event search.");
    }

    [Test]
    public async Task SearchByOrganizer()
    {
        var headerComponents = new Pages.HeaderComponents(Page);
        await headerComponents.Open();
        
        await headerComponents.Search(Data.SearchData.ValidOrganizer);
        await headerComponents.VerifyResultsVisible();
        var count = await headerComponents.GetResultsCount();
        Assert.That(count, Is.GreaterThan(0), "Expected at least one result for a valid organizer search.");
    }

    [Test]
    public async Task SearchEmpty()
    {
        var headerComponents = new Pages.HeaderComponents(Page);
        await headerComponents.Open();
        
        await headerComponents.Search(Data.SearchData.Empty);
        await headerComponents.VerifySearchValue(Data.SearchData.Empty);
    }

    [Test]
    public async Task SearchInvalid()
    {
        var headerComponents = new Pages.HeaderComponents(Page);
        await headerComponents.Open();
        
        await headerComponents.Search(Data.SearchData.InvalidSearch);
        await headerComponents.VerifyNoResults();
    }

    [Test]
    public async Task SearchNumbers()
    {
        var headerComponents = new Pages.HeaderComponents(Page);
        await headerComponents.Open();
        
        await headerComponents.Search(Data.SearchData.Numbers);
        await headerComponents.VerifyNoResults();
    }

    [Test]
    public async Task SearchWithSpecialCharacters()
    {
        var headerComponents = new Pages.HeaderComponents(Page);
        await headerComponents.Open();
        
        await headerComponents.Search(Data.SearchData.SpecialCharacters);
        await headerComponents.VerifyNoResults();
    }

    [Test]
    public async Task SearchWithLongText()
    {
        var headerComponents = new Pages.HeaderComponents(Page);
        await headerComponents.Open();
        
        await headerComponents.Search(Data.SearchData.LongText);
        await headerComponents.VerifyNoResults();
    }
}
    // public async Task VerifyHeader()
    // {
    //     await Page.GotoAsync("https://www.premieronline.com/");
    //     Assert.That(Page.Url, Is.EqualTo("https://www.premieronline.com/"));
 
              
    //     var logo = Page.Locator("img[alt='Premiere Online']");
    //     await Expect(logo).ToBeVisibleAsync();
    //     await Expect(logo).ToBeEnabledAsync();
    //     //await Expect(logo).ToHaveAttributeAsync("href", "https://www.premieronline.com");
                
        
    //     var events = Page.Locator("a:has-text('Events')").First;
    //     await Expect(events).ToBeEnabledAsync();
    //     await Expect(events).ToBeVisibleAsync();


    //     var ratings = Page.Locator("header.uk-sticky.uk-sticky-fixed > nav.uk-navbar-container.boundary-align > div.uk-navbar-left > ul.uk-navbar-nav.hidden > li:nth-child(2) > a");
    //     await Expect(ratings).ToBeEnabledAsync();
    //     await Expect(ratings).ToBeVisibleAsync();

        
    //     var help = Page.GetByRole(AriaRole.Link, new() { Name = "Help" });
    //     await Expect(help).ToBeVisibleAsync();
    //     await Expect(help).ToBeEnabledAsync();

        
    // }
