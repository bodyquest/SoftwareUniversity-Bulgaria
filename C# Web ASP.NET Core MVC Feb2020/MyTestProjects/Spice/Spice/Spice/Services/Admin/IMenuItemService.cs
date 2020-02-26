namespace Spice.Services.Admin
{
    using Spice.Models;
    using Spice.Services.Admin.Models.MenuItems;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public interface IMenuItemService
    {
        Task <IEnumerable<AdminMenuItemVM>> GetAllAsync();

        Task<bool> CreateAsync(MenuItem menuItem);

        Task<MenuItem> GetByIdAsync(int id);

        Task<int> UpdateItemImageAsync(MenuItem menuItem);

        Task<bool> UpdateAsync(MenuItem menuItem);

        Task<bool> DeleteAsync(MenuItem menuItem);
    }
}
