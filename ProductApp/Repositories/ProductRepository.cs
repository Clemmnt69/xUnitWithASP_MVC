public class ProductRepository
{
    private readonly List<Product> _products = new List<Product>();

    public virtual Product GetProductById(int id)
    {
        return _products.FirstOrDefault(p => p.Id == id);
    }

    public virtual void AddProduct(Product product)
    {
        _products.Add(product);
    }
}
