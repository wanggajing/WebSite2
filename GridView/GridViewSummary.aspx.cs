using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class GridView_GridViewSummary : System.Web.UI.Page
{
    private double totalStock = 0;
    private double totalMoney = 0;
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
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            double price = Convert.ToDouble(e.Row.Cells[2].Text);
            double stock = Convert.ToDouble(e.Row.Cells[3].Text);            
            totalStock += stock;
            totalMoney += stock * price;
        }
        else if(e.Row.RowType==DataControlRowType.Footer)
        {
            e.Row.Cells[0].Text = "商品总库存";
            e.Row.Cells[1].Text = totalStock.ToString();
            e.Row.Cells[2].Text = "商品总金额";
            e.Row.Cells[3].Text = totalMoney.ToString();
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Clear();
        Response.AddHeader("content-disposition", "attachment; filename=商品信息.xls");
        Response.Charset = "";
        Response.ContentType = "application/excel";
        System.IO.StringWriter stringWrite = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
        GridView1.RenderControl(htmlWrite);
        Response.Write(stringWrite.ToString());
        Response.End();
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        if (control == GridView1) return;
        base.VerifyRenderingInServerForm(control);
    }
}