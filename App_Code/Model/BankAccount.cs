using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for BankAccount
/// </summary>
public class BankAccount
{
    public string AccountNo { get; set; }
    public double Balance { get; set; }
    public string CustomerID { get; set; }
    public Customer Customer { get; set; }
    public bool IsLocked { get; set; }
    public List<AccountTransaction> AccountTransactions { get; set; }
}