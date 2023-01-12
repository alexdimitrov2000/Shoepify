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
    public class ShoesService : IShoesService
    {
        private readonly ShoepifyContext context;

        public ShoesService(ShoepifyContext context)
        {
            this.context = context;
        }

        public async Task<Shoe?> CreateAsync(Shoe shoe)
        {
            if (shoe == null)
            {
                return null;
            }

            await this.context.Shoes.AddAsync(shoe);
            await this.context.SaveChangesAsync();

            return shoe;
        }

        public async Task<Shoe?> GetByIdAsync(int id)
        {
            return await this.context.Shoes.SingleOrDefaultAsync(s => s.Id == id);
        }

        public async Task<List<Shoe>> GetAllAsync()
        {
            return await this.context.Shoes.ToListAsync();
        }

        public async Task<Shoe?> AddSizesAsync(Shoe shoe, List<Size?> sizesToAdd)
        {
            if (shoe == null || sizesToAdd == null)
            {
                return null;
            }

            sizesToAdd.ForEach(async s =>
            {
                await this.context.ShoeSizes.AddAsync(new ShoeSize
                {
                    Shoe = shoe,
                    Size= s
                });
            });
            await this.context.SaveChangesAsync();

            return shoe;
        }

        public async Task<Shoe?> AddColorsAsync(Shoe shoe, List<Color?> colorToAdd)
        {
            if (shoe == null || colorToAdd == null)
            {
                return null;
            }

            colorToAdd.ForEach(async c =>
            {
                await this.context.ShoeColors.AddAsync(new ShoeColor
                {
                    Shoe = shoe,
                    Color = c
                });
            });
            await this.context.SaveChangesAsync();

            return shoe;
        }

        public async Task<bool> DeleteAsync(Shoe shoe)
        {
            if (shoe == null)
            {
                return false;
            }

            var shoeColors = shoe.Colors;
            this.context.ShoeColors.RemoveRange(shoeColors);
            var shoeSizes = shoe.Sizes;
            this.context.ShoeSizes.RemoveRange(shoeSizes);
            this.context.Shoes.Remove(shoe);
            await this.context.SaveChangesAsync();

            return true;
        }
    }
}
