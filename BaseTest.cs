using Microsoft.Playwright;
using NUnit.Framework;
 
namespace Tests;
 
public class BaseTest
{
    protected IPlaywright Playwright = null!;
    protected IBrowser Browser = null!;
    protected IBrowserContext Context = null!;
    protected IPage Page = null!;
 
    [SetUp]
    public async Task SetUp()
    {
        Playwright = await Microsoft.Playwright.Playwright.CreateAsync();
 
        Browser = await Playwright.Chromium.LaunchAsync(
            new BrowserTypeLaunchOptions
            {
                Headless = false,      
                SlowMo = 200         
            });
 
        Context = await Browser.NewContextAsync(
            new BrowserNewContextOptions
            {
                ViewportSize = new ViewportSize
                {
                    Width = 1920,
                    Height = 1080
                }
            });
 
        Page = await Context.NewPageAsync();
    }
 
    [TearDown]
    public async Task TearDown()
    {
        await Context.CloseAsync();
        await Browser.CloseAsync();
        Playwright.Dispose();
    }
 
    protected static ILocatorAssertions Expect(ILocator locator) =>
        Assertions.Expect(locator);
 
    protected static IPageAssertions Expect(IPage page) =>
        Assertions.Expect(page);
}