using Moresand.ImageManipulation.Api;

var builder = WebApplication.CreateBuilder(args);
ConfigureService();

var app = builder.Build();
Configure();
app.Run();

void ConfigureService()
{
    builder.Services.AddControllersCustom(builder.Configuration);
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
}

void Configure()
{
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();
}