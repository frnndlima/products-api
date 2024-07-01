using BuildingBlocks.Exceptions.Handler;
using Products.API.Shared.Behaviors;

namespace Products.API.Extensions;

public static class BuilderExtensions
{
    public static void AddDocumentation(this WebApplicationBuilder builder)
    {
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(x => { x.CustomSchemaIds(n => n.FullName); });
    }

    public static void AddDataContexts(this WebApplicationBuilder builder)
    {
        builder.Services.AddDbContext<AppDbContext>(o =>
                o.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
    }

    public static void AddMediatr(this WebApplicationBuilder builder)
    {
        builder.Services.AddMediatR(c =>
        {
            c.RegisterServicesFromAssemblies(typeof(Program).Assembly);
            c.AddOpenBehavior(typeof(ExceptionHandlingPipelineBehavior<,>));
            c.AddOpenBehavior(typeof(RequestResponseLoggingBehavior<,>));
            c.AddOpenBehavior(typeof(ValidationPipelineBehavior<,>));

        });
    }

    public static void AddCarter(this WebApplicationBuilder builder) 
        => builder.Services.AddCarter();

    public static void AddValidators(this WebApplicationBuilder builder) 
        => builder.Services.AddValidatorsFromAssembly(typeof(Program).Assembly);

    public static void AddExceptionHandler(this WebApplicationBuilder builder) 
        => builder.Services.AddExceptionHandler<CustomExceptionHandler>();

    public static void AddHealthChecks(this WebApplicationBuilder builder)
        => builder.Services.AddHealthChecks().AddSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
}
