using Microsoft.Playwright;
 
namespace Tests.Pages;
 
public class HeaderComponents : BasePage

{

    private const string Url = "https://www.premieronline.com/";
 
    public HeaderComponents(IPage page) : base(page)

    {

    }
    //Locators
    private ILocator Logo =>

        Page.GetByAltText("Premiere Online");
 
    
    private ILocator Events =>

        Page.GetByRole(AriaRole.Link, new() { Name = "Events" });
 
    private ILocator Ratings =>

        Page.GetByRole(AriaRole.Link, new() { Name = "Ratings" });
 
    private ILocator Help =>

        Page.GetByRole(AriaRole.Link, new() { Name = "Help" });
 
    // Search Locators
    private ILocator SearchInput => Page.Locator("#search");
    private ILocator SearchIcon => Page.Locator(".fa-search");
    private ILocator SearchResultsContainer => Page.Locator(".livesearch_popup");
    private ILocator SearchResultsRows => Page.Locator("#s_ext_events tbody tr");
    private ILocator NoResultsMessage => Page.Locator(".livesearch_popup .uk-text-large");


    // Public actions 
    public async Task Open()
    {
        await Page.GotoAsync(Url);
    }
 
    public async Task VerifyHeaderComponents()

    {

        await Expect(Page).ToHaveURLAsync(Url);
 
        await Expect(Logo).ToBeVisibleAsync();
 
        await Expect(Events).ToBeVisibleAsync();

        await Expect(Events).ToBeEnabledAsync();
 
        await Expect(Ratings).ToBeVisibleAsync();

        await Expect(Ratings).ToBeEnabledAsync();
 
        await Expect(Help).ToBeVisibleAsync();

        await Expect(Help).ToBeEnabledAsync();

    }
 
    // Search Actions
    public async Task<HeaderComponents> FocusSearch()
    {
        await Expect(SearchInput).ToBeVisibleAsync();
        await Expect(SearchInput).ToBeEnabledAsync();
        await SearchInput.FocusAsync();
        return this;
    }

    public async Task<HeaderComponents> FillSearch(string text)
    {
        await FillAsync(SearchInput, text);
        return this;
    }

    public async Task<HeaderComponents> ClearSearch()
    {
        await Expect(SearchInput).ToBeVisibleAsync();
        await Expect(SearchInput).ToBeEnabledAsync();
        await SearchInput.ClearAsync();
        return this;
    }

    public async Task<string> GetSearchValue()
    {
        return await SearchInput.InputValueAsync();
    }

    public async Task<HeaderComponents> Search(string text)
    {
        Utils.LoggerHelper.Info($"Начало поиска: '{text}'");
        
        await ClearSearch();
        Utils.LoggerHelper.Info("Поле поиска очищено");
        
        await FillSearch(text);
        Utils.LoggerHelper.Info($"Введено значение: '{text}'");
        
        Utils.LoggerHelper.Info("Завершение поиска (ожидание результатов)");
        return this;
    }

    // Search Verifications
    public async Task<HeaderComponents> VerifySearchVisible()
    {
        await Expect(SearchInput).ToBeVisibleAsync();
        await Expect(SearchIcon).ToBeVisibleAsync();
        return this;
    }

    public async Task<HeaderComponents> VerifySearchEnabled()
    {
        await Expect(SearchInput).ToBeEnabledAsync();
        return this;
    }

    public async Task<HeaderComponents> VerifyPlaceholder(string expectedPlaceholder)
    {
        await Expect(SearchInput).ToHaveAttributeAsync("placeholder", expectedPlaceholder);
        return this;
    }

    public async Task<HeaderComponents> VerifyInputType(string expectedType)
    {
        await Expect(SearchInput).ToHaveAttributeAsync("type", expectedType);
        return this;
    }

    public async Task<HeaderComponents> VerifySearchValue(string expectedValue)
    {
        await Expect(SearchInput).ToHaveValueAsync(expectedValue);
        return this;
    }

    // Search Results Actions and Verifications
    public async Task<HeaderComponents> VerifyResultsVisible()
    {
        await Expect(SearchResultsContainer).ToBeVisibleAsync();
        return this;
    }

    public async Task<HeaderComponents> VerifyNoResults()
    {
        await Expect(SearchResultsContainer).ToBeVisibleAsync();
        await Expect(NoResultsMessage).ToBeVisibleAsync();
        await Expect(NoResultsMessage).ToContainTextAsync("We couldn't find any events");
        return this;
    }

    public async Task<int> GetResultsCount()
    {
        await VerifyResultsVisible();
        int count = await SearchResultsRows.CountAsync();
        Utils.LoggerHelper.Info($"Количество найденных результатов: {count}");
        return count;
    }

    public async Task<IReadOnlyList<string>> GetResults()
    {
        await VerifyResultsVisible();
        var results = await SearchResultsRows.AllInnerTextsAsync();
        Utils.LoggerHelper.Info($"Получено {results.Count} результатов поиска");
        return results;
    }

    public async Task ClickFirstResult()
    {
        await VerifyResultsVisible();
        var firstResult = SearchResultsRows.First;
        await ClickAsync(firstResult);
    }
}