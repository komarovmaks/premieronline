using Microsoft.Playwright;

 
namespace Tests.Tests;

public class DemoqaWebtablesTests : BaseTest
{
     
    [Test]
    public async Task AddNewRecord()
    {
        var webtables = new Pages.DemoqaWebtablesPage(Page);
        await webtables.NavigateAsync("https://demoqa.com/webtables");

        var random = new Random();
        string firstName = "Test" + random.Next(1000, 9999);
        string lastName = "User" + random.Next(1000, 9999);
        string email = $"test{random.Next(1000, 9999)}@test.com";
        
        await webtables.ClickAddButton();
        await webtables.AddRecord(firstName, lastName, email, "30", "50000", "IT");
        
        await webtables.VerifyRecordVisible(firstName);
    }

    [Test]
    public async Task EditRecord()
    {
        var webtables = new Pages.DemoqaWebtablesPage(Page);
        await webtables.NavigateAsync("https://demoqa.com/webtables");

        string originalName = "Alden"; // Default record on the page
        string editedName = "AldenEdited";

        await webtables.ClickEditRecord(originalName);
        await webtables.EditFirstName(editedName);
        
        await webtables.VerifyRecordVisible(editedName);
    }

    [Test]
    public async Task DeleteRecord()
    {
        var webtables = new Pages.DemoqaWebtablesPage(Page);
        await webtables.NavigateAsync("https://demoqa.com/webtables");

        string recordToDelete = "Kierra"; // Default record on the page
        
        await webtables.VerifyRecordVisible(recordToDelete);
        await webtables.ClickDeleteRecord(recordToDelete);
        
        await webtables.VerifyRecordHidden(recordToDelete);
    }

    [Test]
    public async Task SearchRecord()
    {
        var webtables = new Pages.DemoqaWebtablesPage(Page);
        await webtables.NavigateAsync("https://demoqa.com/webtables");

        string searchName = "Cierra"; // Default record on the page
        await webtables.SearchRecord(searchName);
        
        await webtables.VerifyRecordVisible(searchName);
    }
}