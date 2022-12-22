
namespace CleanArchMvc.Domain.Tests
{
    public class ProductUnitTest1
    {
        [Fact]
        public void CreateProduct_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", 9.99m, 99, "product image");
            action.Should()
                .NotThrow<CleanArchMvc.Domain.Validation.DomainExceptionValidation>();
        }

        [Fact]
        public void CreateProduct_NegativeIdValue_DomainExceptionInvalidId()
        {
            Action action = () => new Product(-1, "Product Name", "Product Description", 9.99m, 99, "product image");
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid Id value.");
        }

        [Fact]
        public void CreateProduct_ShortNameValue_DomainExceptionShortName()
        {
            Action action = () => new Product(1, "Pr", "Product Description", 9.99m, 99, "product image");
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid name. Too short. Minimum 3 characters.");
        }

        [Fact]
        public void CreateProduct_MissingDescription_DomainExceptionRequiredDescription()
        {
            Action action = () => new Product(1, "Product Name", "", 9.99m, 99, "product image");
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid description. Description is required.");
        }

        [Fact]
        public void CreateProduct_WithNullDescription_DomainExceptionRequiredDescription()
        {
            Action action = () => new Product(1, "Product Name", null, 9.99m, 99, "product image");
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid description. Description is required.");
        }

        [Fact]
        public void CreateProduct_ShortDescriptionValue_DomainExceptionShortDescription()
        {
            Action action = () => new Product(1, "Product Name", "Prod", 9.99m, 99, "product image");
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid description. Too short. Minimum 5 characters.");
        }

        [Fact]
        public void CreateProduct_NegativePriceValue_DomainExceptionInvalidPrice()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", -9.99m, 99, "product image");
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid price value.");
        }

        [Theory]
        [InlineData(-5)]
        public void CreateProduct_NegativeStockValue_DomainExceptionInvalidStock(int value)
        {
            Action action = () => new Product(1, "Product Name", "Product Description", 9.99m, value, "product image");
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid stock value.");
        }

        [Fact]
        public void CreateProduct_WithNullImageName_NoDomainException()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", 9.99m, 99, null);
            action.Should()
                .NotThrow<CleanArchMvc.Domain.Validation.DomainExceptionValidation>();
        }

        [Fact]
        public void CreateProduct_WithNullImageName_NoNullReferenceException()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", 9.99m, 99, null);
            action.Should()
                .NotThrow<NullReferenceException>();
        }

        [Fact]
        public void CreateProduct_WithEmptyImageName_NoDomainException()
        {
            
            Action action = () => new Product(1, "Product Name", "Product Description", 9.99m, 99, "");
            action.Should()
                .NotThrow<CleanArchMvc.Domain.Validation.DomainExceptionValidation>();
        }

        [Fact]
        public void CreateProduct_LongImageName_DomainExceptionLongImageName()
        {
            System.Text.StringBuilder sb = new();
            sb.Append('a', 251);
            string invalidProductImageName = sb.ToString();

            Action action = () => new Product(1, "Product Name", "Product Description", 9.99m, 99, invalidProductImageName);
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid image name. Too long. Maximum 250 characters.");
        }
    }
}