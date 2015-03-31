using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class OnlineBanking_SimpleBankPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    /// <summary>
    /// 验证顾客信息，客户ID,登陆密码,支付密码,是否拥有源账号
    /// </summary>
    /// <returns>验证合法返回true,否则false</returns>
    private bool checkPassword()
    {
        string s = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        using (SqlConnection connection = new SqlConnection(s))
        {
            string sql = "select LoginPassword,PayPassword from Customer where CustomerID=@id";
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                SqlParameter p = new SqlParameter("@id", customer.Text);
                command.Parameters.Add(p);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (!reader.Read())
                    {
                        showError("不存在你所输入的顾客ID.");
                        return false;
                    }
                    string pass1, pass2;
                    pass1 = reader[0].ToString();
                    pass2 = reader[1].ToString();
                    if (loginPass.Text != pass1 || payPass.Text != pass2)
                    {
                        showError("密码不正确.");
                        return false;
                    }
                }
            }
            //检测用户是否拥有所输入的源账号
            sql = "select count(*) from BankAccount where AccountNo=@no and CustomerID=@id";
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                SqlParameter p = new SqlParameter("@id", customer.Text);
                SqlParameter p1 = new SqlParameter("@no", source.Text);
                int n = Convert.ToInt32(command.ExecuteScalar());
                if (n == 0)
                {
                    showError("未找到你所输入的账号.");
                    return false;
                }
            }
        }
        return true;
    }
    /// <summary>
    /// 对源账号信息进行验证，包括检验源账号是否被冻结，以及源账号中是否有足够的余额以供转账
    /// </summary>
    /// <returns>true如果验证成功</returns>
    private bool checkSourceAccount()
    {
        string s = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        using (SqlConnection connection = new SqlConnection(s))
        {
            string sql = "select IsLocked,Balance from BankAccount where AccountNo=@no";
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                SqlParameter p = new SqlParameter("@no", source.Text);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (!reader.Read())
                    {
                        showError("你输入的账号[" + source.Text + "]不存在。");
                        return false;
                    }
                    bool locked = Convert.ToBoolean(reader[0]);
                    double balance = Convert.ToDouble(reader[1]);
                    reader.Close();
                    if (locked)
                    {
                        showError("源账号[" + source.Text + "]已经被冻结。");
                        return false;
                    }
                    if (balance < double.Parse(money.Text))
                    {
                        showError("源账号[" + source.Text + "]资金余额不足");
                    }
                }
            }
            return true;
        }
    }
    protected void ok_Click(object sender, EventArgs e)
    {

    }
}