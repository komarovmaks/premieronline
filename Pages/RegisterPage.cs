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
 
    
        public async Task ClickContinue()

    {

        await ClickAsync(ContinueButton);

    }

    public async Task RegisterUser(

        string email,

        string firstName,

        string lastName,

        string password)

    {

        await FillAsync(Email, email);

        await FillAsync(FirstName, firstName);

        await FillAsync(LastName, lastName);

        await FillAsync(Password, password);

        await FillAsync(RepeatPassword, password);
 
        await ClickAsync(ContinueButton);

    }
 
//  [Test]

//  await register.RegisterUser(
//         $"test{Guid.NewGuid():N}@mailinator.com",
//         "Max",
//         "Test",
//         "Test123!"
//     );
}
 