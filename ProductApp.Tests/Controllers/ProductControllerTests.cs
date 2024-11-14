using Moq;
using Microsoft.AspNetCore.Mvc;


public class ProductControllerTests
{
    [Fact]
    public void Details_ShouldReturnView_WhenProductExists()
    {
        // Préparer : Créer un mock de ProductRepository et ProductService
        var productRepositoryMock = new Mock<ProductRepository>();
        productRepositoryMock.Setup(repo => repo.GetProductById(1)).Returns(new Product { Id = 1, Name = "Test Product", Price = 10 });
        
        var productService = new ProductService(productRepositoryMock.Object);
        var controller = new ProductController(productService);

        // Agir : Appeler Details
        var result = controller.Details(1);

        // Vérifier : Vérifie que le résultat est une vue contenant le produit
        var viewResult = Assert.IsType<ViewResult>(result);
        var model = Assert.IsAssignableFrom<Product>(viewResult.Model);
        Assert.Equal("Test Product", model.Name);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public void Details_ShouldReturnNotFound_WhenProductDoesNotExist(int invalidId)
    {
        // Préparer : Configurer ProductRepository pour renvoyer null
        var productRepositoryMock = new Mock<ProductRepository>();
        productRepositoryMock.Setup(repo => repo.GetProductById(invalidId)).Returns((Product)null);

        var productService = new ProductService(productRepositoryMock.Object);
        var controller = new ProductController(productService);

        // Agir : Appeler Details avec un ID invalide
        var result = controller.Details(invalidId);

        // Vérifier : Le résultat est NotFound
        Assert.IsType<NotFoundResult>(result);
    }

}
