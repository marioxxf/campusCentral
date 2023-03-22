using campusCentralApi.Interfaces;
using campusCentralApi.Models;
using campusCentralApi.Repositories;
using Microsoft.EntityFrameworkCore;

static bool ValidateApiKey(string apiKey)
{
    return apiKey == "secretKey";
}

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<UniversitySystemContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IUserAccountRepository, UserAccountRepository>();
builder.Services.AddScoped<ICourseRepository, CourseRepository>();
builder.Services.AddScoped<ITopicRepository, TopicRepository>();
builder.Services.AddScoped<IUserAccountCourseScheduleRepository, UserAccountCourseScheduleRepository>();
builder.Services.AddScoped<ITopicScheduleTimeRepository, TopicScheduleTimeRepository>();
builder.Services.AddScoped<IClassGroupRepository, ClassGroupRepository>();
builder.Services.AddHttpContextAccessor();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.Use(async (context, next) =>
{

    var apiKey = "";

    if(context.Request.Query["apiKey"] != "")
    {
        apiKey = context.Request.Query["apiKey"].ToString();
    }

    if (!ValidateApiKey(apiKey))
    {
        context.Response.StatusCode = 401;
        await context.Response.WriteAsync("Unauthorized");
        return;
    }

    await next();
});

app.MapControllers();

app.Run();