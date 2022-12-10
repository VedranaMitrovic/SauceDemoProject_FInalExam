namespace SauceDemoProject.Pages
{
    public class CheckoutCompletePage
    {
        private IWebDriver driver = WebDrivers.Instance;

        public IWebElement OrderFinished => driver.FindElement(By.ClassName("complete-header"));
    }
}
