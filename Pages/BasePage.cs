// using Microsoft.Playwright;


// namespace Tests.Pages;
 
// public abstract class BasePage: BaseTest

// {

//     protected new readonly IPage Page;
 
//     protected BasePage(IPage page)

//     {

//         Page = page;

//     }

//     protected ILocator Password => Page.Locator("#password");
//     public ILocator SignIn => Page.GetByRole(AriaRole.Link, new() { Name = "Sign in" });
 
//     protected async Task ClickAsync(ILocator locator)

//     {

//         await Expect(locator).ToBeVisibleAsync();

//         await Expect(locator).ToBeEnabledAsync();
 
//         await locator.ClickAsync();

//     }
 
//     protected async Task FillAsync(ILocator locator, string value)

//     {

//         await Expect(locator).ToBeVisibleAsync();

//         await Expect(locator).ToBeEnabledAsync();
 
//         await locator.FillAsync(value);
 
//         await Expect(locator).ToHaveValueAsync(value);

//     }

// }
 
 using Microsoft.Playwright;

//using Microsoft.Playwright.Assertions;

using Tests.Utils;
 
namespace Tests.Pages;
 
public class BasePage

{

    protected readonly IPage Page;
 
    public BasePage(IPage page)

    {

        Page = page;

    }
 
    protected async Task ClickAsync(ILocator locator, string elementName)

    {

        try

        {

            LoggerHelper.Info($"Click: {elementName}");

            await locator.ClickAsync();

        }

        catch (Exception ex)

        {

            LoggerHelper.Error($"Failed to click '{elementName}'", ex);

            throw;

        }

    }
 
    protected async Task FillAsync(ILocator locator, string value, string fieldName)

    {

        try

        {

            LoggerHelper.Info($"Fill '{fieldName}' with '{value}'");

            await locator.FillAsync(value);

        }

        catch (Exception ex)

        {

            LoggerHelper.Error($"Failed to fill '{fieldName}'", ex);

            throw;

        }

    }
 
    public async Task NavigateAsync(string url)

    {

        try

        {

            LoggerHelper.Info($"Navigate to: {url}");

            await Page.GotoAsync(url);

        }

        catch (Exception ex)

        {

            LoggerHelper.Error($"Failed to navigate to '{url}'", ex);

            throw;

        }

    }
 
    protected async Task AssertVisibleAsync(ILocator locator, string elementName)

    {

        try

        {

            LoggerHelper.Info($"Verify '{elementName}' is visible");

            await Assertions.Expect(locator).ToBeVisibleAsync();

        }

        catch (Exception ex)

        {

            LoggerHelper.Error($"Element '{elementName}' is not visible", ex);

            throw;

        }

    }

}
 