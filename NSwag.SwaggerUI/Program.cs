namespace NSwag.SwaggerUI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddOpenApiDocument();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                // Add OpenAPI 3.0 document serving middleware
                // Available at: http://localhost:<port>/swagger/v1/swagger.json
                app.UseOpenApi();

                // Add web UIs to interact with the document
                // Available at: http://localhost:<port>/swagger
                app.UseSwaggerUi(); // UseSwaggerUI Protected by if (env.IsDevelopment())

                // Add ReDoc UI to interact with the document
                // Available at: http://localhost:<port>/redoc
                app.UseReDoc(options =>
                {
                    options.Path = "/api/v1/redoc";
                });
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
