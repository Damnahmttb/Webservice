using ExceptionsService.MiddleWare;
using LoggingService.Database.Dbcontext;
using LoggingService.Loggers;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<LoggerDatabaseContext>();
builder.Services.AddTransient<IDatabaseLogger, DatabaseLogger>();
builder.Services.AddTransient<IEmailLogger, EmailLogger>();
builder.Services.AddTransient<ITextFileLogger, TextFileLogger>();
builder.Services.AddTransient<IEventLogger, EventLogger>();
builder.Services.AddTransient<CoreMiddleware>();
builder.Services.AddTransient<UserLevelMiddleware>();
builder.Services.AddTransient<CriticalUserMiddleware>();


var app = builder.Build();
app.UseMiddleware<CoreMiddleware>();
app.UseMiddleware<UserLevelMiddleware>();
app.UseMiddleware<CriticalUserMiddleware>();
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
