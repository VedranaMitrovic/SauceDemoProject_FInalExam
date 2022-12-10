namespace SauceDemoProject.Pages
{
    public class CartPage
    {
        private IWebDriver driver = WebDrivers.Instance;

        public IWebElement RemoveBackpack => driver.FindElement(By.Id("remove-sauce-labs-backpack"));
        public IWebElement RemoveFleeceJacket => driver.FindElement(By.Id("remove-sauce-labs-fleece-jacket"));
        public IWebElement ContinueShoppingButtom => driver.FindElement(By.Id("continue-shopping"));
        public IWebElement CheckoutButton => driver.FindElement(By.Id("checkout"));
    }
}
