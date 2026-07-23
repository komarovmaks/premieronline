using Microsoft.Playwright;

//using Microsoft.Playwright.Assertions;
 
namespace Tests.Pages;
 
public class HomePage : BasePage

{

    private const string Url = "https://www.premieronline.com/";
 
    public HomePage(IPage page) : base(page)

    {

    }
 
    private ILocator Logo =>

        Page.GetByAltText("Premiere Online");
 
    private ILocator SignIn =>

        Page.GetByRole(AriaRole.Link, new() { Name = "Sign in" });
 
    private ILocator Events =>

        Page.GetByRole(AriaRole.Link, new() { Name = "Events" });
 
    private ILocator Results =>

        Page.GetByRole(AriaRole.Link, new() { Name = "Results" });
 
    private ILocator Help =>

        Page.GetByRole(AriaRole.Link, new() { Name = "Help" });
 
    private ILocator CreateAccount =>

        Page.GetByRole(AriaRole.Button, new() { Name = "Create Account" });
 
    public async Task Open()

    {

        await Page.GotoAsync(Url);

    }
 
    public async Task VerifyHomePage()

    {

        await Expect(Page).ToHaveURLAsync(Url);
 
        await Expect(Page).ToHaveTitleAsync(

            "Premier Online - leading provider of online event registration for sports events");
 
        await Expect(Logo).ToBeVisibleAsync();
 
        await Expect(SignIn).ToBeVisibleAsync();

        await Expect(SignIn).ToBeEnabledAsync();
 
        await Expect(Events).ToBeVisibleAsync();

        await Expect(Events).ToBeEnabledAsync();
 
        await Expect(Results).ToBeVisibleAsync();

        await Expect(Results).ToBeEnabledAsync();
 
        await Expect(Help).ToBeVisibleAsync();

        await Expect(Help).ToBeEnabledAsync();

    }
 
    public async Task ClickCreateAccount()

    {

        await ClickAsync(CreateAccount);

    }

}
  