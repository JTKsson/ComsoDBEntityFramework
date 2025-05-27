using CloudDB_Assignment2.Data.Entities;

namespace CloudDB_Assignment2.Data.Interfaces
{
    public interface ICustomerRepo
    {
        Task<List<Customer>> SearchCustomer(string condition);
        Task<List<Customer>> SearchSalesRep(string condition);
        Task AddCustomer(Customer customer);
        Task UpdateCustomer(Customer customer);
        Task DeleteCustomer(string id);
    }
}
