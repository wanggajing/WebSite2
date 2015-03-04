<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Header.ascx.cs" Inherits="CustomControl_Header" %>
<%-- 注册天气预报用户控件 --%>
<%@ Register Src="~/CustomControl/Weather.ascx" TagPrefix="uc1" TagName="Weather" %>
<div style="background:#f2f2fe; width:1000px; text-align:left;">
    <div style="float:left">
        <img src="~/images/title.png" alt="" />
        <span style="margin-left:180px;margin-right:30px;">
            当前日期：
            <%-- 调用C#代码显示当前时间和日期 --%>
            <%=DateTime.Now.ToLongDateString()+"&nbsp;"+DateTime.Today.DayOfWeek %>
        </span>
    </div>
    <uc1:Weather runat="server" ID="Weather" />
</div>
<%-- 以下为页面顶部的导航条，每个导航项目包括一个图片和一个文字 --%>
<div id="NavMenu">
    <div class="ImageMenu">
        <img  src="~/images/user.png" alt="农民档案"/><br />
        <a href="~/People/FamilyPage.aspx">农民参合档案</a>
    </div>
</div>
