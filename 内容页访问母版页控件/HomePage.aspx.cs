using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class 内容页访问母版页控件_HomePage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        /*第一种方法，从内容页访问母版页的私有变量，破话封装。
        if (!IsPostBack)
        {
            Label positon = (Label)this.Master.FindControl("Label1");
            if (positon != null)
            {
                positon.Text = "<a href='HomePage.aspx'>首页</a>";
            }
        }
         */
        if (!IsPostBack)
        {
            内容页访问母版页控件_MasterPage master = this.Master as 内容页访问母版页控件_MasterPage;
            master.MyPosition = "首页";           
        }
    }
}