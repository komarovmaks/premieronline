using Microsoft.Playwright;

 
namespace Tests.Tests;

public class HomeTests : BaseTest
{
    [Test]
    public async Task OpenHomePage()
    {
        await Page.GotoAsync("https://www.premieronline.com/");
 
        
        Assert.That(Page.Url, Is.EqualTo("https://www.premieronline.com/"));
 
        var title = await Page.TitleAsync();
        
        Assert.That(title, Is.Not.Empty);     
        Console.WriteLine(title);
        
        Assert.That(title, Does.Contain("Premier Online - leading provider of online event registration for sports events"));

       

        var homePage = new Pages.HomePage(Page);
        var signIn = homePage.SignIn;
        await Expect(signIn).ToBeVisibleAsync();
        await Expect(signIn).ToBeEnabledAsync();


        await homePage.VerifyCreateAccountVisible();
                
    }

    
    
}