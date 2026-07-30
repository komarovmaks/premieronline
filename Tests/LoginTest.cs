using Microsoft.Playwright;
using NUnit.Framework;
using Tests.Data;
using Tests.Pages;

namespace Tests.Tests;

public class LoginTests : BaseTest
{
    private AuthData _authData = null!;

    [SetUp]
    public void LoadTestData()
    {
        _authData = AuthData.LoadFromFile();
    }

    [Test]
    public async Task VerifyLoginPageElements()
    {
        var loginPage = new LoginPage(Page);
        await loginPage.Open();
        await loginPage.VerifyLoginPage();
    }

    [Test]
    public async Task LoginWithSavedCredentials()
    {
        var loginPage = new LoginPage(Page);
        await loginPage.Open();
        await loginPage.LoginUser(_authData.Email, _authData.Password);
    }

    [Test]
    public async Task TogglePasswordVisibilityTest()
    {
        var loginPage = new LoginPage(Page);
        await loginPage.Open();
        await loginPage.FillPassword(_authData.Password);
        await loginPage.TogglePasswordVisibility();
    }
}
