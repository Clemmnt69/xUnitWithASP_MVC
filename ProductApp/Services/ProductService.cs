public class ProductService
{
    private readonly ProductRepository _productRepository;

    public ProductService(ProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public Product GetProduct(int id)
    {
        return _productRepository.GetProductById(id);
    }

    public void AddProduct(Product product)
    {
        if (product == null)
            throw new ArgumentNullException(nameof(product));

        _productRepository.AddProduct(product);
    }
}
