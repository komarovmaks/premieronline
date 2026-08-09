using Microsoft.Playwright;

 
namespace Tests.Tests;

public class DemoqaCheckboxTests : BaseTest
{
     
    [Test]
    public async Task ClickCheckbox()
{
    var checkbox = new Pages.DemoqaCheckboxPage(Page);
 
    await Page.GotoAsync("https://demoqa.com/checkbox");
 
    await checkbox.ClickCheckbox();
 
        Assert.That(Page.Url, Is.EqualTo("https://demoqa.com/checkbox"));
             
        await checkbox.VerifyResult("You have selected :");


        }
}