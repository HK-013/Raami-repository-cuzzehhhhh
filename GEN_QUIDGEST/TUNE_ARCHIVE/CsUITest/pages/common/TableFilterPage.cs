namespace quidgest.uitests.pages;

public class TableFilterPage : PageObject
{
    private string tableId;

    private string id => "q-modal-config";

    private string valueControlId => tableId + "_filters_0_0_0";

    /// <summary>
    /// Dropdown container element
    /// </summary>
    private IWebElement popupContainer => GetElement(driver, By.Id(id));

    private string searchType => GetElement(popupContainer, By.CssSelector("[data-search-type]"))?.GetAttribute("data-search-type");

    public EnumControl Field => new(driver, By.Id(id), By.CssSelector("[data-control-type='field'] .q-field"));

    public EnumControl Operation => new(driver, By.Id(id), By.CssSelector("[data-control-type='operator'] .q-field"));

    public InputControl Value
    {
        get
        {
            return searchType switch
            {
                "date" => new DateInputControl(driver, By.Id(id), "[data-control-type='value'] .q-field"),
                _ => new BaseInputControl(driver, By.Id(id), "container-" + valueControlId, "#" + valueControlId)
            };
        }
    }

    public ButtonControl Create => new(driver, By.Id(id), "[data-testid='filter-create']");

    public ButtonControl RemoveAll => new(driver, By.Id(id), "[data-testid='filter-remove']");

    public IWebElement Save => GetElement(driver, By.Id("apply-config-btn"));

    public IWebElement Cancel => GetElement(driver, By.Id("cancel-config-btn"));

    public TableFilterPage(IWebDriver driver, string tableId) : base(driver)
    {
        this.tableId = tableId;

        wait.Until(c => popupContainer != null);
    }
}
