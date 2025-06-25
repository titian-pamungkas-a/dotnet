using EmptyProject.Models;
using Microsoft.Extensions.DependencyInjection;
using Scalar.AspNetCore;

namespace EmptyProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllers();
            builder.Services.AddOpenApi();
            //builder.Services.AddDbContext<Product>(opt => opt.UseInMemoryDatabase("TodoList"));
            var app = builder.Build();
            if (app.Environment.IsDevelopment())
            {
                //app.UseDeveloperExceptionPage();
                app.MapScalarApiReference();
                app.MapOpenApi();
            }
            app.MapGet("/", () => "Hello World!");
            app.MapControllers();

            app.Run();
        }
    }
}
