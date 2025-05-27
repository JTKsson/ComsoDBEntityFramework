using CloudDB_Assignment2.Data.Entities;
using CloudDB_Assignment2.Data.Interfaces;
using Microsoft.AspNetCore.Builder;

namespace CloudDB_Assignment2.Endpoints
{
    public static class CustomerEndpoints
    {

        public static WebApplication MapCustomerEndpoints(this WebApplication app)
        {

            app.MapGet("/api/customers/{condition}", async (string condition, ICustomerRepo repo) =>
            {
                var customer = await repo.SearchCustomer(condition);
                return customer is not null ? Results.Ok(customer) : Results.NotFound();
            });

            app.MapGet("/api/salesrep/{condition}", async (string condition, ICustomerRepo repo) =>
            {
                var salesrep = await repo.SearchSalesRep(condition);
                return salesrep is not null ? Results.Ok(salesrep) : Results.NotFound();
            });

            app.MapPost("/api/customers", async (Customer customer, ICustomerRepo repo) =>
            {
                await repo.AddCustomer(customer);
                return Results.Created();
            });

            app.MapPut("/api/customers/", async (Customer updatedCustomer, ICustomerRepo repo) =>
            {
                //if (id != updatedCustomer.CustomerId) return Results.BadRequest("ID mismatch.");
                await repo.UpdateCustomer(updatedCustomer);
                return Results.Ok();
            });

            app.MapDelete("/api/customers/{id}", async (string id, ICustomerRepo repo) =>
            {
                await repo.DeleteCustomer(id);
                return Results.Ok($"Customer with {id} has been removed");
            });

            return app;
        }


    }
}
