using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for AccountTransaction
/// </summary>
public class AccountTransaction
{
    public int TransactionID { get; set; }
    public BankAccount SourceAccount { get; set; }
    public BankAccount DestinationAccount { get; set; }
    public DateTime TransactionDate { get; set; }
    public double TranserMoney { get; set; }
}