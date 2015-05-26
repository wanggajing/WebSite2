using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for BankAccountDAL
/// </summary>
public static class BankAccountDAL
{
    private static DBContext context = new DBContext();
    public static BankAccount GetById(string no)
    {
        var result = context.BankAccounts.Where(ac => ac.AccountNo == no);
        return result as BankAccount;
    }
    public static void AddMoney(string account, double money)
    {
        var result = context.BankAccounts.Where(ac => ac.AccountNo == account).First();
        result.Balance = money;
        context.SaveChanges();
    }
}