namespace MVCIntroDemo.Controllers
{
    using System.Diagnostics;
    using System.Text;
    using System.Text.Json;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Net.Http.Headers;

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

        [ActionName("My-Products")]
        public IActionResult All(string keyword)
        {
            if (keyword != null)
            {
                var correspondingProducts = this.products.Where(p => p.Name.ToLower().Contains(keyword.ToLower()));

                if (!correspondingProducts.Any())
                {
                    return BadRequest();
                }

                return View(correspondingProducts);
            }

            return View(this.products);
        }

        public IActionResult ById(int id)
        {
            var productModel = this.products.FirstOrDefault(p => p.Id == id);

            if (productModel == null)
            {
                return BadRequest();
            }

            return View(productModel);
        }

        public IActionResult AllAsJson()
        {
            var options = new JsonSerializerOptions()
            {
                WriteIndented = true
            };

            return Json(this.products, options);
        }

        public IActionResult AllAsText()
        {
            var sb = new StringBuilder();

            foreach (var product in this.products)
            {
                sb.AppendLine($"Product {product.Id}: {product.Name} - {product.Price:f2} lv.");
            }

            return Content(sb.ToString().TrimEnd());
        }

        public IActionResult AllAsTextFile()
        {
            var sb = new StringBuilder();

            foreach (var product in this.products)
            {
                sb.AppendLine($"Product {product.Id}: {product.Name} - {product.Price:f2} lv.");
            }

            Response.Headers.Add(HeaderNames.ContentDisposition, @"attachment;filename=products.txt");

            return File(Encoding.UTF8.GetBytes(sb.ToString().TrimEnd()), "text/plain");
        }
    }
}
