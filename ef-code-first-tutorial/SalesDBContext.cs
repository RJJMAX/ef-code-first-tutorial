using ef_code_first_tutorial.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ef_code_first_tutorial; 
public class SalesDBContext : DbContext {
    // Tables accessible
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Item> Items { get; set; }
    public DbSet<OrderLine> OrderLines { get; set; }

    public SalesDBContext() { }
    // from Microsoft library and passed to the parent class
    public SalesDBContext(DbContextOptions<SalesDBContext> options) : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
        var connStr = "server=localhost\\sqlexpress;" +
            "database=SalesDB2;" +
            "trusted_connection=true;" +
            "trustServerCertificate=true;";
        optionsBuilder.UseSqlServer(connStr);
    }

}
