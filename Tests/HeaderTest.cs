using Microsoft.Playwright;

 
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
