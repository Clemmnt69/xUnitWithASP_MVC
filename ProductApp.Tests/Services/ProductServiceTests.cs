using Moq;

public class ProductServiceTests
{
    [Fact]
    public void AddProduct_ShouldAddProductToRepository()
    {
        // Préparer : Mock ProductRepository pour tester l'ajout de produit
        var productRepositoryMock = new Mock<ProductRepository>();
        var productService = new ProductService(productRepositoryMock.Object);

        var product = new Product { Id = 1, Name = "New Product", Price = 20 };

        // Agir : Appeler AddProduct
        productService.AddProduct(product);

        // Vérifier : AddProduct est appelé une fois avec le bon produit
        productRepositoryMock.Verify(repo => repo.AddProduct(product), Times.Once);
    }

    [Fact]
    public void GetProduct_ShouldReturnProduct_WhenProductExists()
    {
        // Préparer : Mock ProductRepository pour simuler un produit existant
        var productRepositoryMock = new Mock<ProductRepository>();
        productRepositoryMock.Setup(repo => repo.GetProductById(1))
                             .Returns(new Product { Id = 1, Name = "Existing Product", Price = 15 });

        var productService = new ProductService(productRepositoryMock.Object);

        // Agir : Appeler GetProduct
        var product = productService.GetProduct(1);

        // Vérifier : Le produit retourné n'est pas null et correspond
        Assert.NotNull(product);
        Assert.Equal("Existing Product", product.Name);
    }

    [Fact]
    public void AddProduct_ShouldThrowArgumentNullException_WhenProductIsNull()
    {
        // Préparer : Mock ProductRepository pour tester une exception
        var productRepositoryMock = new Mock<ProductRepository>();
        var productService = new ProductService(productRepositoryMock.Object);

        // Agir et Vérifier : Vérifie qu'une ArgumentNullException est levée
        Assert.Throws<ArgumentNullException>(() => productService.AddProduct(null));
    }
}
