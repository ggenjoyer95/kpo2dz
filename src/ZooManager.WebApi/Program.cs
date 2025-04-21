using ZooManager.Core.Ports;
using ZooManager.Persistence.Adapters;
using ZooManager.UseCases.Contracts;
using ZooManager.UseCases.Services;
using ZooManager.UseCases.EventHandlers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IAnimalRepository, InMemoryAnimalRepository>();
builder.Services.AddSingleton<IEnclosureRepository, InMemoryEnclosureRepository>();
builder.Services.AddSingleton<IFeedingScheduleRepository, InMemoryFeedingScheduleRepository>();

builder.Services.AddScoped<IAnimalTransferService, AnimalTransferService>();
builder.Services.AddScoped<IFeedingManager, FeedingManager>();
builder.Services.AddScoped<IZooStatisticsProvider, ZooStatisticsProvider>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

_ = new AnimalMovedEventHandler();
_ = new FeedingTimeEventHandler();
_ = new EnclosureCleanedEventHandler();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();
