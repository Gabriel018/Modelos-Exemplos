using ModeloDeConsumoApplication.Queries;

var builder = WebApplication.CreateBuilder(args);

var configBearer = builder.Configuration;
_ = configBearer["TMDb:BearerToken"];

var uriConfiguration = builder.Configuration;
_ = uriConfiguration["UriConfiguration"];

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
