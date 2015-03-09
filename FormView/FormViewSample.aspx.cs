using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class FormView_FormViewSample : System.Web.UI.Page
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
        FormView1.DataSource = table;
        FormView1.DataBind();
        table.Dispose();
    }
    protected void FormView1_PageIndexChanging(object sender, FormViewPageEventArgs e)
    {
        FormView1.PageIndex = e.NewPageIndex;
        bindData();
    }
    protected void FormView1_ModeChanging(object sender, FormViewModeEventArgs e)
    {
        FormView1.ChangeMode(e.NewMode);
        bindData();
    }
    protected void FormView1_ItemDeleting(object sender, FormViewDeleteEventArgs e)
    {
        string key = e.Keys[0].ToString();
        string sql = "delete from Products where ProductId=@id";
        string s = System.Configuration.ConfigurationManager.ConnectionStrings["database2"].ConnectionString;
        SqlConnection connection = new SqlConnection(s);
        SqlCommand command = new SqlCommand(sql, connection);
        SqlParameter p1 = new SqlParameter("@id", key);
        command.Parameters.Add(p1);
        connection.Open();
        int i = command.ExecuteNonQuery();
        FormView1.ChangeMode(FormViewMode.ReadOnly);
        bindData();
        connection.Close();
    }
    protected void FormView1_ItemUpdating(object sender, FormViewUpdateEventArgs e)
    {
        string key = e.Keys[0].ToString();
        string productName = (FormView1.FindControl("productName") as TextBox).Text;
        double price = double.Parse((FormView1.FindControl("productPrice") as TextBox).Text);
        double stock = double.Parse((FormView1.FindControl("stock") as TextBox).Text);
        string description = (FormView1.FindControl("description") as TextBox).Text;
        string image = null;
        FileUpload file = FormView1.FindControl("imageFile") as FileUpload;
        if (file.HasFile)
        {
            image = file.FileName;
            file.SaveAs(Server.MapPath("~/ProductImages/" + file.FileName));
        }
        string sql = "update Products set ProductName=@name,Price=@price,Stock=@stock,"+
            "Description=@description" + (file.HasFile?",ImageUrl=@img ":" ")+" where ProductId=@id";
        string s = System.Configuration.ConfigurationManager.ConnectionStrings["database2"].ConnectionString;
        SqlConnection connection = new SqlConnection(s);
        SqlCommand command = new SqlCommand(sql, connection);
        SqlParameter p1 = new SqlParameter("@name", productName);
        SqlParameter p2 = new SqlParameter("@price", price);
        SqlParameter p3 = new SqlParameter("@stock", stock);
        SqlParameter p4 = new SqlParameter("@description", description);
        SqlParameter p5 = null;
        if (file.HasFile)
        {
             p5 = new SqlParameter("@img", image);
        }    
        SqlParameter p6 = new SqlParameter("@id", key);
        command.Parameters.Add(p1);
        command.Parameters.Add(p2);
        command.Parameters.Add(p3);
        command.Parameters.Add(p4);
        if (file.HasFile)
        {
            command.Parameters.Add(p5);
        }
        command.Parameters.Add(p6);
        connection.Open();
        int i = command.ExecuteNonQuery();
        FormView1.ChangeMode(FormViewMode.ReadOnly);
        bindData();
        connection.Close();
    }
}