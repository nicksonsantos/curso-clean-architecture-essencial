using AutoMapper;
using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Application.Products.Commands;
using CleanArchMvc.Application.Products.Queries;
using MediatR;

namespace CleanArchMvc.Application.Services;

public class ProductService : IProductService
{
    // private IProductRepository _productRespository;
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;

    public ProductService(IMediator mediator, IMapper mapper)
    {
        // _productRespository = productRespository ??
        //     throw new ArgumentNullException(nameof(productRespository));
        _mediator = mediator;
        _mapper = mapper;        
    }
    public async Task Add(ProductDTO product)
    {
        // var productEntity = _mapper.Map<Product>(product);
        // await _productRespository.CreateAsync(productEntity);

        var productCreateCommand = _mapper.Map<ProductCreateCommand>(product);        
        await _mediator.Send(productCreateCommand);

    }

    public async Task<ProductDTO> GetById(int? id)
    {
        // var productEntity = await _productRespository.GetByIdAsync(id);
        // return _mapper.Map<ProductDTO>(productEntity);

        var productByIdQuery = new GetProductByIdQuery(id.Value);

        if (productByIdQuery == null)
            throw new Exception($"Entity could not be loaded.");

        var result = await _mediator.Send(productByIdQuery);

        return _mapper.Map<ProductDTO>(result);
    }

    public async Task<ProductDTO> GetProductCategory(int? id)
    {
        // var productEntity = await _productRespository.GetProductCategoryAsync(id);
        // return _mapper.Map<ProductDTO>(productEntity);

        var productByIdQuery = new GetProductByIdQuery(id.Value);

        if (productByIdQuery == null)
            throw new Exception($"Entity could not be loaded.");

        var result = await _mediator.Send(productByIdQuery);

        return _mapper.Map<ProductDTO>(result);
    }

    public async Task<IEnumerable<ProductDTO>> GetProducts()
    {
        // var productsEntity = await _productRespository.GetProductsAsync();
        // return _mapper.Map<IEnumerable<ProductDTO>>(productsEntity);

        var productsQuery = new GetProductsQuery();
        
        if (productsQuery == null)
            throw new Exception($"Entity could not be loaded.");

        var result = await _mediator.Send(productsQuery);

        return _mapper.Map<IEnumerable<ProductDTO>>(result);
    }

    public async Task Remove(int? id)
    {
        // var productEntity = _productRespository.GetByIdAsync(id).Result;
        // await _productRespository.RemoveAsync(productEntity);

        var productRemoveCommand = new ProductRemoveCommand(id.Value);
        if (productRemoveCommand == null)
            throw new Exception($"Entity could not be loaded");

        await _mediator.Send(productRemoveCommand);
    }

    public async Task Update(ProductDTO product)
    {
        // var productEntity = _mapper.Map<Product>(product);
        // await _productRespository.UpdateAsync(productEntity);

        var productUpdateCommand = _mapper.Map<ProductUpdateCommand>(product);        
        await _mediator.Send(productUpdateCommand);
    }
}
