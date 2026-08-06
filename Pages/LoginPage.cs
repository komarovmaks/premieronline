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
        await FillAsync(Email, email, "Email field");
        await FillAsync(TogglePassword, password, "Password field");
        await ClickAsync(SignInButton, "Sign in button");
    }

    public async Task FillEmail(string email)
    {
        await FillAsync(Email, email, "Email field");
    }

    public async Task FillPassword(string password)
    {
        await FillAsync(TogglePassword, password, "Password field");
    }

    public async Task ClickSignIn()
    {
        await ClickAsync(SignInButton, "Sign in button");
    }

    public async Task TogglePasswordVisibility()
    {
        await ClickAsync(TogglePassword, "Toggle password visibility button");
    }

    public async Task ClickForgotPassword()
    {
        await ClickAsync(ForgotPasswordLink, "Forgot your password? link");
    }

    public async Task ClickCreateAccount()
    {
        await ClickAsync(CreateAccountLink, "Create Account link");
    }

    public async Task ClickRegisterAsGuest()
    {
        await ClickAsync(RegisterAsGuestLink, "Register as a Guest link");
    }

    public async Task VerifyLoginPage()
    {
        await Assertions.Expect(Email).ToBeVisibleAsync();
        await Assertions.Expect(TogglePassword).ToBeVisibleAsync();
        await Assertions.Expect(SignInButton).ToBeVisibleAsync();
        await Assertions.Expect(ForgotPasswordLink).ToBeVisibleAsync();
        await Assertions.Expect(CreateAccountLink).ToBeVisibleAsync();
        await Assertions.Expect(RegisterAsGuestLink).ToBeVisibleAsync();
    }
}
