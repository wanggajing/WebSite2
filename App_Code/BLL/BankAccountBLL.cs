using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for BankAccountBLL
/// </summary>
public static class BankAccountBLL
{
    public static BankAccount GetById(string id)
    {
        return BankAccountDAL.GetById(id);
    }
    public static void AddMoney(string account, double money)
    {
        BankAccount bankAccount = BankAccountDAL.GetById(account);
        if (bankAccount.IsLocked)
            throw new Exception("Your account" + account + "has been locked");
        BankAccountDAL.AddMoney(account, money);
    }
}