using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class GridView_GridViewUpdate : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bindData();
        }
    }
    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView1.EditIndex = -1;
        bindData();
    }
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView1.EditIndex = e.NewEditIndex;
        bindData();
    }
    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        string key = e.Keys[0].ToString();
        string productName = e.NewValues["ProductName"].ToString();
        string price = e.NewValues["Price"].ToString();
        string stock = e.NewValues["Stock"].ToString();
        string description = e.NewValues["Description"].ToString();
        string sql = "update Products set ProductName=@name,Price=@price,Stock=@stock,Description=@description where ProductId=@id";
        string s = System.Configuration.ConfigurationManager.ConnectionStrings["database2"].ConnectionString;
        SqlConnection connection = new SqlConnection(s);
        SqlCommand command = new SqlCommand(sql, connection);
        SqlParameter p1 = new SqlParameter("@name", productName);
        SqlParameter p2 = new SqlParameter("@price", price);
        SqlParameter p3 = new SqlParameter("@stock", stock);
        SqlParameter p4 = new SqlParameter("@description", description);
        SqlParameter p5 = new SqlParameter("@id", key);
        command.Parameters.Add(p1);
        command.Parameters.Add(p2);
        command.Parameters.Add(p3);
        command.Parameters.Add(p4);
        command.Parameters.Add(p5);
        connection.Open();
        int i=command.ExecuteNonQuery();
        GridView1.EditIndex = -1;
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
        GridView1.DataSource = table;
        GridView1.DataBind();
        table.Dispose();
    }
}