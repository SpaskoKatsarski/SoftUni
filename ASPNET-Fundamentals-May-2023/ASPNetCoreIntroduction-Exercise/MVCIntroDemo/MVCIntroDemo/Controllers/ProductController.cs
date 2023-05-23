namespace MVCIntroDemo.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    using MVCIntroDemo.Models.Product;

    public class ProductController : Controller
    {
        private readonly IEnumerable<ProductViewModel> products = new List<ProductViewModel>()
        {
            new ProductViewModel()
            {
                Id = 1,
                Name = "Cheese",
                Price = 7.00
            },
            new ProductViewModel()
            {
                Id = 2,
                Name = "Ham",
                Price = 5.50
            },
            new ProductViewModel()
            {
                Id = 3,
                Name = "Bread",
                Price = 1.50
            }
        };

        public IActionResult All()
        {
            return View(products);
        }
    }
}
