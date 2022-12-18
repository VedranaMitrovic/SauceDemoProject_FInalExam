namespace SauceDemoProject.Tests
{
    public class LoginTest
    {
        LoginPage loginPage;

        [SetUp]
        public void Setup()
        {
            WebDrivers.Initialize();
            loginPage = new LoginPage();
        }

        [TearDown]
        public void TearDown()
        {
            WebDrivers.CleanUp();
        }

        [Test]
        public void TC01_EnterValidUsernameAndPassword_ShouldLogin()
        {
            loginPage.LoginOnPage("standard_user", "secret_sauce");
            Assert.That("https://www.saucedemo.com/inventory.html", Is.EqualTo(WebDrivers.Instance.Url));
        }

        [Test]
        public void TC02_EnterValidUsernameAndInvalidPassword_ShouldNotLogin()
        {
            loginPage.LoginOnPage("standard_user", "SECRET_SAUCE");
            Assert.That("Epic sadface: Username and password do not match any user in this service", Is.EqualTo(loginPage.ErrorMessage.Text));
        }

        [Test]
        public void TC03_EnterInvalidUsernameAndValidPassword_ShouldNotLogin()
        {
            loginPage.LoginOnPage("StandardUser", "secret_sauce");
            Assert.That("Epic sadface: Username and password do not match any user in this service", Is.EqualTo(loginPage.ErrorMessage.Text));
        }

        [Test]
        public void TC04_EnterInvalidUsernameAndInvalidPassword_ShouldNotLogin()
        {
            loginPage.LoginOnPage("user", "pass");
            Assert.That("Epic sadface: Username and password do not match any user in this service", Is.EqualTo(loginPage.ErrorMessage.Text));
        }

        [Test]
        public void TC05_ClickLoginWithoutLoginData_ShouldNotLogin()
        {
            loginPage.LoginButton.Submit();
            Assert.That("Epic sadface: Username is required", Is.EqualTo(loginPage.ErrorMessage.Text));
        }
    }
}