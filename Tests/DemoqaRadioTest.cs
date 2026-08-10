using Microsoft.Playwright;

 
namespace Tests.Tests;

public class DemoqaRadioTests : BaseTest
{
     
    [Test]
    public async Task ClickYesRadio()
{
    var radio = new Pages.DemoqaRadioPage(Page);
 
    await Page.GotoAsync("https://demoqa.com/radio-button");
 
    await radio.ClickYesRadio();
 
        Assert.That(Page.Url, Is.EqualTo("https://demoqa.com/radio-button"));
             
        await Expect(Page.Locator("#yesRadio")).ToBeCheckedAsync();
        
        await radio.VerifyResult("Yes");

        }

        [Test]
    public async Task ClickImpressiveRadio()
{
    var radio = new Pages.DemoqaRadioPage(Page);
 
    await Page.GotoAsync("https://demoqa.com/radio-button");
 
    await radio.ClickImpressiveRadio();
 
        Assert.That(Page.Url, Is.EqualTo("https://demoqa.com/radio-button"));
             
        await Expect(Page.Locator("#impressiveRadio")).ToBeCheckedAsync();
        
        await radio.VerifyResult("Impressive");

        }
}