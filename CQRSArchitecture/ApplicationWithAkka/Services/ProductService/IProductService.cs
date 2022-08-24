namespace ApplicationWithAkka.Services.ProductService
{
    using ApplicationWithAkka.ViewModels;

    public interface IProductService
    {
        void AddNewProduct(ProductAkkaViewModel product);
    }
}
