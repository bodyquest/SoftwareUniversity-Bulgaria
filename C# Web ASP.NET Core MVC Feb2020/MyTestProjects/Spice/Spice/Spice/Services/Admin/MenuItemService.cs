namespace Spice.Services.Admin
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using Spice.Data;
    using Spice.Models;
    using Spice.Services.Admin.Models.MenuItems;

    public class MenuItemService : IMenuItemService
    {
        private readonly ApplicationDbContext context;

        public MenuItemService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<AdminMenuItemVM>> GetAllAsync()
        {
            var list = await this.context
                .MenuItems
                .Select(x => new AdminMenuItemVM
                {
                    Id = x.Id,
                    Name = x.Name,
                    Price = x.Price,
                    Category = x.Category,
                    Subcategory = x.Subcategory
                })
                .ToListAsync();

            return list;
        }

        public async Task<bool> CreateAsync(MenuItem menuItem)
        {
            var itemExists = await this.context.MenuItems.AnyAsync(x => x.Name == menuItem.Name);

            if (!itemExists)
            {
                await this.context.MenuItems.AddAsync(menuItem);
                await this.context.SaveChangesAsync();

                return true;
            }

            return false;
        }

        public async Task<MenuItem> GetByIdAsync(int id)
        {
            var item = await this.context.MenuItems.FirstOrDefaultAsync(x => x.Id == id);

            return item;
        }

        public async Task<int> UpdateItemImageAsync(MenuItem menuItem)
        {
            this.context.MenuItems.Update(menuItem);

            var result = await this.context.SaveChangesAsync();

            return result;
        }

    }
}
