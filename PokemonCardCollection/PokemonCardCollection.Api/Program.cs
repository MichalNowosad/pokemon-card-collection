using PokemonCardCollection.Api;

var builder = WebApplication.CreateBuilder(args);
var app = builder
    .ConfigureServices()
    .ConfigurePipeline();

app.MapGet("/", () => "Hello World!");

app.Run();
