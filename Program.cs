using ReqResApi.API.Interfaces;
using ReqResApi.BusinessLayer;
using ReqResApi.Helper;
using ReqResApi.IoC;
//IConfiguration configuration = new ConfigurationBuilder()
//                            .AddJsonFile("appsettings.json")
//                            .Build();
var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
DependancyContainer.RegisterClients(builder.Services, builder.Configuration);
DependancyContainer.RegisterServices(builder.Services);
//builder.Services.AddHttpClient<IUserService, UserService>();
//builder.Services.AddStackExchangeRedisCache(options =>
//{
//    options.Configuration = configuration["ReqRes:ReqResUri"];
//});

//var DefaultApi = builder.Configuration.GetValue<string>("ReqRes:ReqResUri");

//builder.Services.AddScoped(sp =>
//    new HttpClient { BaseAddress = new Uri(DefaultApi) });

//builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    var schemaHelper = new SwashbuckleSchemaHelper();
    options.CustomSchemaIds(type => schemaHelper.GetSchemaId(type));
}); 

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        //c.SwaggerEndpoint("https://reqres.in/api", "Student Services Api");
        //c.RoutePrefix = "studentservice/api/swagger";
    });
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
