using CloudDB_Assignment2.Data;
using CloudDB_Assignment2.Data.Interfaces;
using CloudDB_Assignment2.Data.Repos;
using CloudDB_Assignment2.Endpoints;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddDbContext<CustomerContext>(options =>
{
    options.UseCosmos("https://assignmenttwo.documents.azure.com:443/",
        "lqAqwo820WE445cqg7kARoNYVLULPPd1XGphhSAOy8Np902eNOR7AgXOS00fhGdyWk4ikmIv1aMrACDb2tZqTg==",
        "CustomerDB");
});

builder.Services.AddScoped<ICustomerRepo, CustomerRepo>();

var app = builder.Build();

app.MapCustomerEndpoints();


app.Run();
