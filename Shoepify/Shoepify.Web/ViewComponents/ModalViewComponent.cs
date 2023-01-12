using Microsoft.AspNetCore.Mvc;
using Shoepify.Web.Models.Modal;

namespace Shoepify.Web.ViewComponents
{
    public class ModalViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(int shoeId, string brand, string model)
        {
            var modalVM = new ModalViewModel()
            {
                ShoeId = shoeId,
                ProductName = $"{brand} {model}"
            };

            return View(modalVM);
        }
    }
}
