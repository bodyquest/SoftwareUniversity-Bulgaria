namespace Spice.Services.Admin
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;
    using Spice.Data;
    using Spice.Models;
    using Spice.Services.Admin.Models;

    public class AdminCategoryService : IAdminCategoryService
    {
        private readonly ApplicationDbContext context;

        public AdminCategoryService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task <IEnumerable<AdminCategoriesListingServiceModel>> AllCategoriesAsync()
        {
            var categories = await context.Categories.Select(c => new AdminCategoriesListingServiceModel
            {
                Id = c.Id,
                Name = c.Name
            })
            .ToListAsync();

            return categories;
        }

        public async Task<IEnumerable<Category>> AllAsync()
        {
            var categories = await context.Categories
            .ToListAsync();

            return categories;
        }

        public async Task<bool> CreateAsync(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return  false;
            }

            var category = new Category
            {
                Name = name
            };

            await this.context.Categories.AddAsync(category);
            await this.context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(int? id)
        {
            var category = await this.context.Categories.FindAsync(id);
            if (category == null)
            {
                return false;
            }

            this.context.Remove(category);
            await this.context.SaveChangesAsync();

            return true;
        }

        public async Task<AdminCategoryEditDeleteViewModel> GetAsync(int? id)
        {
            var category = await this.context.Categories.FindAsync(id);

            if (category == null)
            {
                return null;
            }

            var model = new AdminCategoryEditDeleteViewModel
            {
                Id = category.Id,
                Name = category.Name
            };

            return model;
        }

        public async Task<bool> UpdateAsync(int? id, string name)
        {
            var category = await this.context.Categories.FindAsync(id);

            if (id == null || string.IsNullOrWhiteSpace(name))
            {
                return false;
            }

            category.Name = name;
            this.context.Categories.Update(category);
            await this.context.SaveChangesAsync();
            return true;
        }
    }
}
