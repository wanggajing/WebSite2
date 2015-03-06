using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Transaction_AdoNetTran : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string s = System.Configuration.ConfigurationManager.ConnectionStrings["database"].ConnectionString;
        SqlConnection connection = new SqlConnection(s);
        connection.Open();
        string s1 = "insert into UserTable (UserId,UserName,Password,Sex)" + " values ('user99','NewUser','123','M')";
        string s2 = "insert into UserTable (UserId,UserName,Password,Sex)" + "values ('user100','NewUser','123','nansheng')";
        SqlCommand command1 = new SqlCommand(s1, connection);
        SqlCommand command2 = new SqlCommand(s2, connection);
        SqlTransaction tran = connection.BeginTransaction();
        command1.Transaction = tran;
        command2.Transaction = tran;
        string message = "";
        try
        {
            command1.ExecuteNonQuery();
            command2.ExecuteNonQuery();
            tran.Commit();
            message = "保存成功！";
        }
        catch (Exception ex)
        {
            message = "保存用户信息过程中出错，事务回滚";
            tran.Rollback();
        }
        finally
        {
            command1.Dispose();
            command2.Dispose();
            tran.Dispose();
            connection.Close();
        }
        Page.ClientScript.RegisterStartupScript(this.GetType(), "register", "<script>alert(\"" + message + "\");</script>");
    }
}