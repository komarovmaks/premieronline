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


        var createAccount = Page.Locator("a:has-text('Create Account')").Nth(0);
        await Expect(createAccount).ToBeVisibleAsync();
        await Expect(createAccount).ToBeEnabledAsync();      
                
    }

    
    [Test]
    public async Task RegisterNewUser()
{
    var register = new Pages.RegisterPage(Page);
 
    await Page.GotoAsync("https://www.premieronline.com/action/register");
 
    await register.RegisterUser(
        Utils.UserGenerator.GenerateEmail(),
        Utils.UserGenerator.GenerateFirstName(),
        Utils.UserGenerator.GenerateLastName(),
        Utils.UserGenerator.GeneratePassword()
        
    );
        Utils.LoggerHelper.Info($"Generated email: {Utils.UserGenerator.GenerateEmail()}");
        Utils.LoggerHelper.Info($"Generated first name: {Utils.UserGenerator.GenerateFirstName()}");
        Utils.LoggerHelper.Info($"Generated password: {Utils.UserGenerator.GeneratePassword()}");
}


    [Test]
    public async Task RegisterWithEmailMissingAtSign_Negative()
    {
        var register = new Pages.RegisterPage(Page);

        await Page.GotoAsync("https://www.premieronline.com/action/register");

        await register.RegisterUser(
            "invalid-email",
            "Test",
            "User",
            "Password123!");

        Assert.That(Page.Url, Is.EqualTo("https://www.premieronline.com/action/register"));
        Assert.That(await Page.Locator("#email").InputValueAsync(), Is.EqualTo("invalid-email"));
    }

    [Test]
    public async Task RegisterWithShortPassword_Negative()
    {
        var register = new Pages.RegisterPage(Page);
        var errorMessage = Page.Locator("div.uk-alert-danger > p");

        await Page.GotoAsync("https://www.premieronline.com/action/register");

        await register.RegisterUser(
            "test@mailinator.com",
            "Test",
            "User",
            "Short1");

        Assert.That(Page.Url, Is.EqualTo("https://www.premieronline.com/create_profile.php"));
        Assert.That(await errorMessage.TextContentAsync(), Does.Contain("Your password must be at least 8 characters long."));
    }

    [Test]
    public async Task RegisterWithMismatchedPasswords_Negative()
    {
        var register = new Pages.RegisterPage(Page);
        var errorMessage = Page.Locator("div.uk-alert-danger > p");

        await Page.GotoAsync("https://www.premieronline.com/action/register");

        await register.RegisterUser(
            "test@mailinator.com",
            "Test",
            "User",
            "Password!",
            "Password1234!");

        Assert.That(Page.Url, Is.EqualTo("https://www.premieronline.com/create_profile.php"));
        Assert.That(await errorMessage.TextContentAsync(), Does.Contain("Your passwords don't match."));
    }
}