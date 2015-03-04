using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CustomControl_Weather : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        showWeather();
    }
    private void showWeather()
    {
        try
        {
            var service = new WeatherService.GlobalWeather();
            string result = service.GetWeather("BeiJing", "China");
            service.Dispose();
            weatherDesc.Text = result + "<br/>";
            weatherImage.ImageUrl = result;
        }
        catch
        {
            weatherDesc.Text = "未能获取天气信息";
        }
    }
}