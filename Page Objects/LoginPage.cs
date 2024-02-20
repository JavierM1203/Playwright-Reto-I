using System.Threading.Tasks;
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;

namespace PlaywrightDemoCS.Page_Objects;
public class LoginPage
{
    private IPage _page;
    public LoginPage(IPage page) => _page = page;

    public ILocator _username => _page.Locator("#username");
    private ILocator _password => _page.Locator("#password");
    private ILocator _loginButton => _page.Locator("#loginbtn");
    private ILocator  _errorMessage => _page.Locator("#loginerrormessage");
    private ILocator _welcomeMessage => _page.Locator(".welcome-note");

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
