using DeliveryManagmentSystem.Extentions;
using DeliveryManagmentSystem.Extentions.Middlewares;
using FluentValidation;
using Shared;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddOpenApi();

builder.Services.ConfigureServices() ;

builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddValidatorsFromAssembly(typeof(AssemblyRefference).Assembly);
builder.Services.ConfigureJWT(builder.Configuration);
builder.Services.AddJWTConfiguration(builder.Configuration);

builder.Services.AddControllers()
    .AddApplicationPart(typeof(Presentation.AssemblyReference).Assembly);

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("PreRegisterUser", policy =>
    {
        policy.RequireRole("PreRegister");
        policy.RequireClaim(ClaimTypes.NameIdentifier);
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseMiddleware<CookiesMiddleware>();
//app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
