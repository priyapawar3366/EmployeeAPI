using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using EmployeeAPI.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>(options => 
{
    string tenantId = "79bf4280-6146-4a62-af65-65dce613ecaf";
    string clientId = "ba7e1986-4099-4a8a-aed3-0258561fa768";
    string clientSecret = "9HL8Q~NobzA7ZFEd6eMO3ZscLsYFy5iTGChC2bFq";

    string keyvaultUrl = "https://appkeyvault30002.vault.azure.net/";
    string secretName = "dbconnectionstring";

    ClientSecretCredential clientSecretCredential = new ClientSecretCredential(tenantId, clientId, clientSecret);
    SecretClient secretClient = new SecretClient(new Uri(keyvaultUrl), clientSecretCredential);

    var secret = secretClient.GetSecret(secretName);

    string connectionString = secret.Value.Value;

    options.UseSqlServer(connectionString);
});
builder.Services.AddCors(option => option.AddPolicy(name: "EmployeeOrigins",
    policy =>
    {
        policy.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader();
    })
);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("EmployeeOrigins");
app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();
