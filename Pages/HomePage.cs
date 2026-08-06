using Microsoft.Playwright;
 
namespace Tests.Pages;
 
public class HomePage : BasePage

{

    private const string Url = "https://www.premieronline.com/";
 
    public HomePage(IPage page) : base(page)

    {

    }
 

    public ILocator SignIn => 
        Page.GetByRole(AriaRole.Link, new() { Name = "Sign in" });
    // private ILocator Events =>

    //     Page.GetByRole(AriaRole.Link, new() { Name = "Events" });
 
    // private ILocator Ratings =>

    //     Page.GetByRole(AriaRole.Link, new() { Name = "Ratings" });
 
    // private ILocator Help =>

    //     Page.GetByRole(AriaRole.Link, new() { Name = "Help" });
 
    private ILocator CreateAccount =>

        Page.GetByRole(AriaRole.Button, new() { Name = "Create Account" });
 
    public async Task Open()

    {

        await Page.GotoAsync(Url);

    }
 
    public async Task VerifyHomePage()
    {
        await Assertions.Expect(Page).ToHaveURLAsync(Url);
 
        await Assertions.Expect(Page).ToHaveTitleAsync(
            "Premier Online - leading provider of online event registration for sports events");
 
        await AssertVisibleAsync(SignIn, "Sign In link");
        await Assertions.Expect(SignIn).ToBeEnabledAsync();
        // await Expect(Events).ToBeVisibleAsync();

        // await Expect(Events).ToBeEnabledAsync();
 
        // await Expect(Ratings).ToBeVisibleAsync();

        // await Expect(Ratings).ToBeEnabledAsync();
 
        // await Expect(Help).ToBeVisibleAsync();

        // await Expect(Help).ToBeEnabledAsync();

    }
 
    public async Task VerifyCreateAccountVisible()
    {
        await AssertVisibleAsync(CreateAccount, "Create Account button");
        await Assertions.Expect(CreateAccount).ToBeEnabledAsync();
    }

    public async Task ClickCreateAccount()
    {
        await ClickAsync(CreateAccount, "Create Account button");
    }

}
  