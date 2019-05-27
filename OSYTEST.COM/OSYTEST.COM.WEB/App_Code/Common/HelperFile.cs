using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Caching;

/// <summary>
/// HelperFile의 요약 설명입니다.
/// </summary>
public class HelperFile
{
    /// <summary>
    /// URL 경로에 ?v=20160818131300 과 같은 형태의 버전 번호가 결합된 문자열을 반환합니다.
    /// </summary>
    /// <param name="context">HttpContext</param>
    /// <param name="fileNameOrUrl">Url 경로 ( ex : /global/js/sample.js Or http://tour.interpark.com/css/test.css )</param>
    /// <returns></returns>
    public static string GetJsWithVersionCode(string fileNameOrUrl)
    {
        string returnResult = string.Empty;
        bool isFullUrl = false;

        try
        {
            if (!string.IsNullOrEmpty(fileNameOrUrl) && fileNameOrUrl.Substring(0, 4).ToUpper().Equals("HTTP"))
                isFullUrl = true;

            string version = string.Empty;
            version = GetJsFileVersionWithCache(fileNameOrUrl, isFullUrl);

            returnResult = fileNameOrUrl + "?v=" + version;
        }
        catch (Exception ex)
        {
            string logMessage = string.Format(@"
                                                < Utility Error >   
                                                [FILE]      : {0}
                                                [MESSAGE]   : {1}"
                                            , fileNameOrUrl, ex.ToString());
        }

        return returnResult;
    }

    /// <summary>
    /// Cache 를 조회하여, Version 정보를 가져오거나 Cache 가 없을 경우 Version 정보를 생성하고 이를 반환합니다.
    /// </summary>
    /// <param name="context">HttpContext</param>
    /// <param name="fileName">파일 경로 ( Url Path. ex : /global/js/sample.js )</param>
    /// <param name="isFullUrl">상대 경로인지, http Full Url 인지 여부</param>
    /// <returns>yyyyMMddhhmmss 형태의 Version Code. ex : 201608181023 </returns>
    private static string GetJsFileVersionWithCache(string fileName, bool isFullUrl)
    {
        string returnResult = string.Empty;

        string filePhysicalPathOrUrl = string.Empty;

        // 상대 경로(사이트 내부 파일) 의 경우 물리 경로 구함
        if (isFullUrl == false)
            filePhysicalPathOrUrl = HttpContext.Current.Server.MapPath(fileName);

        if (HttpContext.Current.Cache[filePhysicalPathOrUrl] == null)
        {
            // 파일 정보를 기반으로 Version Number 생성
            string version = GetFileVersion(filePhysicalPathOrUrl, isFullUrl);

            // .Config 에 기록된 갱신 주기 가져오기
            int refreshInterval = Convert.ToInt32(HelperCommon._VERSIONING_INTERVAL_MINUTES);

            // 한번 조회한 파일의 경우 Cache 에 저장하여 부하 감소 ( 상대 경로일 경우 Key 는 PhysicalPath, Full Url 의 경우 Url 경로가 Key 가 됨 )
            HttpContext.Current.Cache.Add(filePhysicalPathOrUrl, version, null, DateTime.Now.AddMinutes(refreshInterval), TimeSpan.Zero, CacheItemPriority.Normal, null);

            returnResult = version;
        }
        else
        {
            // Cache 에 있는 경우 Cache 에 저장된 값 리턴
            returnResult = HttpContext.Current.Cache[filePhysicalPathOrUrl] as string;
        }

        return returnResult;
    }

    /// <summary>
    /// 파일 물리적인 정보를 읽어와 yyyyMMddHHmmss 형태의 Version 정보를 반환합니다. ( Full Url 일 경우 현재 시각 기준으로 마킹 )
    /// </summary>
    /// <param name="fileName"></param>
    /// <param name="isFullUrl"></param>
    /// <returns></returns>
    private static string GetFileVersion(string filePhysicalPathOrUrl, bool isFullUrl)
    {
        string returnReulst = string.Empty;

        if (isFullUrl == false)
        {
            // 파일 존재 체크
            if (File.Exists(filePhysicalPathOrUrl))
                returnReulst = new System.IO.FileInfo(filePhysicalPathOrUrl).LastWriteTime.ToString("yyyyMMddHHmmss");
        }
        else
        {
            returnReulst = HelperCommon.GenerateRandomString(14);
        }

        return returnReulst;
    }
}

