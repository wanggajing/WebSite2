using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class GridView_Default2 : System.Web.UI.Page
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
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        bindData();
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        int n;
        if (int.TryParse(pageNumber.Text, out n))
        {
            GridView1.PageIndex = n - 1;
            bindData();
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        int n;
        if (int.TryParse(size.Text, out n))
        {
            GridView1.PageSize = n;
            bindData();
        }
    }
}