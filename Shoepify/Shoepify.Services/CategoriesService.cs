using Microsoft.EntityFrameworkCore;
using Shoepify.Data;
using Shoepify.Domain;
using Shoepify.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shoepify.Services
{
    public class CategoriesService : ICategoriesService
    {
        private readonly ShoepifyContext context;

        public CategoriesService(ShoepifyContext context)
        {
            this.context = context;
        }

        public async Task<Category?> CreateAsync(Category category)
        {
            if (category == null)
            {
                return null;
            }

            await this.context.Categories.AddAsync(category);
            await this.context.SaveChangesAsync();

            return category;
        }

        public async Task<Category?> GetByIdAsync(int id)
        {
            return await this.context.Categories.SingleOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Category?> GetByNameAsync(string name)
        {
            return await this.context.Categories.SingleOrDefaultAsync(s => s.Name == name);
        }
    }
}
