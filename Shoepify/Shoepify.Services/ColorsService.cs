using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Shoepify.Data;
using Shoepify.Domain;
using Shoepify.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shoepify.Services
{
    public class ColorsService : IColorsService
    {
        private readonly ShoepifyContext context;

        public ColorsService(ShoepifyContext context)
        {
            this.context = context;
        }

        public async Task<Color?> CreateAsync(Color color)
        {
            if (color == null)
            {
                return null;
            }

            await this.context.Colors.AddAsync(color);
            await this.context.SaveChangesAsync();

            return color;
        }

        public async Task<Color?> GetByIdAsync(int id)
        {
            return await this.context.Colors.SingleOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Color?> GetByNameAsync(string name)
        {
            return await this.context.Colors.SingleOrDefaultAsync(c => c.Name == name);
        }

        public async Task<List<Color>> GetAllAsync()
        {
            return await this.context.Colors.ToListAsync();
        }
    }
}
