using ef_code_first_tutorial.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ef_code_first_tutorial.Controllers; 
public class CustomersController { // BEGIN CLASS

    private readonly SalesDBContext _context;

    public CustomersController() { 
        _context = new SalesDBContext();
    }

    public async Task<ICollection<Customer>> GetCustomers() {
        return await _context.Customers
                                // .Include(x => x.Orders)
                                .ToListAsync();
    }

    public async Task<Customer?> GetCustomerWithOrders(int id) {
        return await _context.Customers
                                .Include(x => x.Orders)
                                    .ThenInclude(x => x.OrderLines)
                                    .ThenInclude(x =>x.Item)
                                .SingleOrDefaultAsync(x => x.Id == id);
    }


    public async Task<Customer?> GetCustomer(int id) {
        return await _context.Customers
                                .FindAsync(id);
    }

    public async Task<Customer> InsertCustomer(Customer cust) {
        _context.Customers.Add(cust);
        var changes = await _context.SaveChangesAsync();
        if (changes != 1) {
            throw new Exception("Insert Failed");
        }
        return cust;
    }
        public async Task UpdateCustomer(int id, Customer cust) {
            if(id != cust.Id) {
            throw new Exception("Customer ID doesnt match!");
            }
        
            _context.Entry(cust).State = EntityState.Modified;
            var changes = await _context.SaveChangesAsync();
            if(changes != 1) {
            throw new Exception("Update Failed");
        }
                
    }

        public async Task DeleteCustomer(int id) {
            var cust = await GetCustomer(id);  
            if(cust is null) {
        throw new Exception("Not Found!");
        }
        _context.Customers.Remove(cust);
        var changes = await _context.SaveChangesAsync();
        if (changes != 1) {
            throw new Exception("Delete Failed!");
        }
         }

} // END CLASS
