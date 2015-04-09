using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DBContext
/// </summary>
public class DBContext: DbContext
{
    public DbSet<Customer> Customers { get; set; }
    public DbSet<BankAccount> BankAccounts { get; set; }
    public DbSet<AccountTransaction> AccountTransactions { get; set; }
    public DbSet<BankPolicy> BankPolicy { get; set; }
}