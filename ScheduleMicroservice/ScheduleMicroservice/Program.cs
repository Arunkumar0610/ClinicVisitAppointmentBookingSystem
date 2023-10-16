using BusinessLogicLayer.Services.IServices;
using BusinessLogicLayer.Services;
using DataAccessLayer;
using DataAccessLayer.DataBase;
using Microsoft.Extensions.Options;
using Serilog;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using ScheduleMicroservice.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//Added MongoDB Connection
builder.Services.Configure<DataBaseSettings>(
                builder.Configuration.GetSection(nameof(DataBaseSettings)));
builder.Services.AddSingleton<IDataBaseSettings>(provider =>
provider.GetRequiredService<IOptions<DataBaseSettings>>().Value);
//Added dependency injection lifetime for UserService 
builder.Services.AddScoped<IScheduleService, ScheduleService>();
//Added AutoMapper
builder.Services.AddAutoMapper(typeof(MappingConfig));
//Added Serilog to write logs to a txt file
var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(configuration)
    .CreateLogger();
builder.Host.UseSerilog();
builder.Services.AddControllers();
//Added Jwt token Authentication
var key = builder.Configuration.GetValue<string>("Jwt:key");
builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key)),
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = true,
        ClockSkew=TimeSpan.Zero
    };
}); 
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

//Added options for passing Authorize jwt bearer token in Swagger
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n" +
        "Enter 'Bearer' [Space] and then your token in the text input below. \r\n\r\n" +
        "Example: \"Bearer 1234567abcdef\"",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Scheme = "Bearer"

    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement()
    {
        {
            new OpenApiSecurityScheme
            {
                Reference=new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                },
                Scheme="oauth2",
                Name="Bearer",
                In=ParameterLocation.Header
            },
            new List<string>()
        }
    });
});


var app = builder.Build();
app.UseMiddleware(typeof(ExceptionHandlingMiddleware));
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
}
app.UseCors(x =>
{
    x.WithOrigins("http://localhost:4200").AllowAnyHeader().AllowAnyMethod();
});
app.UseHttpsRedirection();

app.UseSerilogRequestLogging();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
