namespace Spice.Services.Admin
{
    using Microsoft.EntityFrameworkCore;
    using Spice.Data;
    using Spice.Models;
    using Spice.Services.Admin.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

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
    }
}
