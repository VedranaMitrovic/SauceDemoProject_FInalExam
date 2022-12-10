namespace SauceDemoProject.Pages
{
    public class LoginPage
    {
        private IWebDriver driver = WebDrivers.Instance;

        public IWebElement Username => driver.FindElement(By.Id("user-name"));
        public IWebElement Password => driver.FindElement(By.Id("password"));
        public IWebElement LoginButton => driver.FindElement(By.Id("login-button"));
        public IWebElement ErrorMessage => driver.FindElement(By.XPath("//*[@id=\"login_button_container\"]/div/form/div[3]/h3"));

        public void LoginOnPage (string username, string password)
        {
            Username.SendKeys(username);
            Password.SendKeys(password);
            LoginButton.Submit();
        }
    }
}
