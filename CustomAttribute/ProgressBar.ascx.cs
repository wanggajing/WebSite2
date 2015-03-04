using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CustomAttribute_ProgressBar : System.Web.UI.UserControl
{
    public Color backColor
    {
        get
        {
            if (ViewState["BackColor"] == null)
                return Color.Silver;
            return (Color)ViewState["BackColor"];
        }
        set
        {
            ViewState["BackColor"] = value;
        }
    }
    public Color foreColor
    {
        get
        {
            if (ViewState["ForeColor"] == null)
                return Color.Green;
            return (Color)ViewState["ForeColor"];
        }
        set
        {
            ViewState["ForeColor"] = value;
        }
    }
    public int progress
    {
        get
        {
            if (ViewState["Progress"] == null)
                return 0;
            return (int)ViewState["Progress"];
        }
        set
        {
            if (value > 100 || value < 0) return;
            ViewState["Progress"] = value;
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        //为控件的PreRender事件添加事件处理程序
        this.PreRender += new EventHandler(ProgressBar_PreRender);
    }
    void ProgressBar_PreRender(object sender, EventArgs e)
    {
        int blocks = (int)Math.Round(progress * 20.0 / 100.0);
        TableRow row = new TableRow();
        for (int i = 0; i < 20; i++)
        {
            TableCell cell = new TableCell();
            cell.Text = " ";
            if (i < blocks)
                cell.BackColor = foreColor;
            else
                cell.BackColor = backColor;
            row.Cells.Add(cell);
        }
        Table1.Rows.Add(row);
    }
}