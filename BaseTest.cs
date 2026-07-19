// using Microsoft.Playwright;
// using NUnit.Framework;
// namespace Tests;

// public class BaseTest
// {
//     protected IPlaywright Playwright=null!; //защита - Внутри текущего класса и его наследников
//     protected IBrowser Browser=null!; 
//         protected IBrowserContext Context = null!;
//         protected IPage Page = null!;
//     [SetUp]
//     public async Task SetUp()
//     {
        
//         Playwright= await Microsoft.Playwright.Playwright.CreateAsync();
//         Browser=await Playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
//         {
//             Headless=false
//         });
//     Context=await Browser.NewContextAsync(new BrowserNewContextOptions
//     {
//         ViewportSize=new ViewportSize
//         {
//             Width=1920, Height=1080
//         }
//     });
//     Page=await Context.NewPageAsync();
//     }
//     [TearDown]
//     public async Task TearDown()
//     {
//         await Context.CloseAsync();
//         await Browser.CloseAsync();
//         Playwright.Dispose();
//     }
// }

using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
 
namespace Tests;
 
public class BaseTest : PageTest
{
    // protected const string BaseUrl = "https://www.premieronline.com/";
 
    // public override BrowserTypeLaunchOptions BrowserTypeLaunchOptions()
    // {
    //     return new BrowserTypeLaunchOptions
    //     {
    //         Headless = false,
    //         SlowMo = 100
    //     };
    // }
 
    // public override BrowserNewContextOptions ContextOptions()
    // {
    //     return new BrowserNewContextOptions
    //     {
    //         BaseURL = BaseUrl,
    //         ViewportSize = new ViewportSize
    //         {
    //             Width = 1920,
    //             Height = 1080
    //         }
    //     };
    // }
 
    // [SetUp]
    // public async Task SetUp()
    // {
    //     await Page.GotoAsync("/");
    // }
}