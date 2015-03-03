using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        cn.com.webxml.fy.EnglishChinese utility = new cn.com.webxml.fy.EnglishChinese();
        try
        {
            string[] result = utility.TranslatorString(word.Text);
            string temp = "";
            temp += "读音：" + result[1] + "<br/>";
            temp += "翻译:" + result[3] + "<br/>";
            translation.Text = temp;
        }
        catch
        {
            translation.Text = "翻译过程中出现错误";
        }
        finally
        {
            utility.Dispose();
        }
    }
}