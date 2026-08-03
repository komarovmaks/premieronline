# Реализация функциональности поиска (Page Object Model)

Этот план описывает добавление функциональности поиска с использованием Playwright .NET (C#) и NUnit.

## Мои рекомендации и поправки к плану

> [!TIP]
> 1. **Локаторы и методы в `HeaderComponents.cs`**: Так как поле поиска физически находится в шапке (header) сайта, мы добавим локаторы и методы поиска в уже существующий класс `HeaderComponents.cs`. Это полностью соответствует принципу DRY и не требует создания отдельного Page Object.
> 2. **Тесты в `HeaderTest.cs`**: Как вы и просили, все тесты для поиска будут добавлены в уже существующий файл `Tests/HeaderTest.cs`. Это логично, поскольку поиск является частью компонента Header.
> 3. **Fluent Interface (Method Chaining)**: Метод `Search(string text)` может возвращать `this` (то есть сам `HeaderComponents`), что позволит писать тесты цепочкой: `header.Search(ValidEvent).VerifyResultsVisible();`.
> 4. **Ожидания**: Окно результатов поиска (`.livesearch_popup`) появляется динамически. Мы будем использовать встроенные методы вроде `Locator.WaitForAsync()` и `Expect(Locator).ToBeVisibleAsync()` без искусственных задержек `Task.Delay`.
> 5. **Переиспользование BasePage**: Всегда использовать уже существующие в `BasePage.cs` методы (например, `FillAsync`, `ClickAsync` и другие), чтобы избежать дублирования проверок `ToBeVisibleAsync` и `ToBeEnabledAsync` перед каждым действием.

## Proposed Changes

### Data

#### [NEW] SearchData.cs
Класс с тестовыми константами.
- `ValidEvent`
- `ValidOrganizer`
- `InvalidSearch` (и другие сценарии: пустое, числа, спецсимволы и т.д.)

---

### Pages

#### [MODIFY] HeaderComponents.cs
Добавим функциональность поиска в существующий компонент шапки.
- **Приватные локаторы**: Поле поиска (`#search`), Иконка поиска (`.fa-search`), Контейнер результатов (`.livesearch_popup`), Сообщение об отсутствии результатов (текст "Apologies!").
- **Методы**:
  - `FillSearch()`, `ClearSearch()`, `FocusSearch()`, `GetSearchValue()`.
  - Универсальный `Search(string text)`.
  - Проверки: `VerifySearchVisible()`, `VerifyPlaceholder()`, `VerifyInputType()`, `VerifySearchEnabled()`, `VerifySearchValue()`.
  - Результаты: `GetResults()`, `GetResultsCount()`, `VerifyResultsVisible()`, `VerifyNoResults()`, `ClickFirstResult()`.
- Будет использоваться `LoggerHelper.Info` для логирования.

---

### Tests

#### [MODIFY] HeaderTest.cs
Добавление новых тестовых сценариев в существующий класс.
- Набор независимых тестов: `SearchByEventName()`, `SearchByOrganizer()`, `SearchEmpty()`, `SearchInvalid()`, `SearchNumbers()`, `SearchWithSpecialCharacters()`, `SearchWithLongText()`.
- Все проверки инкапсулированы внутри методов `HeaderComponents`.

## Verification Plan

### Automated Tests
- Запуск тестов через `dotnet test`. Убедимся, что все сценарии успешно проходят и корректно логируются.
