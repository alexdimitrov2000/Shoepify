using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shoepify.Domain;
using Shoepify.Services.Contracts;
using Shoepify.Web.Areas.Administration.Models.Categories;
using Shoepify.Web.Areas.Administration.Models.Colors;

namespace Shoepify.Web.Areas.Administration.Controllers
{
    public class CategoriesController : AdministrationController
    {
        private readonly IMapper mapper;
        private readonly ICategoriesService categoriesService;
        public CategoriesController(IMapper mapper, ICategoriesService categoriesService)
        {
            this.mapper = mapper;
            this.categoriesService = categoriesService;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CategoryCreateInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            Category category;
            try
            {
                category = this.mapper.Map<Category>(model);
                await this.categoriesService.CreateAsync(category);
            }
            catch (DbUpdateException)
            {
                return this.View(model);
            }

            return this.RedirectToAction("All", "Shoes", new { area = "" });
        }
    }
}
