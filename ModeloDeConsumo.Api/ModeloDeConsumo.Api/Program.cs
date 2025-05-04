using ModeloDeConsumoApplication.Queries;

var builder = WebApplication.CreateBuilder(args);

var config = builder.Configuration;
var tmdbToken = config["TMDb:BearerToken"];

builder.Services.AddControllers();
builder.Services.AddOpenApi();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient();

builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssembly(typeof(ObterFilmesListaQuery).Assembly));

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.MapOpenApi();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
