using Microsoft.EntityFrameworkCore;
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
    public class SizesService : ISizesService
    {
        private readonly ShoepifyContext context;

        public SizesService(ShoepifyContext context)
        {
            this.context = context;
        }

        public async Task<Size?> CreateAsync(Size size)
        {
            if (size == null)
            {
                return null;
            }

            await this.context.Sizes.AddAsync(size);
            await this.context.SaveChangesAsync();

            return size;
        }

        public async Task<Size?> GetByIdAsync(int id)
        {
            return await this.context.Sizes.SingleOrDefaultAsync(s => s.Id == id);
        }
    }
}
