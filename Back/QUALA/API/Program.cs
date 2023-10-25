using API.DI;
using API.Middelware;
using Application.DI;
using Infraestructure.DI;

var builder = WebApplication.CreateBuilder(args);
var myCorsName = "AllowSpecificOrigin";
builder.Services.AddCors(options =>
{
    options.AddPolicy(myCorsName, builder =>
    {
        builder.WithOrigins("*")
               .AllowAnyHeader()
               .AllowAnyMethod();
    });
});



builder.Services.AddPresentation()
                .AddInfrastructure(builder.Configuration)
                .AddApplication();

var app = builder.Build();

app.UseCors(myCorsName);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    //app.ApplyMigration();
}

app.UseExceptionHandler("/error");

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseMiddleware<GlobalExceptionHandlingMiddelware>();

app.MapControllers();

app.Run();
