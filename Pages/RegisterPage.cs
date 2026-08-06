using Microsoft.Playwright;

//using Microsoft.Playwright.Assertions;
 
namespace Tests.Pages;
 
public class RegisterPage : BasePage

{

    public RegisterPage(IPage page) : base(page)

    {

    }
 
    private ILocator Email => Page.Locator("#email");

    private ILocator FirstName => Page.Locator("#first_name");

    private ILocator LastName => Page.Locator("#last_name");

    private ILocator Password => Page.Locator("#password");

    private ILocator RepeatPassword => Page.Locator("#password_repeat");
 
    private ILocator ContinueButton =>
        Page.Locator("button[type='submit']");
 
    private ILocator ErrorMessage => 
        Page.Locator("div.uk-alert-danger > p");

    public async Task ClickContinue()

    {

        await ClickAsync(ContinueButton, "Continue button");

    }

    public async Task RegisterUser(

        string email,

        string firstName,

        string lastName,

        string password,

        string? repeatPassword = null)

    {

        await FillAsync(Email, email, "Email field");

        await FillAsync(FirstName, firstName, "First name field");

        await FillAsync(LastName, lastName, "Last name field");

        await FillAsync(Password, password, "Password field");

        await FillAsync(RepeatPassword, repeatPassword ?? password, "Repeat password field");
 
        await ClickAsync(ContinueButton, "Continue button");

    }
 
//  [Test]

//  await register.RegisterUser(
//         $"test{Guid.NewGuid():N}@mailinator.com",
//         "Max",
//         "Test",
//         "Test123!"
//     );

    public async Task VerifyEmailValue(string expectedEmail)
    {
        await Assertions.Expect(Email).ToHaveValueAsync(expectedEmail);
    }

    public async Task VerifyErrorMessageContains(string expectedMessage)
    {
        await AssertVisibleAsync(ErrorMessage, "Error message");
        await Assertions.Expect(ErrorMessage).ToContainTextAsync(expectedMessage);
    }
}
 