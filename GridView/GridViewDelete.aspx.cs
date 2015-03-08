using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class GridView_GridViewDelete : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bindData();
        }
    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string key = e.Keys[0].ToString();
        string sql = "delete from Products where ProductId=@id";
        string s = System.Configuration.ConfigurationManager.ConnectionStrings["database2"].ConnectionString;
        SqlConnection connection = new SqlConnection(s);        
        SqlCommand command = new SqlCommand(sql, connection);
        SqlParameter p1 = new SqlParameter("@id", key);
        command.Parameters.Add(p1);
        connection.Open();
        int i=command.ExecuteNonQuery();
        bindData();
        connection.Close();
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
        GridView1.DataKeyNames = new string[] { "ProductId" };
        GridView1.DataSource = table;
        GridView1.DataBind();
        table.Dispose();
    }
}