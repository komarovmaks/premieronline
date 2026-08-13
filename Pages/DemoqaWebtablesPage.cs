using Microsoft.Playwright;
using Tests.Utils;
 
namespace Tests.Pages;
 
public class DemoqaWebtablesPage : BasePage

{

    public DemoqaWebtablesPage(IPage page) : base(page)

    {

    }
 
    private ILocator AddButton => Page.Locator("#addNewRecordButton");
    
    private ILocator FirstName => Page.Locator("#firstName");

    private ILocator LastName => Page.Locator("#lastName");

    private ILocator Email => Page.Locator("#userEmail");

    private ILocator Age => Page.Locator("#age");

    private ILocator Salary => Page.Locator("#salary");

    private ILocator Department => Page.Locator("#department");

    private ILocator SubmitButton => Page.Locator("#submit");
 
    private ILocator EditRecord1 => Page.Locator("#edit-record-1 > svg");

    private ILocator DeleteRecord1 => Page.Locator("#delete-record-1 > svg");


    private ILocator SearchBox => Page.Locator("#searchBox");

    public async Task ClickAddButton()
    {
        await ClickAsync(AddButton, "Add");
    }

    public async Task AddRecord(
        string firstName,
        string lastName,
        string email,
        string age,
        string salary,
        string department)
    {
        await FillAsync(FirstName, firstName, "First Name");
        await FillAsync(LastName, lastName, "Last Name");
        await FillAsync(Email, email, "Email");
        await FillAsync(Age, age, "Age");
        await FillAsync(Salary, salary, "Salary");
        await FillAsync(Department, department, "Department");
        await ClickAsync(SubmitButton, "Submit");
    }

    public ILocator GetRowByText(string text)
    {
        return Page.GetByRole(AriaRole.Row).Filter(new() { HasText = text });
    }

    public async Task SearchRecord(string text)
    {
        await FillAsync(SearchBox, text, "Search Box");
    }

    public async Task ClickEditRecord(string text)
    {
        var row = GetRowByText(text);
        await ClickAsync(row.Locator("[id^='edit-record-']"), "Edit button");
    }

    public async Task EditFirstName(string newFirstName)
    {
        await FillAsync(FirstName, newFirstName, "First Name");
        await ClickAsync(SubmitButton, "Submit");
    }

    public async Task ClickDeleteRecord(string text)
    {
        var row = GetRowByText(text);
        await ClickAsync(row.Locator("[id^='delete-record-']"), "Delete button");
    }

    public async Task VerifyRecordVisible(string text)
    {
        await AssertVisibleAsync(GetRowByText(text), $"Row with text '{text}'");
    }

    public async Task VerifyRecordHidden(string text)
    {
        try
        {
            LoggerHelper.Info($"Verify row with text '{text}' is hidden");
            await Assertions.Expect(GetRowByText(text)).ToBeHiddenAsync();
        }
        catch (Exception ex)
        {
            LoggerHelper.Error($"Element row with text '{text}' is not hidden", ex);
            throw;
        }
    }
}