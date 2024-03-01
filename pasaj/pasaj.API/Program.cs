using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using pasaj.Extensions;
using System.Text;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("db");
builder.Services.AddNecessaryIoC(connectionString);
builder.Services.AddCors(option => option.AddPolicy("allow", builder =>
{
    builder.AllowAnyHeader();
    builder.AllowAnyMethod();
    builder.AllowAnyOrigin();

    /*
     *  http://www.turkcell.com.tr 
     *  https://www.turkcell.com.tr 
     *  https://order.turkcell.com.tr 
     *  https://order.turkcell.com.tr:8082 
     *  
     */
}));

//builder.Services.AddAuthentication("Basic").AddSc
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(option =>
                {
                    option.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuer = true,
                        ValidIssuer = "main.turkcell",
                        ValidateAudience = true,
                        ValidAudience = "client.turkcell",
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Bu-cümle-kritik-bir-cümledir-ona-göre")),


                    };
                });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("allow");
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
