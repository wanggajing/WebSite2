using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class 内容页访问母版页控件_MasterPage : System.Web.UI.MasterPage
{
    //将母版页当前位置的Label的文本封装成一个属性，方便访问
    public string MyPosition
    {
        get { return Label1.Text; }
        set { Label1.Text=value; }
    }
    protected void Page_Load(object sender, EventArgs e)
    {

    }
}
