using Microsoft.Playwright;

namespace PlaywrightDemo.PageOjectModel
{
    public class LoginPage
    {
        private readonly IPage _page;

        public LoginPage(IPage page)
        {
            _page = page;
        }

        public async Task NavigateAsync()
        {
            await _page.GotoAsync("https://demo.snipeitapp.com/login");
        }

        public async Task LoginAsync(string username, string password)
        {
            var usernameInput = _page.Locator("#username");
            var passwordInput = _page.Locator("#password");
            var loginButton = _page.Locator("button[type='submit']");

            await usernameInput.FillAsync(username);
            await passwordInput.FillAsync(password);
            await loginButton.ClickAsync();
        }
    }
}
