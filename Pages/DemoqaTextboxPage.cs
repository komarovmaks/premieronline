using Microsoft.Playwright;
 
namespace Tests.Pages;
 
public class DemoqaTextboxPage : BasePage

{

    public DemoqaTextboxPage(IPage page) : base(page)

    {

    }
 
    private ILocator FullName => Page.Locator("#userName");

    private ILocator Email => Page.Locator("#userEmail");

    private ILocator CurrentAddress => Page.Locator("#currentAddress");

    private ILocator PermanentAddress => Page.Locator("#permanentAddress");
 
    private ILocator SubmitButton => Page.Locator("#submit");
 
    private ILocator CompletedName => Page.Locator("#name");

    private ILocator CompletedEmail => Page.Locator("#email");

    private ILocator CompletedCurrentAddress => Page.Locator("#currentAddress");

    private ILocator CompletedPermanentAddress => Page.Locator("#permanentAddress");


    public async Task ClickSubmit()

    {

        await ClickAsync(SubmitButton, "Submit");

    }

    public async Task EnterValues(

        string fullName,

        string email,

        string currentAddress,

        string permanentAddress)

    {
        await FillAsync(FullName, fullName, "Max Test");
        
        await FillAsync(Email, email, "max@test.com");

        await FillAsync(CurrentAddress, currentAddress, "100 Main St., Miami, FL 33555");

        await FillAsync(PermanentAddress, permanentAddress, "100 Main St., Miami, FL 33555");
 
        await ClickAsync(SubmitButton, "Submit");

    }
 


    public async Task VerifyFullNameValue(string expectedName)
    {
        await Assertions.Expect(FullName).ToHaveValueAsync(expectedName);
    }

    public async Task VerifyEmailValue(string expectedEmail)
    {
        await Assertions.Expect(Email).ToHaveValueAsync(expectedEmail);
    }

    public async Task VerifyCurrentAddressValue(string expectedAddress)
    {
        await Assertions.Expect(CurrentAddress).ToHaveValueAsync(expectedAddress);
    }

    public async Task VerifyPermanentAddressValue(string expectedAddress)
    {
        await Assertions.Expect(PermanentAddress).ToHaveValueAsync(expectedAddress);
    }

}
 