using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DataSetAndDataAdapter_BatchUpdate : System.Web.UI.Page
{
    private DataTable data = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        showData(data);
    }
    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        data = loadData();
    }
    private DataTable loadData()
    {
        string s = System.Configuration.ConfigurationManager.ConnectionStrings["database"].ConnectionString;
        SqlConnection connection = new SqlConnection(s);
        string sql = "select top 5 UserId, UserName from UserTable";
        SqlDataAdapter adapter = new SqlDataAdapter(sql, s);

        DataTable table = new DataTable();
        adapter.FillSchema(table, SchemaType.Source);
        adapter.Fill(table);
        adapter.Dispose();
        return table;
    }
    private void showData(DataTable table)
    {
        int num = table.Columns.Count;
        TableHeaderRow header = new TableHeaderRow();
        for (int i = 0; i < num; i++)
        {
            TableHeaderCell cell = new TableHeaderCell();
            cell.Text = table.Columns[i].ColumnName;
            header.Cells.Add(cell);
        }
        grid.Rows.Add(header);
        foreach (DataRow row in table.Rows)
        {
            TableRow r = new TableRow();
            string id = Convert.ToString(row[0]);
            string name = Convert.ToString(row[1]);
            TableCell cell = new TableCell();
            cell.Text = id;
            r.Cells.Add(cell);
            cell = new TableCell();
            TextBox t = new TextBox();
            t.ID = "textbox" + id;
            t.Text = name;
            t.TextChanged += new EventHandler(t_TextChanged);
            cell.Controls.Add(t);
            r.Cells.Add(cell);
            grid.Rows.Add(r);
        }       
    }
    void t_TextChanged(object sender, EventArgs e)
    {
        TextBox t = sender as TextBox;
        TableRow r = t.Parent.Parent as TableRow;
        string id = r.Cells[0].Text;
        DataRow row = data.Rows.Find(id);
        if (row == null) return;
        row[1] = t.Text;
    }
    protected void update_Click(object sender, EventArgs e)
    {
        string s = System.Configuration.ConfigurationManager.ConnectionStrings["database"].ConnectionString;
        SqlConnection connection = new SqlConnection(s);
        string sql = "select top 5 UserId, UserName from UserTable";
        SqlDataAdapter adapter = new SqlDataAdapter(sql, s);
        SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
        adapter.Update(data);
        builder.Dispose();
        adapter.Dispose();
    }
}