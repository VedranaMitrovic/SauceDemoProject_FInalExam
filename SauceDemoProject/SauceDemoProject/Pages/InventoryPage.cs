namespace SauceDemoProject.Pages
{
    public class InventoryPage
    {
        private IWebDriver driver = WebDrivers.Instance;

        public IWebElement ProductSort => driver.FindElement(By.ClassName("product_sort_container"));
        public IWebElement AddOnesie => driver.FindElement(By.Id("add-to-cart-sauce-labs-onesie"));
        public IWebElement AddBikeLight => driver.FindElement(By.Id("add-to-cart-sauce-labs-bike-light"));
        public IWebElement AddBoltTShirt => driver.FindElement(By.Id("add-to-cart-sauce-labs-bolt-t-shirt"));
        public IWebElement AddBackpack => driver.FindElement(By.Id("add-to-cart-sauce-labs-backpack"));
        public IWebElement AddFleeceJacket => driver.FindElement(By.Id("add-to-cart-sauce-labs-fleece-jacket"));
        public IWebElement ShoppingCart => driver.FindElement(By.Id("shopping_cart_container"));

        public void SelectSortOption(string text)
        {
            SelectElement element = new SelectElement(ProductSort);
            element.SelectByText(text);
        }
    }
}
