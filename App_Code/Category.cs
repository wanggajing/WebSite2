using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Category
/// </summary>
public class Category
{
    public string ID { get; set; }
    public string Name { get; set; }
    public static List<Category> randomCategories(int count)
    {
        Random r = new Random(DateTime.Now.Millisecond);
        List<Category> categories = new List<Category>();
        for (int i = 0; i < count; i++)
        {
            Category category = new Category();
            category.ID = "C" + r.Next(1000);
            category.Name = "Category " + i.ToString();
            categories.Add(category);
        }
        return categories;
    }
}