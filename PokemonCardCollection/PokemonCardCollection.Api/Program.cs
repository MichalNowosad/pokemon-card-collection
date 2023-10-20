using PokemonCardCollection.Api;

var builder = WebApplication.CreateBuilder(args);
var app = builder
    .ConfigureServices()
    .ConfigurePipeline()
    .ConfigureDatabase();

app.Run();
