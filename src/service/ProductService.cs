using Microsoft.EntityFrameworkCore;
using test_net.src.data;
using test_net.src.dto;
using test_net.src.model;
using test_net.src.service.@interface;

namespace test_net.src.service;

public class ProductService(AppDbContext context) : IProductService
{
    private readonly AppDbContext _context = context;

    public async Task<IEnumerable<ProductDto>> GetAllAsync()
    {
        return await _context.Products
            .Select(p => new ProductDto(p.Id, p.Name, p.Price))
            .ToListAsync();
    }

    public async Task<ProductDto?> GetByIdAsync(int id)
    {
        var product = await _context.Products.FindAsync(id);
        if (product == null) return null;
        return new ProductDto(product.Id, product.Name, product.Price);
    }

    public async Task<ProductDto> CreateAsync(CreateProductDto dto)
    {
        var product = new Product { Name = dto.Name, Price = dto.Price };
        _context.Products.Add(product);
        await _context.SaveChangesAsync();
        return new ProductDto(product.Id, product.Name, product.Price);
    }
}
