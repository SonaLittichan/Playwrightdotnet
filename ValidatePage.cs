using Microsoft.Playwright;
using System.Threading.Tasks;

namespace PlaywrightDemo.PageOjectModel
{
    public class ValidatePage
    {
        private readonly IPage _page;

        public ValidatePage(IPage page)
        {
            _page = page;
        }

        // Open History tab
        public async Task OpenHistoryTabAsync()
        {
            await _page.Locator("a[href='#history']").ClickAsync();
            await _page.WaitForSelectorAsync("table#assetHistory");
        }

        // Validate history entry exists
        public async Task<bool> IsHistoryEntryPresentAsync(
            string expectedAction,
            string expectedUser)
        {
            var historyRow = _page.Locator(
                $"table#assetHistory >> tr:has-text('{expectedAction}') >> text={expectedUser}");

            return await historyRow.First.IsVisibleAsync();
        }

        // Validate asset creation entry
        public async Task<bool> ValidateAssetCreatedHistoryAsync()
        {
            return await _page
                .Locator("table#assetHistory >> tr:has-text('created')")
                .First
                .IsVisibleAsync();
        }

        // Validate checkout history
        public async Task<bool> ValidateCheckedOutHistoryAsync(string assignedUser)
        {
            return await _page
                .Locator($"table#assetHistory >> tr:has-text('Checked Out') >> text={assignedUser}")
                .First
                .IsVisibleAsync();
        }
    }
}
