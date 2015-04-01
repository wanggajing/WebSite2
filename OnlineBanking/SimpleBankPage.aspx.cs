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
            connection.Open();
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
            connection.Close();
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
            connection.Open();
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
            connection.Close();
        }
        return true;
    }
    /// <summary>
    /// 检查交易上限(包括单笔金额上限，累计转账金额上限，累计交易次数上限)
    /// </summary>
    /// <returns>检查是否合法</returns>
    private bool checkTransactionLimit()
    {
        string s = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        using (SqlConnection connection = new SqlConnection(s))
        {
            connection.Open();
            double singleTranserLimit;
            int transferTimesLimit;
            double transferMoneyLimit;
            string sql = "select PolicyContent from BankPolicy where PolicyID = @id";
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                //从数据库读取单笔转账金额上限
                SqlParameter p = new SqlParameter("@id","policy001");
                command.Parameters.Add(p);
                singleTranserLimit = Convert.ToDouble(command.ExecuteScalar());
                //从数据库读取单日累计转账次数上限
                command.Parameters["@id"].Value = "policy002";
                transferTimesLimit = Convert.ToInt32(command.ExecuteScalar());
                //数据库读取单日累计转账金额上限
                command.Parameters["@id"].Value = "policy003";
                transferMoneyLimit = Convert.ToDouble(command.ExecuteScalar());
            }
            if (singleTranserLimit < double.Parse(money.Text))
            {
                showError("你要转账的金额超过单笔转账上限" + singleTranserLimit.ToString());
                return false;
            }
            //从数据库读取源账号当日累计转账次数和当时累计转账金额
            sql = "select count(*),sum(TransferMoney) from AccountTransaction" + " where SourceAccount=@no";
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                SqlParameter p = new SqlParameter("@no", source.Text);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        int times = Convert.ToInt32(reader[0]);
                        double theMoney = 0;
                        if (reader[1] != DBNull.Value)
                            theMoney = Convert.ToDouble(reader[1]);
                        if (times == transferTimesLimit)
                        {
                            showError("账号[" + source.Text + "]当日累计转账次数已经达到上限，不能进行转账。");
                            return false;
                        }
                        //检查累计转账金额
                        if (theMoney + double.Parse(money.Text) > transferMoneyLimit)
                        {
                            showError("此次转账将使账号[" + source.Text + "]当日累计转账金额超出上限，不能进行转账。");
                            return false;
                        }
                    }
                }
            }
            connection.Close();
        }
        return true;
    }
    /// <summary>
    /// 检查目的账号(账号是否存在，名称是否正确，是否被冻结)
    /// </summary>
    /// <returns>检查是否合法</returns>
    private bool checkDestinationAccount()
    {
        string s = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        using (SqlConnection connection = new SqlConnection(s))
        {
            connection.Open();
            string sql = "select IsLocked, CustomerID from BankAccount where AccountNo=@no";
            bool locked;
            string customerId, customerName;
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                SqlParameter p = new SqlParameter("@no", destination.Text);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (!reader.Read())
                    {
                        showError("你输入的账号[" + destination.Text + "]不存在。");
                        return false;
                    }
                    locked = Convert.ToBoolean(reader[0]);
                    customerId = Convert.ToString(reader[1]);
                }
            }
            sql = "select CustomerName form Customer where CustomerID = @id";
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                SqlParameter p = new SqlParameter("@id", customerId);
                command.Parameters.Add(p);
                customerName = Convert.ToString(command.ExecuteScalar());
            }
            if (customerName != destinationName.Text)
            {
                showError("目的账号[" + source.Text + "]名称不对，请检查账号是否正确。");
                return false;
            }
            if (locked)
            {
                showError("目的账号[" + source.Text + "]已经被冻结。");
                return false;
            }
            connection.Close();
        }
        return true;
    }
    private void transerMoney()
    {
        string s = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        using (SqlConnection connection = new SqlConnection(s))
        {
            connection.Open();
            using (SqlTransaction tran = connection.BeginTransaction())
            {
                //修改源账号
                string sql = "update BankAccount set Balance=Balance-Balance-@money where AccountNo=@no";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    SqlParameter p = new SqlParameter("@no", destination.Text);
                    SqlParameter p1 = new SqlParameter("money", money.Text);
                    command.Parameters.Add(p);
                    command.Parameters.Add(p1);
                    command.Transaction = tran;
                    command.ExecuteNonQuery();
                }
                //修改目标账号
                sql = "update BankAccount set Balance=Balance+@money where AccountNo=@no";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    SqlParameter p = new SqlParameter("@no", source.Text);
                    SqlParameter p1 = new SqlParameter("@money", money.Text);
                    command.Parameters.Add(p);
                    command.Parameters.Add(p1);
                    command.Transaction = tran;
                    command.ExecuteNonQuery();
                }
                //将交易记录保存到数据库
                sql = "insert into AccountTransaction (SourceAccount, DestinationAccount, TransferMoney) " +
                    "values (@source,@dest,@money)";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    SqlParameter p = new SqlParameter("@source", source.Text);
                    SqlParameter p1 = new SqlParameter("@dest", destination.Text);
                    SqlParameter p2 = new SqlParameter("@money", money.Text);
                    command.Parameters.Add(p);
                    command.Parameters.Add(p1);
                    command.Parameters.Add(p2);
                    command.Transaction=tran;
                    command.ExecuteNonQuery();
                }
                tran.Commit();
            }
            connection.Close();
        }
    }
    protected void ok_Click(object sender, EventArgs e)
    {
        if (!checkPassword())
            return;
        if (!checkSourceAccount())
            return;
        if (!checkTransactionLimit())
            return;
        if (!checkDestinationAccount())
            return;
        transerMoney();
        showMessage("转账操作成功。");
    }
    /// <summary>
    /// 显示错误提示，同时隐藏操作结果提示
    /// </summary>
    /// <param name="errorMessage"></param>
    private void showError(string errorMessage)
    {
        error.Text = errorMessage;
        error.Visible = true;
        message.Visible = false;
        message.Text = "";
    }
    /// <summary>
    /// 显示操作提示（如果操作成功），同时隐藏错误提示
    /// </summary>
    /// <param name="content"></param>
    private void showMessage(string content)
    {
        message.Visible = true;
        error.Visible = false;
        error.Text = "";
        message.Text = content;
    }
}