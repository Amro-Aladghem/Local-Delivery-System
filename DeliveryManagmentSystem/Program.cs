using FluentValidation;
using Shared;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddOpenApi();


builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddValidatorsFromAssembly(typeof(AssemblyRefference).Assembly);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
