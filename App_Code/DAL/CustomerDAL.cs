using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CustomerDAL
/// </summary>
public static class CustomerDAL
{
    private static DBContext context = new DBContext();
    public static Customer GetById(string id)
    {
        var customer = context.Customers.Where(c => c.CustomerID == id);
        return customer as Customer;
    }
}