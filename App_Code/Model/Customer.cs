using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Customer
/// </summary>
public class Customer
{
    public string CustomerID { get; set; }
    public string CustomerName { get; set; }
    public string LoginPassword { get; set; }
    public string PayPassword { get; set; }
    public List<BankAccount> BankAccounts { get; set; }
}