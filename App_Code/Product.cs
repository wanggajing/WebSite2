using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Product
/// </summary>
public class Product
{
    public string ID { get; set; }
    public string Name { get; set; }
    public int Storage { get; set; }
    public double Price { get; set; }
    public Category Category { get; set; }
    public static List<Product> randomProducts(int count)
    {
        Random r = new Random(DateTime.Now.Millisecond);
        List<Product> products = new List<Product>();
        int categoryCount = Math.Min(20, Math.Max(3, count / 10));
        Category[] categories = Category.randomCategories(categoryCount).ToArray();
        for (int i = 0; i < count; i++)
        {
            Product p = new Product();
            p.ID = "p" + r.Next(10000).ToString("0000");
            p.Name = "Product" + i.ToString();
            p.Storage = r.Next(10, 10000);
            p.Price = 1 + r.NextDouble() * 300;
            p.Category = categories[r.Next(categoryCount)];
            products.Add(p);
        }
        return products;
    }
}