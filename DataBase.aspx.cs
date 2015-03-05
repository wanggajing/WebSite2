using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DataBase : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string connString = ConfigurationManager.ConnectionStrings["database"].ConnectionString;
        Label1.Text = "";
        using (SqlConnection conn = new SqlConnection(connString))
        {
            conn.Open();
            Label1.Text += "连接已近打开<br />";
            conn.Close();
            Label1.Text += "连接已近关闭<br />";
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        string connString = ConfigurationManager.ConnectionStrings["database"].ConnectionString;
        SqlConnection conn = new SqlConnection(connString);
        string sql = "insert into UserTable (UserName,Password) values (@name, @pass)";
        SqlCommand command = new SqlCommand(sql, conn);
        SqlParameter p1 = new SqlParameter("@name", TextBox1.Text);
        command.Parameters.Add(p1);
        SqlParameter p2 = new SqlParameter("@pass", TextBox2.Text);
        command.Parameters.Add(p2);
        string message = "";
        try
        {
            conn.Open();
            int n = command.ExecuteNonQuery();
            if (n == 1)
                message = "注册成功。用户信息已经保存在数据库";
            else
                message = "数据未能保存";
        }
        catch (Exception ex)
        {
            message = "保存用户信息过程中出错" + ex.Message.Replace("\r", "\\r ").Replace("\n", "\\n");
        }
        finally
        {
            command.Dispose();
            conn.Close();
        }
        Page.ClientScript.RegisterStartupScript(this.GetType(), "register", "<script>alert(\"" + message + "\");</script>");
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        string connString = ConfigurationManager.ConnectionStrings["database"].ConnectionString;
        SqlConnection conn = new SqlConnection(connString);
        string sql = "update UserTable set Password=@newpass " + "where UserName=@name and Password=@oldpass";
        string sql1 = "update UserTable set Password='12344' where UserName='wuke' and Password='123'";
        SqlCommand command = new SqlCommand(sql1, conn);
    /*    SqlParameter p1 = new SqlParameter("@name", TextBox3.Text);
        command.Parameters.Add(p1);
        SqlParameter p2 = new SqlParameter("@oldpass", TextBox4.Text);
        command.Parameters.Add(p2);
        SqlParameter p3 = new SqlParameter("@newpass", TextBox5.Text);
        command.Parameters.Add(p3);
     */ 

        string message = "";
        try
        {
            conn.Open();
            int n = command.ExecuteNonQuery();
            if (n == 1)
                message = "密码修改成功";
            else
                message = "不存在此用户或原始密码不对";
        }
        catch (Exception ex)
        {
            message = "更改密码过程中出错" + ex.Message.Replace("\r", "\\r ").Replace("\n", "\\n");
        }
        finally
        {
            command.Dispose();
            conn.Close();
        }
        Page.ClientScript.RegisterStartupScript(this.GetType(), "register", "<script>alert(\"" + message + "\");</script>");
    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        string connString = ConfigurationManager.ConnectionStrings["database"].ConnectionString;
        SqlConnection conn = new SqlConnection(connString);
        string sql = "select count(*) from UserTable";
        SqlCommand command = new SqlCommand(sql, conn);
        string message = "";
        try
        {
            conn.Open();
            int n = Convert.ToInt32(command.ExecuteScalar());
            Total.Text = n.ToString();
        }
        catch (Exception ex)
        {
            message = "执行命令过程中出错" + ex.Message.Replace("\r", "\\r ").Replace("\n", "\\n");
        }
        finally
        {
            command.Dispose();
            conn.Close();
        }
        Page.ClientScript.RegisterStartupScript(this.GetType(), "register", "<script>alert(\"" + message + "\");</script>");
    }
    protected void Button5_Click(object sender, EventArgs e)
    {
        string connString = ConfigurationManager.ConnectionStrings["database"].ConnectionString;
        using (SqlConnection conn = new SqlConnection(connString))
        {
            string sql = "select UserId,UserName,Password,Sex from UserTable";
            SqlCommand command = new SqlCommand(sql, conn);
            conn.Open();
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    TableRow row = new TableRow();
                    Result.Rows.Add(row);
                    for (int i = 0; i < 3; i++)
                    {
                        TableCell cell = new TableCell();
                        cell.Text = Convert.ToString(reader[i]);
                        row.Cells.Add(cell);
                    }
                }
            }
            command.Dispose();
            conn.Close();
        }
    }
}