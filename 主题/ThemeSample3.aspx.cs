using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class 主题_ThemeSample3 : System.Web.UI.Page
{
    //此方法也不行，因为PreInit时控件还没加载，根本无法得知选中了那个主题
    /*
    protected void Page_Load(object sender, EventArgs e)
    {
        this.PreInit += new EventHandler(Page_PreInit);
    }
    void Page_PreInit(object sender, EventArgs e)
    {
        this.Theme = DropDownList1.SelectedValue;
    }
     */
    //用Button click时间不能改变主题，因为主题是在PreInit中就已经完成了设置
    /*
    protected void Button1_Click(object sender, EventArgs e)
    {
        this.Theme = DropDownList1.SelectedValue;
    }
     */
    protected void Page_Load(object sender, EventArgs e)
    {
    }
    void Page_PreInit(object sender, EventArgs e)
    {
        this.Theme = Request.QueryString["theme"] ?? "GrassGreen";
    }
}