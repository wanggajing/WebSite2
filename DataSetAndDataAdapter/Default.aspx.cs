using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DataSetAndDataAdapter_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string s = System.Configuration.ConfigurationManager.ConnectionStrings["database"].ConnectionString;
        SqlConnection connection = new SqlConnection(s);
        string sql = "select * from UserTable";
        SqlDataAdapter adapter = new SqlDataAdapter(sql, s);

        DataSet ds = new DataSet();
        adapter.Fill(ds);
        DataTable table = ds.Tables[0];
        TableHeaderRow header = new TableHeaderRow();
        foreach (DataColumn column in table.Columns)
        {
            TableHeaderCell cell = new TableHeaderCell();
            cell.Text = column.ColumnName;
            header.Cells.Add(cell);
        }
        Table1.Rows.Add(header);
        foreach (DataRow row in table.Rows)
        {
            TableRow r = new TableRow();
            for (int i = 0; i < table.Columns.Count; i++)
            {
                TableCell cell = new TableCell();
                cell.Text = Convert.ToString(row[i]);
                r.Cells.Add(cell);
            }
            Table1.Rows.Add(r);
        }
        table.Dispose();
        ds.Dispose();
        adapter.Dispose();
    }
}