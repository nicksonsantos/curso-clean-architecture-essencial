using AutoMapper;
using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;

namespace CleanArchMvc.Application.Services;

public class ProductService : IProductService
{
    private IProductRepository _productRespository;
    private readonly IMapper _mapper;

    public ProductService(IProductRepository productRespository, IMapper mapper)
    {
        _productRespository = productRespository ??
            throw new ArgumentNullException(nameof(productRespository));

        _mapper = mapper;
    }
    public async Task Add(ProductDTO product)
    {
        var productEntity = _mapper.Map<Product>(product);
        await _productRespository.CreateAsync(productEntity);
    }

    public async Task<ProductDTO> GetById(int? id)
    {
        var productEntity = await _productRespository.GetByIdAsync(id);
        return _mapper.Map<ProductDTO>(productEntity);
    }

    public async Task<ProductDTO> GetProductCategory(int? id)
    {
        var productEntity = await _productRespository.GetProductCategoryAsync(id);
        return _mapper.Map<ProductDTO>(productEntity);
    }

    public async Task<IEnumerable<ProductDTO>> GetProducts()
    {
        var productsEntity = await _productRespository.GetProductsAsync();
        return _mapper.Map<IEnumerable<ProductDTO>>(productsEntity);
    }

    public async Task Remove(int? id)
    {
        var productEntity = _productRespository.GetByIdAsync(id).Result;
        await _productRespository.RemoveAsync(productEntity);
    }

    public async Task Update(ProductDTO product)
    {
        var productEntity = _mapper.Map<Product>(product);
        await _productRespository.UpdateAsync(productEntity);
    }
}
