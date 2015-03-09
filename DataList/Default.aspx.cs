using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DataList_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string s = System.Configuration.ConfigurationManager.ConnectionStrings["database2"].ConnectionString;
            SqlConnection connection = new SqlConnection(s);
            string sql = "select * from Products";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
            DataTable table = new DataTable();
            adapter.FillSchema(table, SchemaType.Source);
            adapter.Fill(table);
            DataList1.DataSource = table;
            DataList1.DataBind();
            table.Dispose();
        }
    }
}