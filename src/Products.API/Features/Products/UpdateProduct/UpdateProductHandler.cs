using Products.API.Shared.Exceptions;

namespace Products.API.Features.Products.UpdateProduct;

public record UpdateProductCommand(Guid Id, string Name, string Description, decimal Price)
    : IRequest<UpdateProductResult>;
public record UpdateProductResult(bool IsSuccess);

public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
{
    public UpdateProductCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty().WithMessage("Product Id is required");
        RuleFor(c => c.Name).NotEmpty().WithMessage("Name is required")
            .Length(2, 150).WithMessage("Name must be between 2 and 150 characters");
        RuleFor(c => c.Price)
            .GreaterThan(0).WithMessage("Price must be greater than 0");
    }
}

internal class UpdateProductCommandHandler
    (AppDbContext _context)
    : IRequestHandler<UpdateProductCommand, UpdateProductResult>
{
    public async Task<UpdateProductResult> Handle(UpdateProductCommand command, CancellationToken cancellationToken)
    {
        var product = await _context.FindAsync<Product>(command.Id, cancellationToken);

        if (product is null)
            throw new NotFoundException("Product not found");

        product.Id = command.Id;
        product.Name = command.Name;
        product.Description = command.Description;
        product.Price = command.Price;

        _context.Update(product);
        await _context.SaveChangesAsync(cancellationToken);

        return new UpdateProductResult(true);
    }
}
