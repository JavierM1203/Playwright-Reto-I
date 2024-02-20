using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using PlaywrightDemoCS.Page_Objects;

namespace PlaywrightTests;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
public class LoginTests
{
    //public LoginPage loginPage {  get; private set; }
    
    [SetUp]
    public async Task Setup()
    {

    }

    [Test]
    public async Task InvalidLoginCredentials()
    {
        using var playwright = await Playwright.CreateAsync();
        await using var browser = await playwright.Chromium.LaunchAsync();
        LoginPage loginPage = new LoginPage(await browser.NewPageAsync());
        await loginPage.GotoAsync();
        await loginPage.EnterLoginCredentials("efef", "eef");
        await loginPage.ClickLoginButton();
        //var isVisible = await loginPage.IsErrorMessageVisible();
        //Assert.IsTrue(isVisible);
        var text = await loginPage.ErrorMessageText();
        Assert.IsTrue(text.Contains("Error de inicio de sesión"));
        
    }

    [Test]
    public async Task ValidLoginCredentials()
    {
        using var playwright = await Playwright.CreateAsync();
        await using var browser = await playwright.Chromium.LaunchAsync();
        LoginPage loginPage = new LoginPage(await browser.NewPageAsync());
        await loginPage.GotoAsync();
        await loginPage.EnterLoginCredentials("javier.moreno", "Mtvd1408*");
        await loginPage.ClickLoginButton();
        //var isVisible = await loginPage.IsWelcomeMessageVisible();
        //Assert.IsTrue(isVisible);
        var text = await loginPage.WelcomeMessageText();
        Assert.IsTrue(text.Contains("¡Hola, JAVIER!"));
    }

    //[Test]
    //public async Task NoCredentials()
    //{
    //    await loginPage.ClickLoginButton();
    //    Assert.IsTrue(await loginPage.IsErrorMessageVisible());
    //    Assert.IsTrue(await loginPage.AssertErrorMessageText("Error de inicio de sesión"));
    //}
}
