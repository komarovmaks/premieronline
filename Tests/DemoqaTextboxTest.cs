using Microsoft.Playwright;

 
namespace Tests.Tests;

public class DemoqaTextboxTests : BaseTest
{
     
    [Test]
    public async Task EnterValues()
{
    var textbox = new Pages.DemoqaTextboxPage(Page);
 
    await Page.GotoAsync("https://demoqa.com/text-box");
 
    await textbox.EnterValues(
        
            "Max Test",
            "max@test.com",
            "100 Main St., Main City, FL 33555",
            "100 Main St., Main City, FL 33555");

        Assert.That(Page.Url, Is.EqualTo("https://demoqa.com/text-box"));
             
        await textbox.VerifyFullNameValue("Max Test");
        await textbox.VerifyEmailValue("max@test.com");
        await textbox.VerifyCurrentAddressValue("100 Main St., Main City, FL 33555");
        await textbox.VerifyPermanentAddressValue("100 Main St., Main City, FL 33555");

        }
}