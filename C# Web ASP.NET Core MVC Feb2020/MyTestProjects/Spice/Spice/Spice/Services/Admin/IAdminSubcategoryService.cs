namespace Spice.Services.Admin.Models
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

        Task<int?> CreateAsync(string name, int categoryId);

        Task<bool> ExistsAsync(string name, int categoryId);

        Task<SubcategoryAndCategoryViewModel> GetEditAsync(int? id);

        Task<SubcategoryViewModel> GetByIdAsync(int id);

        Task<IEnumerable<SubcategoryViewModel>> GetListAsync(int id);

        Task<bool> UpdateAsync(int id, string name);

        Task<bool> DeleteAsync(int? id);
    }
}
