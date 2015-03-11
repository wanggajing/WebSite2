using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ProductSale
/// </summary>
public class ProductSale
{
    public Product Product { get; set; }
    public DateTime Date { get; set; }
    public int Quantity { get; set; }
    public static List<ProductSale> randomSales(int count)
    {
        int productCount = count / 5 + 1;
        Product[] products = Product.randomProducts(productCount).ToArray();
        Random r = new Random(DateTime.Now.Millisecond);
        List<ProductSale> sales = new List<ProductSale>();
        for (int i = 0; i < count; i++)
        {
            ProductSale sale = new ProductSale();
            sale.Product = products[r.Next(productCount)];
            sale.Quantity = r.Next(100);
            sale.Date = DateTime.Now.AddDays(r.Next(-30, 30));
            sales.Add(sale);
        }
        return sales;
    }

}