using System.Threading.Tasks;
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;

namespace PlaywrightDemoCS.Page_Objects;
public class LoginPage
{
    private IPage _page;
    private readonly ILocator _username;
    private readonly ILocator _password;
    private readonly ILocator _loginButton;
    private readonly ILocator _errorMessage;
    private readonly ILocator _welcomeMessage;


    public LoginPage(IPage page) 
    {
        _page = page;
        _username = page.Locator("#username");
        _password = page.Locator("#password");
        _loginButton = page.Locator("#loginbtn");
        _errorMessage = page.Locator("#loginerrormessage");
        _welcomeMessage = page.Locator(".welcome-note");
    }

    public async Task GotoAsync() => await _page.GotoAsync("https://webasignatura.ucu.edu.uy/login/index.php");

    public async Task EnterLoginCredentials(string username, string password)
    {
        await _username.FillAsync(username);
        await _password.FillAsync(password);
    }

    public async Task ClickLoginButton() => await _loginButton.ClickAsync();

    public async Task<bool> IsErrorMessageVisible() => await _errorMessage.IsVisibleAsync();

    public async Task<string> ErrorMessageText() => await _errorMessage.TextContentAsync();

    public async Task<bool> IsWelcomeMessageVisible() => await _welcomeMessage.IsVisibleAsync();

    public async Task<string> WelcomeMessageText() => await _welcomeMessage.TextContentAsync();

    public async Task Logout() => await _page.GotoAsync("https://webasignatura.ucu.edu.uy/login/logout.php");

}
