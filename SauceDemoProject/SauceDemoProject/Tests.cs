namespace SauceDemoProject
{
    public class Tests
    {
        LoginPage loginPage;
        InventoryPage inventoryPage;
        CartPage cartPage; 
        YourInfoPage yourInfoPage;
        CheckoutOverviewPage checkoutOverviewPage;    
        CheckoutCompletePage checkoutCompletePage;
      
        [SetUp]
        public void Setup()
        {
            WebDrivers.Initialize();
            loginPage= new LoginPage();  
            inventoryPage= new InventoryPage();
            cartPage= new CartPage();
            yourInfoPage = new YourInfoPage();
            checkoutOverviewPage= new CheckoutOverviewPage();
            checkoutCompletePage= new CheckoutCompletePage();
        }

        [TearDown] 
        public void TearDown()
        {
            WebDrivers.CleanUp();
        }

        [Test]
        public void TC01_0_EnterValidUsernameAndPassword_ShouldLogin()
        {
            loginPage.LoginOnPage("standard_user", "secret_sauce");
            Assert.That("https://www.saucedemo.com/inventory.html", Is.EqualTo(WebDrivers.Instance.Url));
        }

        [Test]
        public void TC01_1_EnterValidUsernameAndInvalidPassword_ShouldNotLogin()
        {
            loginPage.LoginOnPage("standard_user", "SECRET_SAUCE");
            Assert.That("Epic sadface: Username and password do not match any user in this service", Is.EqualTo(loginPage.ErrorMessage.Text));
        }

        [Test]
        public void TC01_2_EnterInvalidUsernameAndValidPassword_ShouldNotLogin()
        {
            loginPage.LoginOnPage("StandardUser", "secret_sauce");
            Assert.That("Epic sadface: Username and password do not match any user in this service", Is.EqualTo(loginPage.ErrorMessage.Text));
        }

        [Test]
        public void TC01_3_EnterInvalidUsernameAndInvalidPassword_ShouldNotLogin()
        {
            loginPage.LoginOnPage("user", "pass");
            Assert.That("Epic sadface: Username and password do not match any user in this service", Is.EqualTo(loginPage.ErrorMessage.Text));
        }

        [Test]
        public void TC01_4_ClickLoginWithoutLoginData_ShouldNotLogin()
        {
            loginPage.LoginButton.Submit();
            Assert.That("Epic sadface: Username is required", Is.EqualTo(loginPage.ErrorMessage.Text));
        }

        [Test]
        public void TC02_Add3CheapestProductsToCart_3CHeapestProductsShouldBeAddedToCart()
        {
            loginPage.LoginOnPage("standard_user", "secret_sauce");
            inventoryPage.SelectSortOption("Price (low to high)");
            inventoryPage.AddOnesie.Click();
            inventoryPage.AddBikeLight.Click();
            inventoryPage.AddBoltTShirt.Click();
            Assert.That("3", Is.EqualTo(inventoryPage.ShoppingCart.Text));
        }

        [Test]
        public void TC02_1_AddAndRemove2ProductsFromCart_2ProductsShouldBeAddedAndRemovedFromCart()
        {
            loginPage.LoginOnPage("standard_user", "secret_sauce");
            inventoryPage.AddBackpack.Click();
            inventoryPage.AddFleeceJacket.Click();
            inventoryPage.ShoppingCart.Click();
            cartPage.RemoveBackpack.Click();
            cartPage.RemoveFleeceJacket.Click();
            cartPage.ContinueShoppingButtom.Click();
            Assert.That("", Is.EqualTo(inventoryPage.ShoppingCart.Text));
        }

        [Test]
        public void TC03_CheckItemTotalPriceInCart_ItemTotalPriceShoulBeChecked()
        {
            loginPage.LoginOnPage("standard_user", "secret_sauce");
            inventoryPage.AddBackpack.Click();
            inventoryPage.AddBikeLight.Click();
            inventoryPage.ShoppingCart.Click();
            cartPage.CheckoutButton.Click();
            yourInfoPage.FirstName.SendKeys("Vedrana");
            yourInfoPage.LastName.SendKeys("Mitrovic");
            yourInfoPage.ZipCode.SendKeys("11000");
            yourInfoPage.ContinueButton.Submit();
            Assert.That("Item total: $39.98", Is.EqualTo(checkoutOverviewPage.ItemTotal.Text)); 
        }

        [Test]
        public void TC04_TotalPriceInCart_TotalPriceShouldBeChecked()
        {
            loginPage.LoginOnPage("standard_user", "secret_sauce");
            inventoryPage.AddOnesie.Click();
            inventoryPage.AddBikeLight.Click();
            inventoryPage.AddFleeceJacket.Click();
            inventoryPage.ShoppingCart.Click();
            cartPage.CheckoutButton.Click();
            yourInfoPage.FirstName.SendKeys("Vedrana");
            yourInfoPage.LastName.SendKeys("Mitrovic");
            yourInfoPage.ZipCode.SendKeys("11000");
            yourInfoPage.ContinueButton.Submit();
            Assert.That("Total: $73.41", Is.EqualTo(checkoutOverviewPage.Total.Text));
        }

        [Test]
        public void TC05_Buy2Products_ShoulBuy2Products()
        {
            loginPage.LoginOnPage("standard_user", "secret_sauce");
            inventoryPage.AddBackpack.Click();
            inventoryPage.AddOnesie.Click();
            inventoryPage.ShoppingCart.Click();
            cartPage.CheckoutButton.Click();
            yourInfoPage.FirstName.SendKeys("Vedrana");
            yourInfoPage.LastName.SendKeys("Mitrovic");
            yourInfoPage.ZipCode.SendKeys("11000");
            yourInfoPage.ContinueButton.Submit();
            checkoutOverviewPage.FinishButton.Click();
            Assert.That("THANK YOU FOR YOUR ORDER", Is.EqualTo(checkoutCompletePage.OrderFinished.Text));
        }
    }
}