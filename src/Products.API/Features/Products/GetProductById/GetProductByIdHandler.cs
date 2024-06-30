using Products.API.Shared.Exceptions;

namespace Products.API.Features.Products.GetProductById;

public record GetProductByIdQuery(Guid Id) : IRequest<GetProductByIdResult>;
public record GetProductByIdResult(Product Product);

internal class GetProductByIdQueryHandler
    (AppDbContext _context)
    : IRequestHandler<GetProductByIdQuery, GetProductByIdResult>
{
    public async Task<GetProductByIdResult> Handle(GetProductByIdQuery query, CancellationToken cancellationToken)
    {
        var product = await _context.FindAsync<Product>(query.Id, cancellationToken);

        return product is null ? throw new NotFoundException("Product not found") : new GetProductByIdResult(product);
    }
}
