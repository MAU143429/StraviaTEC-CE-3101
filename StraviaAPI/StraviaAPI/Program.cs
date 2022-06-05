using StraviaAPI.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<SQLDB>();
builder.Services.AddScoped<Mongo>();

builder.Services.AddControllers();

// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy
    (
        builder => builder
            .AllowAnyMethod()
            .AllowAnyHeader()
            .SetIsOriginAllowed(x => true)
            .AllowCredentials()
    );
});

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

app.UseCors();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
