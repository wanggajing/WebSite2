using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CustomAttribute_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Random r = new Random(DateTime.Now.Second);
        ProgressBar1.progress += r.Next(20);
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Random r = new Random(DateTime.Now.Second);
        ProgressBar1.progress -= r.Next(20);
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        Color fore = Color.FromName(foreColorList.SelectedValue);
        Color back = Color.FromName(backColorList.SelectedValue);
        ProgressBar1.foreColor = fore;
        ProgressBar1.backColor = back;
    }
}