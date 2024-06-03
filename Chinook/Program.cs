using Chinook.Extensions;
using Chinook.Middlewares;

var builder = WebApplication.CreateBuilder(args);

DatabaseConfiguration.Configure(builder.Services, builder.Configuration);
ServiceConfiguration.Configure(builder.Services, builder.Configuration);

var app = builder.Build();

MiddlewareConfiguration.Configure(app);

app.Run();
