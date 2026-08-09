using Microsoft.Playwright;
 
namespace Tests.Pages;
 
public class DemoqaCheckboxPage : BasePage

{

    public DemoqaCheckboxPage(IPage page) : base(page)

    {

    }
 
    private ILocator Checkbox => Page.GetByLabel("Select Home");

    private ILocator Message => Page.Locator("#result");

    
    public async Task ClickCheckbox()

    {
        await ClickAsync(Checkbox, "Select Home");
    }

    
    public async Task VerifyResult(string expectedText)
    {
        await Assertions.Expect(Message).ToHaveTextAsync(expectedText);
    }
    
}
 