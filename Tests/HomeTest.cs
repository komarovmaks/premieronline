using Microsoft.Playwright;

 
namespace Tests.Tests;
 
public class HomeTests : BaseTest
{
    [Test]
    public async Task OpenHomePage()
    {
        await Page.GotoAsync("https://www.premieronline.com/");
 
        //await Expect(Page).ToHaveURLAsync("https://www.premieronline.com/");
        Assert.That(Page.Url, Is.EqualTo("https://www.premieronline.com/"));
 
        var title = await Page.TitleAsync();
        
        Assert.That(title, Is.Not.Empty);     
        
        //TestContext.WriteLine($"Title: {title}");     
        Console.WriteLine(title);
        
        Assert.That(title, Does.Contain("Premier Online - leading provider of online event registration for sports events"));
        
        //var logo = Page.Locator(".uk-logo");
        //var logo = Page.Locator("a:has(img[alt='Premiere Online'])");
        var logo = Page.Locator("img[alt='Premiere Online']");

        Assert.That(await logo.IsVisibleAsync(), Is.True);
        
        var href = await logo.GetAttributeAsync("href");
        //Assert.That(href, Is.EqualTo("https://www.premieronline.com"));

        //var signIn = Page.Locator("a:has-text('Sign in')").First;
        var signIn = Page.Locator("a:has-text('Sign in')").Nth(0);
        Assert.That(await signIn.IsVisibleAsync(), Is.True);
        Assert.That(await signIn.IsEnabledAsync(), Is.True);

        var events = Page.Locator("a:has-text('Events')").First;
        Assert.That(await events.IsEnabledAsync(), Is.True);
        Assert.That(await events.IsVisibleAsync(), Is.True);

        var ratings = Page.Locator("header.uk-sticky.uk-sticky-fixed > nav.uk-navbar-container.boundary-align > div.uk-navbar-left > ul.uk-navbar-nav.hidden > li:nth-child(2) > a");
        Assert.That(await ratings.IsEnabledAsync(), Is.True);
        Assert.That(await ratings.IsVisibleAsync(), Is.True);

        //var help = Page.Locator("a[href=\"https://www.premieronline.com/help\"]").First;
        //var help = Page.Locator("nav a").Nth(2);
        //Assert.That(await help.IsEnabledAsync(), Is.True);
        //Assert.That(await help.IsVisibleAsync(), Is.True);
        var help = Page.GetByRole(AriaRole.Link, new() { Name = "Help" });
        await Expect(help).ToBeVisibleAsync();
        await Expect(help).ToBeEnabledAsync();
        
    }

    [Test]
    public async Task CreateNewAccount()
    {
        await Page.GotoAsync("https://www.premieronline.com/");

        var createAccount = Page.Locator("a:has-text('Create Account')").First;
        await Expect(createAccount).ToBeVisibleAsync();
        await Expect(createAccount).ToBeEnabledAsync();

        await createAccount.ClickAsync();
        await Expect(Page).ToHaveURLAsync("https://www.premieronline.com/action/register");

        var emailInput = Page.Locator("#email");
        await Expect(emailInput).ToBeVisibleAsync();
        await Expect(emailInput).ToBeEnabledAsync();
        await Expect(emailInput).ToHaveAttributeAsync("placeholder", "Email: we send your confirmations and receipts here.");
        await emailInput.FillAsync("test@example.com");

        var firstName = Page.Locator("#first_name");
        await Expect(firstName).ToBeVisibleAsync();
        await Expect(firstName).ToBeEnabledAsync();
        await Expect(firstName).ToHaveAttributeAsync("placeholder", "First Name");
        await firstName.FillAsync("Max");

        var lastName = Page.Locator("#last_name");
        await Expect(lastName).ToBeVisibleAsync();
        await Expect(lastName).ToBeEnabledAsync();
        await Expect(lastName).ToHaveAttributeAsync("placeholder", "Last Name");
        await lastName.FillAsync("Test");

        var password = Page.Locator("#password");
        await Expect(password).ToBeVisibleAsync();
        await Expect(password).ToBeEnabledAsync();
        await Expect(password).ToHaveAttributeAsync("placeholder", "Password (8 characters alphanumeric)");
        await password.FillAsync("Test123!");

        var passwordRepeat = Page.Locator("#password_repeat");
        await Expect(passwordRepeat).ToBeVisibleAsync();
        await Expect(passwordRepeat).ToBeEnabledAsync();
        await Expect(passwordRepeat).ToHaveAttributeAsync("placeholder", "Repeat Password");
        await passwordRepeat.FillAsync("Test123!");

        var continueButton = Page.Locator("button[type=\"submit\"]");
        await Expect(continueButton).ToBeVisibleAsync();
        await Expect(continueButton).ToBeEnabledAsync();
        await continueButton.ClickAsync();
        await Expect(Page).ToHaveURLAsync("https://www.premieronline.com/create_profile.php");
    }
}