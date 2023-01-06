using AutoMapper;
using Microsoft.AspNetCore.Mvc;
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

            var shoesModels = shoes.Select(s => this.mapper.Map<ShoeViewModel>(s)).ToList();

            var shoesCollection = new ShoesAllCollectionViewModel { Shoes = shoesModels };

            return this.View(shoesCollection);
        }
    }
}
