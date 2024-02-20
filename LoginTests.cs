using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using PlaywrightDemoCS.Page_Objects;

namespace PlaywrightTests;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
public class LoginTests : PageTest
{
    public LoginPage loginPage;

    [SetUp]
    public async Task Setup()
    {
        loginPage = new LoginPage(Page);
        await loginPage.GotoAsync();
    }

    [Test]
    public async Task InvalidLoginCredentials()
    {
        await loginPage.EnterLoginCredentials("efef", "eef");
        await loginPage.ClickLoginButton();
        //var isVisible = await loginPage.IsErrorMessageVisible();
        //Assert.IsTrue(isVisible);
        await Expect(loginPage._errorMessage).ToBeVisibleAsync();
        //var text = await loginPage.ErrorMessageText();
        //Assert.IsTrue(text.Contains("Error de inicio de sesión"));
        await Expect(loginPage._errorMessage).ToContainTextAsync("Error de inicio de sesión");
    }

    [Test]
    public async Task ValidLoginCredentials()
    {
        await loginPage.EnterLoginCredentials("javier.moreno", "Mtvd1408*");
        await loginPage.ClickLoginButton();
        //var isVisible = await loginPage.IsWelcomeMessageVisible();
        //Assert.IsTrue(isVisible);
        await Expect(loginPage._welcomeMessage).ToBeVisibleAsync();
        //var text = await loginPage.WelcomeMessageText();
        //Assert.IsTrue(text.Contains("¡Hola, JAVIER!"));
        await Expect(loginPage._welcomeMessage).ToContainTextAsync("¡Hola, JAVIER!");
    }

    [Test]
    public async Task NoCredentials()
    {
        await loginPage.ClickLoginButton();
        //Assert.IsTrue(await loginPage.IsErrorMessageVisible());
        await Expect(loginPage._errorMessage).ToBeVisibleAsync();
        //Assert.IsTrue(await loginPage.AssertErrorMessageText("Error de inicio de sesión"));
        await Expect(loginPage._errorMessage).ToContainTextAsync("Error de inicio de sesión");
    }
}
