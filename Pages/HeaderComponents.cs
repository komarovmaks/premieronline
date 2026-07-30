using Microsoft.Playwright;
 
namespace Tests.Pages;
 
public class HeaderComponents : BasePage

{

    private const string Url = "https://www.premieronline.com/";
 
    public HeaderComponents(IPage page) : base(page)

    {

    }
    //Locators
    private ILocator Logo =>

        Page.GetByAltText("Premiere Online");
 
    
    private ILocator Events =>

        Page.GetByRole(AriaRole.Link, new() { Name = "Events" });
 
    private ILocator Ratings =>

        Page.GetByRole(AriaRole.Link, new() { Name = "Ratings" });
 
    private ILocator Help =>

        Page.GetByRole(AriaRole.Link, new() { Name = "Help" });
 

    // Public actions 
    public async Task Open()
    {
        await Page.GotoAsync(Url);
    }
 
    public async Task VerifyHeaderComponents()

    {

        await Expect(Page).ToHaveURLAsync(Url);
 
        await Expect(Logo).ToBeVisibleAsync();
 
        await Expect(Events).ToBeVisibleAsync();

        await Expect(Events).ToBeEnabledAsync();
 
        await Expect(Ratings).ToBeVisibleAsync();

        await Expect(Ratings).ToBeEnabledAsync();
 
        await Expect(Help).ToBeVisibleAsync();

        await Expect(Help).ToBeEnabledAsync();

    }
 
    

}