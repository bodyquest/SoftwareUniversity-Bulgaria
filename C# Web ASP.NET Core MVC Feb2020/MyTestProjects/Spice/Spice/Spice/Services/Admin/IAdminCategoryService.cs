namespace Spice.Services.Admin
{
    using Spice.Services.Admin.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public interface IAdminCategoryService
    {
        Task<IEnumerable<AdminCategoriesListingServiceModel>> AllCategoriesAsync();

        Task<bool> CreateAsync(string name);
    }
}
