using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Shoepify.Infrastructure.Extensions;
using Shoepify.Services.Contracts;
using Shoepify.Web.Models.Shoes;

namespace Shoepify.Web.Controllers
{
    public class ShoesController : Controller
    {
        private readonly IMapper mapper;
        private readonly IShoesService shoesService;

        public ShoesController(IMapper mapper, IShoesService shoesService)
        {
            this.mapper = mapper;
            this.shoesService = shoesService;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var shoes = await this.shoesService.GetAllAsync();

            var filteredShoes = HttpContext.Request.Query.GetFilteredShoes(shoes);

            var shoesModels = filteredShoes.Select(s => this.mapper.Map<ShoeViewModel>(s)).ToList();

            var shoesCollection = new ShoesAllCollectionViewModel { Shoes = shoesModels };

            return this.View(shoesCollection);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var shoe = await this.shoesService.GetByIdAsync(id);

            if (shoe == null)
            {
                return this.Redirect("/");
            }

            var shoeViewModel = this.mapper.Map<ShoeDetailsViewModel>(shoe);

            return this.View(shoeViewModel);
        }
    }
}
