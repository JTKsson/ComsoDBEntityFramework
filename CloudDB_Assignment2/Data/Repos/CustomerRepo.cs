using CloudDB_Assignment2.Data.Entities;
using CloudDB_Assignment2.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CloudDB_Assignment2.Data.Repos
{
    public class CustomerRepo : ICustomerRepo
    {
        private readonly CustomerContext _context;

        public CustomerRepo(CustomerContext context)
        {
            _context = context;
        }

        public async Task<List<Customer>> SearchCustomer(string condition)
        {
            return await _context.Customers
                .Where(c => c.FullName != null &&
                            c.FullName.Contains(condition, StringComparison.OrdinalIgnoreCase))
                .ToListAsync();
        }

        public async Task<List<Customer>> SearchSalesRep(string condition)
        {
            return await _context.Customers
                .Where(c => c.FullName != null &&
                            c.FullName.Contains(condition, StringComparison.OrdinalIgnoreCase))
                .ToListAsync();
        }

        public async Task AddCustomer(Customer customer)
        {
            if (string.IsNullOrWhiteSpace(customer.CustomerId))
            {
                customer.CustomerId = Guid.NewGuid().ToString();
            }

            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateCustomer(Customer customer)
        {
            var existing = await _context.Customers.FindAsync(customer.CustomerId);
            if (existing == null) return;

            _context.Entry(existing).CurrentValues.SetValues(customer);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCustomer(string id)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer == null) return;

            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();
        }
    }
}
