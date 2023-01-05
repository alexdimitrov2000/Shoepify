using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shoepify.Domain;
using Shoepify.Services.Contracts;
using Shoepify.Web.Areas.Administration.Models.Colors;

namespace Shoepify.Web.Areas.Administration.Controllers
{
    public class ColorsController : AdministrationController
    {
        private readonly IMapper mapper;
        private readonly IColorsService colorsService;

        public ColorsController(IMapper mapper, IColorsService colorsService)
        {
            this.mapper = mapper;
            this.colorsService = colorsService;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ColorCreateInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            Color color;
            try
            {
                color = this.mapper.Map<Color>(model);
                await this.colorsService.CreateAsync(color);
            }
            catch (DbUpdateException)
            {
                return this.View(model);
            }

            return this.RedirectToAction("Details", "Colors", new { area = "", id = color.Id });
        }
    }
}
