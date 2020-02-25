namespace Spice.Services.Admin
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using Spice.Data;
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
                    Category = x.Category,
                    Subcategory = x.Subcategory
                })
                .ToListAsync();

            return list;
        }



    }
}
