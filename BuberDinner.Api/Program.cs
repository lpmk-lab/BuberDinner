using BuberDinner.Application;
using BuberDinner.infrastructure;

var builder = WebApplication.CreateBuilder(args);
{
builder.Services.AddApplication();
builder.Services.AddInfrastructure();
builder.Services.AddControllers();
}


var app = builder.Build();{
    
app.UseHttpsRedirection();
app.MapControllers();
app.Run();

}
