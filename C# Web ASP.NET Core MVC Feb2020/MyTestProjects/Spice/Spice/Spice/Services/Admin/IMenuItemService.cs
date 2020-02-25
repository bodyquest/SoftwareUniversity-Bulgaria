namespace Spice.Services.Admin
{
    using Spice.Services.Admin.Models.MenuItems;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public interface IMenuItemService
    {
        Task <IEnumerable<AdminMenuItemVM>> GetAllAsync();



        //Task<AdminMenuItemVM> GetByIdAsync(int id);

        //Task<int> CreateAsync(string name, int categoryId, int subcategoryId);

        //Task<bool> UpdateAsync(int id, string name);

        //Task<bool> DeleteAsync(int id);
    }
}
