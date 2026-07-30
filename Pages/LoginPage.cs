using Microsoft.Playwright;

namespace Tests.Pages;

public class LoginPage : BasePage
{
    private const string Url = "https://www.premieronline.com/action/login.php";

    public LoginPage(IPage page) : base(page)
    {
    }

    // Locators
    private ILocator Email => Page.Locator("#login_name");

    // Password locator is inherited from BasePage (#password)

    private ILocator TogglePassword => Page.Locator("#togglePassword");

    private ILocator EyeIcon => Page.Locator("#eyeIcon");

    private ILocator SignInButton =>
        Page.GetByRole(AriaRole.Button, new() { Name = "Sign in" });

    private ILocator ForgotPasswordLink =>
        Page.GetByRole(AriaRole.Link, new() { Name = "Forgot your password?" });

    private ILocator CreateAccountLink =>
        Page.GetByRole(AriaRole.Link, new() { Name = "Create Account" });

    private ILocator RegisterAsGuestLink =>
        Page.GetByRole(AriaRole.Link, new() { Name = "Register as a Guest" });

    // Public actions
    public async Task Open()
    {
        await Page.GotoAsync(Url);
    }

    public async Task LoginUser(string email, string password)
    {
        await FillAsync(Email, email);
        await FillAsync(Password, password);
        await ClickAsync(SignInButton);
    }

    public async Task FillEmail(string email)
    {
        await FillAsync(Email, email);
    }

    public async Task FillPassword(string password)
    {
        await FillAsync(Password, password);
    }

    public async Task ClickSignIn()
    {
        await ClickAsync(SignInButton);
    }

    public async Task TogglePasswordVisibility()
    {
        await ClickAsync(TogglePassword);
    }

    public async Task ClickForgotPassword()
    {
        await ClickAsync(ForgotPasswordLink);
    }

    public async Task ClickCreateAccount()
    {
        await ClickAsync(CreateAccountLink);
    }

    public async Task ClickRegisterAsGuest()
    {
        await ClickAsync(RegisterAsGuestLink);
    }

    public async Task VerifyLoginPage()
    {
        await Expect(Email).ToBeVisibleAsync();
        await Expect(Password).ToBeVisibleAsync();
        await Expect(SignInButton).ToBeVisibleAsync();
        await Expect(ForgotPasswordLink).ToBeVisibleAsync();
        await Expect(CreateAccountLink).ToBeVisibleAsync();
        await Expect(RegisterAsGuestLink).ToBeVisibleAsync();
    }
}
