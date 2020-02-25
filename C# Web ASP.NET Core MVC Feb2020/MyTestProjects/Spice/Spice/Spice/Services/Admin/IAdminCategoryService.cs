namespace Spice.Services.Admin
{
    using Spice.Models;
    using Spice.Services.Admin.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public interface IAdminCategoryService
    {
        Task<IEnumerable<AdminCategoriesListingServiceModel>> AllCategoriesAsync();

        Task<IEnumerable<Category>> AllAsync();

        Task<bool> CreateAsync(string name);

        Task<AdminCategoryEditDeleteViewModel> GetAsync(int? id);

        Task<bool> UpdateAsync(int? id, string name);

        Task<bool> DeleteAsync(int? id);
    }
}
