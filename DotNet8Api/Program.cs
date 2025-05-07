
namespace DotNet8Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            // builder.Services.AddEndpointsApiExplorer(); // required only for minimal APIs
            builder.Services.AddSwaggerGen(); // Add the Swagger generator to the services collection

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger(); // Enable the middleware for serving the generated JSON document at /swagger/v1/swagger.json
                app.UseSwaggerUI(); // Enable the middleware for an embedded version of the Swagger UI tool at /swagger
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
