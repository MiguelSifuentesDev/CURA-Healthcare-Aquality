using System.Reflection;
using Aquality.Selenium.Browsers;
using CURA_Healthcare_Aquality.Pages;

namespace CURA_Healthcare_Aquality
{
    public class Tests
    {
        private readonly Browser browser = AqualityServices.Browser;
        private readonly AppointmentPage appointmentPage = new AppointmentPage();
        private readonly HistoryPage historyPage = new HistoryPage();
        private readonly HomePage homePage = new HomePage();
        private readonly LoginPage loginPage = new LoginPage();
        private const string mainUrl = "https://katalon-demo-cura.herokuapp.com/";
        private const string username = "John Doe";
        private const string password = "ThisIsNotAPassword";

        [SetUp]
        public void Setup()
        {
            browser.Maximize();
            browser.GoTo(mainUrl);
            browser.WaitForPageToLoad();
        }

        [TearDown]
        public void TearDown()
        {

        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            browser.Quit();
        }

        [Test]
        [Description("Verify that the home page title is \"CURA Healthcare Service\".")]
        [Order(1)]
        public void VerifyHomePageLoad()
        {
            Assert.That(browser.Driver.Title == "CURA Healthcare Service", "The title should be: CURA Healthcare Service");
        }

        [Test]
        [Description("Check if clicking the Make Appointment button redirects to the login page.")]
        [Order(2)]
        public void NavigateToLoginPage()
        {
            homePage.MakeAppointment();
            Assert.That(browser.CurrentUrl.Contains("profile.php#login"), "Current Url must be contains profile.php#login");
        }

        [Test]
        [Description("Ensure that a user can log in with valid credentials.")]
        [Order(3)]
        public void SuccessfulLogin()
        {
            homePage.MakeAppointment();
            loginPage.SetUsername(username);
            loginPage.SetPassword(password);
            loginPage.SubmitForm();
            Assert.That(browser.CurrentUrl.Contains("#appointment"), "Current Url must be contains #appointment");
        }

        [Test]
        [Description("Verify that an error message is displayed when login with invalid credentials.")]
        [Order(4)]
        public void UnsuccessfulLogin()
        {
            homePage.MakeAppointment();
            loginPage.SetUsername("username");
            loginPage.SetPassword("password");
            loginPage.SubmitForm();
            Assert.That(loginPage.UnsuccessfulLogin, "An error message: Login failed! Please ensure the username and password are valid. Should be displayed");
        }
    }
}