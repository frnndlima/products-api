namespace Products.API.Features.Products.GetProducts;
public record GetProductsQuery : IRequest<GetProductsResult>;
public record GetProductsResult(IEnumerable<Product> Products);

internal sealed class GetProductsHandler(AppDbContext _context) : IRequestHandler<GetProductsQuery, GetProductsResult>
{
    public async Task<GetProductsResult> Handle(GetProductsQuery request, CancellationToken cancellationToken)
    {
        var products = await _context.Products
            .AsNoTracking()
            .OrderBy(p => p.Name)
            .ToListAsync(cancellationToken);

        return new GetProductsResult(products);
    }
}

