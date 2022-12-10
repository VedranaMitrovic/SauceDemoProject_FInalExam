namespace SauceDemoProject.Pages
{
    public class CheckoutOverviewPage
    {
        private IWebDriver driver = WebDrivers.Instance;

        public IWebElement ItemTotal => driver.FindElement(By.ClassName("summary_subtotal_label"));
        public IWebElement Total => driver.FindElement(By.ClassName("summary_total_label"));
        public IWebElement FinishButton => driver.FindElement(By.Id("finish"));
    }
}
