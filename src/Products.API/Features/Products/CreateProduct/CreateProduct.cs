namespace Products.API.Features.Products.CreateProduct;

public record CreateProductCommand(string Name, string Description, decimal Price) : IRequest<CreateProductResult>;
public record CreateProductResult(Guid Id);

public class Validator : AbstractValidator<CreateProductCommand>
{
    public Validator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
        RuleFor(x => x.Description).NotEmpty().WithMessage("Description is required");
        RuleFor(x => x.Price).GreaterThan(0).WithMessage("Price must be greater than zero");
    }
}

internal sealed class CreateProductCommandHandler(AppDbContext _context)
    : IRequestHandler<CreateProductCommand, CreateProductResult>
{
    public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
    {
        var product = new Product
        {
            Id = Guid.NewGuid(),
            Name = command.Name,
            Description = command.Description,
            Price = command.Price,
        };

        _context.Add(product);

        await _context.SaveChangesAsync(cancellationToken);

        return new CreateProductResult(product.Id);
    }
}

