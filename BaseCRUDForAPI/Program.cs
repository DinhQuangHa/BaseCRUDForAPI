using BaseCRUDForAPI.Core.Interfaces.RepositoryInterfaces;
using BaseCRUDForAPI.Core.Interfaces.RepositoryInterfaces.Base;
using BaseCRUDForAPI.Core.Interfaces.ServicesInterfaces;
using BaseCRUDForAPI.Core.Interfaces.ServicesInterfaces.Base;
using BaseCRUDForAPI.Infrastructure;
using BaseCRUDForAPI.Infrastructure.DbContext;
using BaseCRUDForAPI.Infrastructure.Repositories;
using BaseCRUDForAPI.Infrastructure.Repositories.Base;
using BaseCRUDForAPI.Infrastructure.Services;
using BaseCRUDForAPI.Infrastructure.Services.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
           .EnableSensitiveDataLogging()
           .LogTo(Console.WriteLine)
           .AddInterceptors(new QueryLoggingInterceptor())
           .ConfigureWarnings(warnings =>
           {
               warnings.Log(
                   (RelationalEventId.ConnectionOpened, LogLevel.Information),
                   (RelationalEventId.CommandCreating, LogLevel.Information),
                   (RelationalEventId.CommandCreated, LogLevel.Information),
                   (RelationalEventId.CommandExecuting, LogLevel.Information),
                   (RelationalEventId.CommandExecuted, LogLevel.Information),
                   (RelationalEventId.ConnectionClosed, LogLevel.Information)
               );
           }); ;
});
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddTransient(typeof(IUserRepository), typeof(UserRepository));
builder.Services.AddTransient(typeof(IBaseService<,,,>), typeof(BaseService<,,,>));
builder.Services.AddTransient(typeof(IUserSevice), typeof(UserService));
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
app.UseMiddleware<RequestTimingMiddleware>();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
