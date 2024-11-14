public class ProductRepository
{
    private readonly List<Product> _products = new List<Product>();

    public Product GetProductById(int id)
    {
        return _products.FirstOrDefault(p => p.Id == id);
    }

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }
}
