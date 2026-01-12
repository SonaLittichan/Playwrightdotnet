using Microsoft.Playwright;
using System.Threading.Tasks;

namespace PlaywrightDemo.PageOjectModel
{
    public class AssetNavigate
    {
        private readonly IPage _page;

        public AssetNavigate(IPage page)
        {
            _page = page;
        }

        // Navigate to assets list
        public async Task NavigateAsync()
        {
            await _page.GotoAsync("https://demo.snipeitapp.com/hardware");
        }

        // Open asset details by clicking asset name
        public async Task OpenAssetDetailsAsync(string assetName)
        {
            var assetLink = _page.Locator($"table >> text={assetName}");
            await assetLink.First.ClickAsync();
        }

        // Validate asset details on asset page
        public async Task<bool> ValidateAssetDetailsAsync(
            string expectedName,
            string expectedStatus,
            string expectedUser)
        {
            var name = await _page.Locator("h1").TextContentAsync();
            var status = await _page.Locator("text=Status").Locator("xpath=following-sibling::dd").TextContentAsync();
            var assignedTo = await _page.Locator("text=Assigned To").Locator("xpath=following-sibling::dd").TextContentAsync();

            return name.Contains(expectedName)
                && status.Contains(expectedStatus)
                && assignedTo.Contains(expectedUser);
        }
    }
}
