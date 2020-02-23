﻿namespace Spice.Services.Admin.Models
{
    using Spice.Models.ViewModels;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public interface IAdminSubcategoryService
    {
        Task<IEnumerable<AdminSubcategoriesListingServiceModel>> AllSubcategoriesAsync();

        Task<SubcategoryAndCategoryViewModel> GetCreateAsync();

        Task<IEnumerable<SubcategoryViewModel>> GetListAsync(int id);

        Task<int?> CreateAsync(string name, int categoryId);

        Task<bool> UpdateAsync(int? id, string name);

        Task<bool> DeleteAsync(int? id);
    }
}
