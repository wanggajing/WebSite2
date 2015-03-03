using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

/// <summary>
/// Summary description for WebService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class WebService : System.Web.Services.WebService {
    string[] numbers=("零，一，二，三，四，五，六，七，八，九，十，十一，十二，十三，十四，十五"
        +"，十六，十七，十八，十九，二十，廿一，廿二，廿三，廿四，廿五，廿六，廿七"
        +"，廿八，廿九，三十").Split('，');
    public WebService () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string GetLunarDate(DateTime date)
    {
        System.Globalization.ChineseLunisolarCalendar calendar = new
        System.Globalization.ChineseLunisolarCalendar();
        string result = "";
        result = result + toChineseNum(calendar.GetYear(date)) + "年";
        result = result + numbers[calendar.GetMonth(date)] + "月";
        int month = calendar.GetDayOfMonth(date);
        if (month < 11)
            result = result + "初" + numbers[month];
        else
            result = result + numbers[month];
        return result;
    }
    private string toChineseNum(int n)
    {
        int r;
        string result = "";
        while (n > 0)
        {
            r = n % 10;
            result = numbers[r] + result;
            n = n / 10;
        }
        return result;
    }
}
