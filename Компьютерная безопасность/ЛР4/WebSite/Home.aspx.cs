using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ServiceAuthorization;

public partial class _Default : System.Web.UI.Page
{
    static string userLogin = "";
    static string userPassword = "";
    static string userToken = "";
    /// <summary>
    /// Загрузка страницы
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        string casheKey = Request.QueryString["cashe"];
        if (!String.IsNullOrEmpty(casheKey))
        {
            string[] userInfo = (string[])Cache.Remove(casheKey);
            userLogin = userInfo[0];
            userPassword = userInfo[1];
            userToken = userInfo[2];
            Response.Redirect(Request.RawUrl.Replace(Request.Url.Query, ""));
        }
        if (userToken == "")
        {
            Response.Redirect("Login.aspx");
        }
    }
    /// <summary>
    /// Нажатие на кнопку "User"
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ButtonForUser_Click(object sender, EventArgs e)
    {
        ServiceAuthorizationClient client = new ServiceAuthorizationClient();
        if (!client.AccessAction(userToken, 1))
            Response.Write("У вас нет прав быть пользователем!");
        else
            Response.Write("Доступ получен, пользователь!");
    }
    /// <summary>
    /// Нажатие на кнопку "Admin"
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ButtonForAdmin_Click(object sender, EventArgs e)
    {
        ServiceAuthorizationClient client = new ServiceAuthorizationClient();
        if (!client.AccessAction(userToken, 2))
            Response.Write("У вас нет прав быть администратором!");
        else
            Response.Write("Доступ получен, администратор!");
    }
    /// <summary>
    /// Нажатие на кнопку "Вернуться к авторизации"
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ButtonBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("Login.aspx");
    }
}