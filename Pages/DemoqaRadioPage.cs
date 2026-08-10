using Microsoft.Playwright;
 
namespace Tests.Pages;
 
public class DemoqaRadioPage : BasePage

{

    public DemoqaRadioPage(IPage page) : base(page)

    {

    }
 
    private ILocator YesRadio => Page.Locator("#yesRadio");

    private ILocator ImpressiveRadio => Page.Locator("#impressiveRadio");

    private ILocator Message => Page.Locator("p.mt-3 > span.text-success");

    
    public async Task ClickYesRadio()

    {
        await ClickAsync(YesRadio, "Select Yes");
    }

    public async Task ClickImpressiveRadio()
    {
        await ClickAsync(ImpressiveRadio, "Select Impressive");
    }

    public async Task VerifyResult(string expectedText)
    {
        await Assertions.Expect(Message).ToHaveTextAsync(expectedText);
    }
    
}
 