namespace SauceDemoProject.Pages
{
    public class YourInfoPage
    {
        private IWebDriver driver = WebDrivers.Instance;

        public IWebElement FirstName => driver.FindElement(By.Id("first-name"));
        public IWebElement LastName => driver.FindElement(By.Id("last-name"));
        public IWebElement ZipCode => driver.FindElement(By.Id("postal-code"));
        public IWebElement ContinueButton => driver.FindElement(By.Id("continue"));
    }
}
