using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DropDownList_DropDownList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bindOccupationList();
        }
    }
    private void bindOccupationList()
    {
        String s = System.Configuration.ConfigurationManager.ConnectionStrings["database2"].ConnectionString;
        SqlConnection connection = new SqlConnection(s);
        string sql = "select * from Occupation";
        SqlDataAdapter adapter = new SqlDataAdapter(sql, s);
        DataTable table = new DataTable();
        adapter.FillSchema(table, SchemaType.Source);
        adapter.Fill(table);
        list.DataSource = table;
        list.DataBind();
        table.Dispose();
    }
}