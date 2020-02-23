namespace Spice.Services.Admin.Models
{
    using Microsoft.EntityFrameworkCore;
    using Spice.Data;
    using Spice.Models;
    using Spice.Models.ViewModels;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class AdminSubcategoryService : IAdminSubcategoryService
    {
        private readonly ApplicationDbContext context;

        public AdminSubcategoryService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<AdminSubcategoriesListingServiceModel>> AllSubcategoriesAsync()
        {
            var subcategories = await context.Subcategories.Select(c => new AdminSubcategoriesListingServiceModel
            {
                Id = c.Id,
                Name = c.Name,
                CategoryName = c.Category.Name
            })
            .ToListAsync();

            return subcategories;
        }

        public async Task<SubcategoryAndCategoryViewModel> GetCreateAsync()
        {
            SubcategoryAndCategoryViewModel model = new SubcategoryAndCategoryViewModel
            { 
                CategoryList = await this.context
                    .Categories
                    .OrderBy(c => c.Name)
                    .ToListAsync(),
                Subcategory = new Subcategory(),
                SubcategoryList = await this.context.Subcategories
                    .OrderBy(x => x.Name)
                    .Select(x => x.Name)
                    .Distinct()
                    .ToListAsync()
            };

            return model;
        }

        public async Task<bool> DeleteAsync(int? id)
        {
            throw new NotImplementedException();
        }

        public async Task<int?> CreateAsync(string name, int categoryId)
        {
            var subcategory = await this.context.Subcategories
                .FirstOrDefaultAsync(s => s.Name == name && s.CategoryId == categoryId);

            if (subcategory != null)
            {
                //Error
                return null;
            }
            else
            {
                subcategory = new Subcategory
                {
                    Name = name,
                    CategoryId = categoryId
                };

                await this.context.Subcategories.AddAsync(subcategory);
                await this.context.SaveChangesAsync();

                return subcategory.Id;
            }
        }

        public Task<bool> UpdateAsync(int? id, string name)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<SubcategoryViewModel>> GetListAsync(int id)
        {
            var subcategories = await this.context
               .Subcategories
               .Where(x => x.CategoryId == id)
               .Select(x => new SubcategoryViewModel
               {
                   Id = x.Id,
                   Name = x.Name
               }).ToListAsync();

            return subcategories;
        }
    }
}
