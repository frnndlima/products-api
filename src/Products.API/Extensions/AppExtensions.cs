﻿namespace Products.API.Extensions;

public static class AppExtension
{
    public static void ConfigureDevEnvironment(this WebApplication app)
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    public static void ConfigureCarter(this WebApplication app)
        => app.MapCarter();

    public static void ConfigureExceptionHandler(this WebApplication app)
    {
        app.UseExceptionHandler(options => { });
    }
}