using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shoepify.Domain;
using Shoepify.Services.Contracts;
using Shoepify.Web.Areas.Administration.Models.Colors;
using Shoepify.Web.Areas.Administration.Models.Sizes;

namespace Shoepify.Web.Areas.Administration.Controllers
{
    public class SizesController : AdministrationController
    {
        private readonly IMapper mapper;
        private readonly ISizesService sizesService;

        public SizesController(IMapper mapper, ISizesService sizesService)
        {
            this.mapper = mapper;
            this.sizesService = sizesService;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SizeCreateInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            Size size;
            try
            {
                size = this.mapper.Map<Size>(model);
                await this.sizesService.CreateAsync(size);
            }
            catch (DbUpdateException)
            {
                return this.View(model);
            }

            return this.RedirectToAction("Details", "Sizes", new { area = "", id = size.Id });
        }
    }
}