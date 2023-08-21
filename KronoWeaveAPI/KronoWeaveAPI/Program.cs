namespace KronoWeaveAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            string? MyAllowSpecificOrigins = "KronoWeave";

            builder.Services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                                  policy =>
                                  {
                                      policy.WithOrigins("https://localhost:4200", "http://localhost:4200", "https://localhost:7151", "http://localhost:7151", "http://localhost:8101", "http://localhost:8100")
                                      .WithHeaders("Access-Control-Allow-Origin: *")
                                      .AllowAnyHeader()
                                      .AllowAnyMethod()
                                      .WithMethods("PUT", "DELETE", "GET")
                                      .SetIsOriginAllowedToAllowWildcardSubdomains();
                                  });
            });


            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();
            
            app.UseCors();

            app.MapControllers();

            app.Run();
        }
    }
}
