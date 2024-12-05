using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Text;
//using System.Net.Http;
using System.IO;
using System.Net.Mime;
using System.Text.RegularExpressions;
using System.Collections;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;

/// <summary>
/// Utility 的摘要描述
/// </summary>
public class Utility
{
    public Utility()
    {
        //
        // TODO: 在這裡新增建構函式邏輯
        //
    }

    public static void showMessage(System.Web.UI.Page pPage, String pKey, String pMessage)
    {
        pPage.ClientScript.RegisterStartupScript(pPage.GetType(), pKey, String.Format("alert('{0}');", pMessage), true);
    }

    public static String showPageNumber(int rowCount, int pageNumber, int pageRecord = 10, int pageShow = 10)
    {
        String returnString = "";
        if ((rowCount <= 0) || (pageNumber <= 0) || (pageRecord <= 0) || (pageShow <= 0)) return "";
        int maxPageNumber = (rowCount - 1) / pageRecord + 1;
        if (maxPageNumber <= 1) return "";
        returnString += "<div class=\"center pages both w10\">";

        //第一頁
        if (pageNumber > 1) returnString += String.Format("<a href=\"#\" style=\"margin-right:0px;\" onclick=\"_goPage({0});return false;\"><i class=\"fa fa-angle-double-left\" aria-hidden=\"true\"></i></a>", 1);
        //上一頁
        if (pageNumber > 1) returnString += String.Format("<a href=\"#\" style=\"margin-left:0px;\" onclick=\"_goPage({0});return false;\">上一頁</a>", pageNumber - 1);
        //顯示頁碼
        int pageShowStart = pageNumber - pageShow / 2;
        if (pageShowStart < 1) pageShowStart = 1;
        int pageShowEnd = pageShowStart + pageShow - 1;
        if (pageShowEnd > maxPageNumber) pageShowEnd = maxPageNumber;
        for (int i = pageShowStart; i <= pageShowEnd; i++)
        {
            if (i == pageNumber)
            {
                returnString += String.Format("<a href=\"#\" style=\"color:red;cursor:default;\" onclick=\"return false;\">{0}</a>{1}", i, (i == pageShowEnd) ? "" : " ");
            }
            else
            {
                returnString += String.Format("<a href=\"#\" onclick=\"_goPage({0});return false;\">{0}</a>{1}", i, (i == pageShowEnd) ? "" : " ");
            }
        }
        //下一頁
        if (pageNumber < maxPageNumber) returnString += String.Format("<a href=\"#\" style=\"margin-right:0px;\" onclick=\"_goPage({0});return false;\">下一頁</a>", pageNumber + 1);
        //最後一頁
        if (pageNumber < maxPageNumber) returnString += String.Format("<a href=\"#\" style=\"margin-left:0px;\" onclick=\"_goPage({0});return false;\"><i class=\"fa fa-angle-double-right\" aria-hidden=\"true\"></i></a>", maxPageNumber);
        //計算總筆數
        if (rowCount != 0) returnString += string.Format("共<span style='color:red'>{0}</span>筆", rowCount);
        returnString += "</div>";
        return returnString;
    }


}