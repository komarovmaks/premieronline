using Microsoft.Playwright;


namespace Tests.Pages;
 
public abstract class BasePage: BaseTest

{

    protected new readonly IPage Page;
 
    protected BasePage(IPage page)

    {

        Page = page;

    }

    protected ILocator Password => Page.Locator("#password");
    public ILocator SignIn => Page.GetByRole(AriaRole.Link, new() { Name = "Sign in" });
 
    protected async Task ClickAsync(ILocator locator)

    {

        await Expect(locator).ToBeVisibleAsync();

        await Expect(locator).ToBeEnabledAsync();
 
        await locator.ClickAsync();

    }
 
    protected async Task FillAsync(ILocator locator, string value)

    {

        await Expect(locator).ToBeVisibleAsync();

        await Expect(locator).ToBeEnabledAsync();
 
        await locator.FillAsync(value);
 
        await Expect(locator).ToHaveValueAsync(value);

    }

}
 