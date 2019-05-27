using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// HelperSecurity의 요약 설명입니다.
/// </summary>
public class HelperSecurity
{
    /// <summary>
    /// XSS Injection 공격에 사용되는 Single quotation, Dobule quotation 을 제거한 값을 리턴합니다.
    /// </summary>
    /// <returns></returns>
    public static string WithoutInjectionCharacters(string plainString, out bool hasInjectionCharacters)
    {
        bool isIncludedCharacter = false;
        string returnValue = plainString;

        try
        {
            // String 정제
            if (!string.IsNullOrEmpty(plainString))
            {
                //string[] invalidCharacters = { "\"", "'", "%22", "%27", "<", ">", "%3C", "%3E", "%253C", "%253E", ";", "%3B" };
                string[] invalidCharacters = HelperCommon._INJECTION_CHARACTERS.Split(',');
                foreach (string n in invalidCharacters)
                {
                    string replaceCharacter = "";

                    if (returnValue.ToUpper().Contains(n))
                        isIncludedCharacter = true;

                    switch (n)
                    {
                        case "<":
                        case "%3C":
                            replaceCharacter = "&lt;";
                            break;
                        case ">":
                        case "%3E":
                            replaceCharacter = "&gt;";
                            break;
                        default:
                            break;
                    }

                    // 대/소문자 각각 치환
                    returnValue = returnValue.Replace(n, replaceCharacter);
                    returnValue = returnValue.Replace(n.ToLower(), replaceCharacter);
                }

                // Injection 문자가 있으면 로그
                if (isIncludedCharacter)
                {
                    string requestUrl = string.Empty;
                    string referrerUrl = string.Empty;
                    string clientIpAddr = string.Empty;
                    requestUrl = HttpContext.Current.Request.Url.AbsoluteUri;
                    clientIpAddr = HelperNetwork.GetClientIpAddress();

                    // ReferrerUrl 이 있을 경우 조회
                    try
                    {
                        if (HttpContext.Current.Request.UrlReferrer != null)
                            referrerUrl = HttpContext.Current.Request.UrlReferrer.AbsoluteUri;
                        else
                            referrerUrl = "Referrer URL not exist";
                    }
                    catch (Exception ex)
                    {
                        referrerUrl = "Failed Get Referrer URL (Exception)";
                    }

                    // Exception 상황이 아닌, Injection 의심 건을 기록하기 위함
                    string logMessage = string.Format(@"
                                                        < Secure Warning >   
                                                        [DESC]          : {0}
                                                        [URL]           : {1}
                                                        [REFERRER URL]  : {2}
                                                        [IP]            : {3}"
                                                    , "Maybe XSS, SQL Injection", requestUrl, referrerUrl, clientIpAddr);

                    HelperCommon.RegisterLogForHelperSecurity(logMessage);
                }
            }
        }
        catch (Exception ex)
        {
            HelperCommon.RegisterLogForHelperSecurity(ex.ToString());
        }

        hasInjectionCharacters = isIncludedCharacter;

        return returnValue;
    }
}