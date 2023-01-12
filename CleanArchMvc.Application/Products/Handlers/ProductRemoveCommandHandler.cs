using CleanArchMvc.Application.Products.Commands;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using MediatR;

namespace CleanArchMvc.Application.Products.Handlers;

public class ProductRemoveCommandHandler : IRequestHandler<ProductRemoveCommand, Product>
{
    private readonly IProductRepository _productRepository;

    public ProductRemoveCommandHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository ??
        throw new ArgumentNullException(nameof(productRepository));        
    }

    public async Task<Product> Handle(ProductRemoveCommand request, CancellationToken cancellationToken)
    {
        var product = await _productRepository.GetByIdAsync(request.Id);

        if (product == null)
        {
            throw new ApplicationException($"Error could not be found.");
        }
        else
        {
            var result = await _productRepository.RemoveAsync(product);
            return result;
        }
    }
}
