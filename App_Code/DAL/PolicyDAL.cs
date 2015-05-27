using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for PolicyDAL
/// </summary>
public static class PolicyDAL
{
    private const string SINGLE_TRANSFER_LIMIT_ID = "policy001";
    private const string TRANSFER_TIMES_LIMIT_ID = "policy002";
    private const string TRANSFER_MONEY_LIMIT_ID = "policy003";
    private static DBContext context = new DBContext();
    public static BankPolicy GetById(string id)
    {
        var result = context.BankPolicy.Where(p => p.PolicyID == id);
        return result as BankPolicy;
    }
    public static double GetSingTransferLimit()
    {
        BankPolicy policy = GetById(SINGLE_TRANSFER_LIMIT_ID);
        return Convert.ToDouble(policy.PolicyContent);
    }
    public static int GetTransferTimesLimit()
    {
        BankPolicy policy = GetById(TRANSFER_TIMES_LIMIT_ID);
        return int.Parse(policy.PolicyContent);
    }
    public static double GetTransferMoneyLimit()
    {
        BankPolicy policy = GetById(TRANSFER_MONEY_LIMIT_ID);
        return double.Parse(policy.PolicyContent);
    }
}