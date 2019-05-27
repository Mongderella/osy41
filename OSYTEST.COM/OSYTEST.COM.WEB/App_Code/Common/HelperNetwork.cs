using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

/// <summary>
/// HelperNetwork의 요약 설명입니다.
/// </summary>
public static class HelperNetwork
{
    /// <summary>
    /// Client 의 Ip Address 를 반환합니다.
    /// </summary>
    /// <returns></returns>
    public static string GetClientIpAddress()
    {
        string returnResult = string.Empty;

        try
        {
            System.Web.HttpContext context = System.Web.HttpContext.Current;
            string ipAddress = context.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

            if (!string.IsNullOrEmpty(ipAddress))
            {
                string[] addresses = ipAddress.Split(',');
                if (addresses.Length != 0)
                {
                    returnResult = addresses[0];
                }
            }
            else
                returnResult = context.Request.ServerVariables["REMOTE_ADDR"];
        }
        catch (Exception ex)
        {
            HelperCommon.RegisterLogForHelperSecurity(ex.ToString());
        }

        return returnResult;
    }

    /// <summary>
    /// 2 개의 IP 를 비교하여 ipAddr2 가 ipAddr1 에 속하는지 여부를 반환합니다.
    /// </summary>
    /// <param name="ipAddr1">기준이 되는 Ip Addr</param>
    /// <param name="ipAddr2">ipAddr1 에 종속되는 ip 인지 확인할 Ip Addr</param>
    /// <returns>ture : ipAddr2 가 ipAddr1 에 종속 / false : ipAddr2 가 ipAddr1 에 종속되지 않음</returns>
    public static bool ValidationIpAddresInGroup(string ipAddr1, string ipAddr2)
    {
        bool returnResult = false;

        IPNetwork ipnetwork = IPNetwork.Parse(ipAddr1 + "/24");
        IPAddress ipaddress = IPAddress.Parse(ipAddr2);

        returnResult = IPNetwork.Contains(ipnetwork, ipaddress);

        return returnResult;
    }

}