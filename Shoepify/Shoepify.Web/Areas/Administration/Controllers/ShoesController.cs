using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shoepify.Domain;
using Shoepify.Services.Contracts;
using Shoepify.Web.Areas.Administration.Models.Shoes;

namespace Shoepify.Web.Areas.Administration.Controllers
{
    public class ShoesController : AdministrationController
    {
        private readonly IMapper mapper;
        private readonly IShoesService shoesService;
        private readonly ISizesService sizesService;
        private readonly IColorsService colorsService;

        public ShoesController(IMapper mapper, IShoesService shoesService, ISizesService sizesService, IColorsService colorsService)
        {
            this.mapper = mapper;
            this.shoesService = shoesService;
            this.sizesService = sizesService;
            this.colorsService = colorsService;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ShoeCreateInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            Shoe shoe;
            try
            {
                shoe = this.mapper.Map<Shoe>(model);
                await this.shoesService.CreateAsync(shoe);

                if (model.ShoeSizes != null && model.ShoeSizes.Count > 0)
                {
                    var sizesIds = model.ShoeSizes;
                    var sizesToAdd = sizesIds.Select(s => this.sizesService.GetByIdAsync(s).GetAwaiter().GetResult()).ToList();

                    await this.shoesService.AddSizesAsync(shoe, sizesToAdd);
                }

                if (model.ShoeColors != null && model.ShoeColors.Count > 0)
                {
                    var colorsIds = model.ShoeColors;
                    var colorsToAdd = colorsIds.Select(c => this.colorsService.GetByIdAsync(c).GetAwaiter().GetResult()).ToList();

                    await this.shoesService.AddColorsAsync(shoe, colorsToAdd);
                }
            }
            catch (DbUpdateException)
            {
                return this.View(model);
            }

            return this.RedirectToAction("All", "Shoes", new { area = "" });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var shoe = await this.shoesService.GetByIdAsync(id);

            if (shoe == null)
            {
                return this.NotFound();
            }

            try
            {
                await this.shoesService.DeleteAsync(shoe);
            }
            catch(DbUpdateException)
            {
                this.ModelState.AddModelError("Error", "Could not delete shoe.");
                return this.BadRequest(this.ModelState);
            }

            return this.RedirectToAction("All", "Shoes", new { area = "" });
        }
    }
}
