


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(option =>
{
    option.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Country Exchange API demo", Version = "v1" });
});

//builder.Services.AddCors(options=>{
//    options.AddPolicy("AllowOrigins",builder=>builder.WithOrigins("http://localhost:3000").AllowAnyHeader());
//});
var app = builder.Build();
//app.UseCors("AllowOrigins");
app.UseSwagger();
app.UseSwaggerUI(c => 
{ 
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "API Demo");
});

app.MapGet("/overview/exchanges",async() =>
{
    using var httpClient = new HttpClient();
    using var response = await httpClient.GetAsync("https://api.coingecko.com/api/v3/exchanges");
    string apiResponse = await response.Content.ReadAsStringAsync();
    return apiResponse;
});
app.MapGet("/overview/continent/:countrycode",async () => 
{

    using var httpClient = new HttpClient();
    using var response = await httpClient.GetAsync("https://www.worldpop.org/rest/data/pop/wpgp?iso3=AUS");
    string apiResponse = await response.Content.ReadAsStringAsync();
    return apiResponse;
});
app.MapGet("/overview/flag/:countrycode", async () =>
{

    using var httpClient = new HttpClient();
    using var response = await httpClient.GetAsync("https://www.worldpop.org/rest/data/pop/wpgp?iso3=AUS");
    string apiResponse = await response.Content.ReadAsStringAsync();
    return apiResponse;
});

app.Run();
