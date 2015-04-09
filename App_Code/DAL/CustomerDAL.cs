using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CustomerDAL
/// </summary>
public class CustomerDAL
{
    private DBContext context = new DBContext();
    public Customer GetById(string id)
    {
        var customer = context.Customers.Select(c => c.CustomerID == id);
        return customer as Customer;
    }
}