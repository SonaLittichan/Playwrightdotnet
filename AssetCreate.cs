using Microsoft.Playwright;
using System;
using System.Threading.Tasks;

namespace PlaywrightDemo.PageOjectModel
{
    public class AssetCreate
    {
        private readonly IPage _page;

        public AssetCreate(IPage page)
        {
            _page = page;
        }

        // Navigate to Assets page 
        public async Task NavigateAsync()
        {
            await _page.GotoAsync("https://demo.snipeitapp.com/hardware");
        }

        // Create a new Macbook Pro 13" asset
        public async Task CreateMacbookProAssetAsync(string assignedUser)
        {
            // Click "Create New" button
            await _page.Locator("text=Create New").ClickAsync();

            // Fill in the asset details
            await _page.Locator("#asset_name").FillAsync("Macbook Pro 13\"");
            await _page.Locator("#model_id").SelectOptionAsync(new[] { "Macbook Pro 13\"" }); 
            await _page.Locator("#status_id").SelectOptionAsync(new[] { "1" }); 

            // Assign to random user
            await _page.Locator("#assigned_to_user").FillAsync(assignedUser);

            // Click Save
            await _page.Locator("text=Save").ClickAsync();
        }
    }
}

