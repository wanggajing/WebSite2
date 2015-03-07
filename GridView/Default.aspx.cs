using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class GridView_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bindData();
        }
    }
    private void bindData()
    {
        string s = System.Configuration.ConfigurationManager.ConnectionStrings["database2"].ConnectionString;
        SqlConnection connection = new SqlConnection(s);
        string sql = "select * from Products";
        SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
        DataTable table = new DataTable();
        adapter.FillSchema(table, SchemaType.Source);
        adapter.Fill(table);
        GridView1.DataSource = table;
        GridView1.DataBind();
        table.Dispose();
    }
    private void bindData(string sortField, bool desc)
    {
        string s = System.Configuration.ConfigurationManager.ConnectionStrings["database2"].ConnectionString;
        SqlConnection connection = new SqlConnection(s);
        string sql = "select * from Products";
        if (!string.IsNullOrEmpty(sortField))
        {
            sql += " order by " + sortField;
            if (desc)
                sql += " desc ";
        }
        SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
        DataTable table = new DataTable();
        adapter.FillSchema(table, SchemaType.Source);
        adapter.Fill(table);
        GridView1.DataSource = table;
        GridView1.DataBind();
        table.Dispose();
    }
    protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
    {
        bindData(e.SortExpression, e.SortDirection == SortDirection.Descending);
    }
}