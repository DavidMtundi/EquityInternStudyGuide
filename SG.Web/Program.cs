using Microsoft.EntityFrameworkCore;
using SG.Data.Entities;
using SG.Data.Entities.SG.Data.Entities;
using SG.Repo;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContextPool<ApplicationContext>
    (options => options.UseSqlServer(builder.Configuration.GetConnectionString("InternStudyGuide"),
    sqlServerOptionsAction: sqlOptions =>
    {
        sqlOptions.EnableRetryOnFailure();
    }));
builder.Services.AddScoped<IRepository<InternModel>, Repository<InternModel>>();
builder.Services.AddScoped<IRepository<ContentCreatorModel>, Repository<ContentCreatorModel>>();
builder.Services.AddScoped<IRepository<UploadModel>, Repository<UploadModel>>();
builder.Services.AddScoped<IRepository<LearningMaterialModel>, Repository<LearningMaterialModel>>();




var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
