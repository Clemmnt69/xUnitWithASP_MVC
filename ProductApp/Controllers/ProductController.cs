using Microsoft.AspNetCore.Mvc;

public class ProductController : Controller
{
    private readonly ProductService _productService;

    public ProductController(ProductService productService)
    {
        _productService = productService;
    }

    public IActionResult Details(int id)
    {
        var product = _productService.GetProduct(id);
        if (product == null) return NotFound();
        return View(product);
    }

    [HttpPost]
    public IActionResult Add(Product product)
    {
        if (ModelState.IsValid)
        {
            _productService.AddProduct(product);
            return RedirectToAction("Index");
        }
        return View(product);
    }
}
