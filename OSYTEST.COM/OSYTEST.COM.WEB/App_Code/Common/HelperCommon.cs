using Newtonsoft.Json;
using NLog;
using NLog.Config;
using NLog.Targets;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

/// <summary>
/// HelperCommon의 요약 설명입니다.
/// </summary>
public class HelperCommon
{
    #region Properties

    internal static string _EXECUTING_ASSEMBLY_NAME = Path.GetFileNameWithoutExtension(System.Reflection.Assembly.GetExecutingAssembly().Location);

    internal static string _VERSIONING_INTERVAL_MINUTES { get; set; }
    internal static string _INJECTION_CHARACTERS { get; set; }
    internal static string _NLOG_ROOT_PATH { get; set; }
    internal static dynamic _ASSEMBLY_CONFIGURATION { get; set; }
    internal static Logger _NLOGGER_HelperCommon { get; set; }
    internal static Logger _NLOGGER_HelperFile { get; set; }
    internal static Logger _NLOGGER_HelperNetwork { get; set; }
    internal static Logger _NLOGGER_HelperSecurity { get; set; }
    internal static Logger _NLOGGER_HelperSecurityForSecure { get; set; }

    #endregion / Properties


    #region Structure

    /// <summary>
    /// INTERPARKTOUR.UTIL.COMMON 클래스의 생성자
    /// </summary>
    static HelperCommon()
    {
        InitCommonAndNLog();
    }

    #endregion / Structure


    #region Settings For NLog

    /// <summary>
    /// Setting For NLog in Codes 
    /// </summary>
    private static void InitCommonAndNLog()
    {
        try
        {
            #region INTERPARKTOUR.UTIL.DLL 의 JSON 파일 환경 파일 내용 읽기

            string jsonConfig = System.IO.File.ReadAllText(GetAssemblyConfigPath() + ".config");

            dynamic obj = JsonConvert.DeserializeObject<dynamic>(jsonConfig);
            _ASSEMBLY_CONFIGURATION = obj;

            // Js, Css 등의 Script 의 Versioning 정보를 갱신하는 주기 ( Minute 기준 )
            _VERSIONING_INTERVAL_MINUTES = GetAssemblySetting("VersioningIntervalMinutes");
            if (string.IsNullOrEmpty(_VERSIONING_INTERVAL_MINUTES))
                _VERSIONING_INTERVAL_MINUTES = "1";

            // Site Injection, XSS 공격 방어를 위한 문자열 Set 
            _INJECTION_CHARACTERS = GetAssemblySetting("InjectionInvalidCharacters");

            // NLog 가 기록될 Root 경로
            _NLOG_ROOT_PATH = GetAssemblySetting("NLogRootFolder");

            #endregion / INTERPARKTOUR.UTIL.DLL 의 JSON 파일 환경 파일 내용 읽기


            #region INTERPARKTOUR.UTIL.DLL 에서 사용할 NLOG 환경 파일 내용 읽기

            //////NLog.LogManager.Configuration = new NLog.Config.XmlLoggingConfiguration(GetAssemblyConfigPath() + ".NLog.config", true);
            //////_NLOGGER = LogManager.GetCurrentClassLogger();

            #endregion / INTERPARKTOUR.UTIL.DLL 에서 사용할 NLOG 환경 파일 내용 읽기


            #region Nlog : Step 1. Create configuration object 

            var config = new LoggingConfiguration();

            #endregion / Nlog : Step 1. Create configuration object 


            #region Nlog : Step 2. Create targets and add them to the configuration 

            //////var consoleTarget = new ColoredConsoleTarget();
            //////config.AddTarget("INTERPARKTOUR_UTIL_ERROR", consoleTarget);

            var fileTargetForHelperCommon = new FileTarget();
            config.AddTarget("INTERPARKTOUR_UTIL_ERROR_HelperCommon", fileTargetForHelperCommon);

            var fileTargetForHelperFile = new FileTarget();
            config.AddTarget("INTERPARKTOUR_UTIL_ERROR_HelperFile", fileTargetForHelperFile);

            var fileTargetForHelperNetwork = new FileTarget();
            config.AddTarget("INTERPARKTOUR_UTIL_ERROR_HelperNetwork", fileTargetForHelperNetwork);

            var fileTargetForHelperSecurity = new FileTarget();
            config.AddTarget("INTERPARKTOUR_UTIL_ERROR_HelperSecurity", fileTargetForHelperSecurity);

            var fileTargetForHelperSecurityForSecure = new FileTarget();
            config.AddTarget("INTERPARKTOUR_UTIL_ERROR_HelperSecurity_Secure", fileTargetForHelperSecurityForSecure);

            #endregion / Nlog : Step 2. Create targets and add them to the configuration 


            #region Nlog : Step 3. Set target properties 

            string entryAssemblyName = GetEntryAssemblyFolderName();

            // Log File Path : HelperCommon ( EX : D:\ComLog\INTERPARKTOUR.UTIL\HelperCommon\TOUR.INTERPARK.COM.log )
            fileTargetForHelperCommon.FileName = string.Format(_NLOG_ROOT_PATH + "{0}\\{1}\\{2}\\${{shortdate}}.log", _EXECUTING_ASSEMBLY_NAME, "HelperCommon", entryAssemblyName);
            fileTargetForHelperCommon.Layout = "[${longdate}]${callsite}|${level:uppercase=true}|${exception} : ${message}";

            // Log File Path : HelperFile
            fileTargetForHelperFile.FileName = string.Format(_NLOG_ROOT_PATH + "{0}\\{1}\\{2}\\${{shortdate}}.log", _EXECUTING_ASSEMBLY_NAME, "HelperFile", entryAssemblyName);
            fileTargetForHelperFile.Layout = "[${longdate}]${callsite}|${level:uppercase=true}|${exception} : ${message}";

            // Log File Path : HelperNetwork
            fileTargetForHelperNetwork.FileName = string.Format(_NLOG_ROOT_PATH + "{0}\\{1}\\{2}\\${{shortdate}}.log", _EXECUTING_ASSEMBLY_NAME, "HelperNetwork", entryAssemblyName);
            fileTargetForHelperNetwork.Layout = "[${longdate}]${callsite}|${level:uppercase=true}|${exception} : ${message}";

            // Log File Path : HelperSecurity
            fileTargetForHelperSecurity.FileName = string.Format(_NLOG_ROOT_PATH + "{0}\\{1}\\{2}\\${{shortdate}}.log", _EXECUTING_ASSEMBLY_NAME, "HelperSecurity", entryAssemblyName);
            fileTargetForHelperSecurity.Layout = "[${longdate}]${callsite}|${level:uppercase=true}|${exception} : ${message}";

            // Log File Path : HelperSecurity For Secure ( XSS, Injection )
            fileTargetForHelperSecurityForSecure.FileName = string.Format(_NLOG_ROOT_PATH + "{0}\\{1}\\{2}\\${{shortdate}}.log", _EXECUTING_ASSEMBLY_NAME, "HelperSecurityForSecure", entryAssemblyName);
            fileTargetForHelperSecurityForSecure.Layout = "[${longdate}]${callsite}|${level:uppercase=true}|${exception} : ${message}";

            #endregion / Nlog : Step 3. Set target properties 


            #region Nlog : Step 4. Define rules

            var rule1 = new LoggingRule("INTERPARKTOUR.UTIL.HelperCommon", LogLevel.Debug, fileTargetForHelperCommon);
            var rule2 = new LoggingRule("INTERPARKTOUR.UTIL.HelperFile", LogLevel.Debug, fileTargetForHelperFile);
            var rule3 = new LoggingRule("INTERPARKTOUR.UTIL.HelperNetwork", LogLevel.Debug, fileTargetForHelperNetwork);
            var rule4 = new LoggingRule("INTERPARKTOUR.UTIL.HelperSecurity", LogLevel.Debug, fileTargetForHelperSecurity);
            var rule4_1 = new LoggingRule("INTERPARKTOUR.UTIL.HelperSecurityForSecure", LogLevel.Debug, fileTargetForHelperSecurityForSecure);

            config.LoggingRules.Add(rule1);
            config.LoggingRules.Add(rule2);
            config.LoggingRules.Add(rule3);
            config.LoggingRules.Add(rule4);
            config.LoggingRules.Add(rule4_1);

            #endregion / Nlog : Step 4. Define rules


            #region Nlog : Step 5. Activate the configuration

            LogManager.Configuration = config;

            _NLOGGER_HelperCommon = LogManager.GetLogger("INTERPARKTOUR.UTIL.HelperCommon");
            _NLOGGER_HelperFile = LogManager.GetLogger("INTERPARKTOUR.UTIL.HelperFile");
            _NLOGGER_HelperNetwork = LogManager.GetLogger("INTERPARKTOUR.UTIL.HelperNetwork");
            _NLOGGER_HelperSecurity = LogManager.GetLogger("INTERPARKTOUR.UTIL.HelperSecurity");
            _NLOGGER_HelperSecurityForSecure = LogManager.GetLogger("INTERPARKTOUR.UTIL.HelperSecurityForSecure");

            #endregion / Nlog : Step 5. Activate the configuration
        }
        catch (Exception ex)
        { }
    }

    /// <summary>
    /// 현재 Assembly 가 존재하는 물리적 경로를 반환합니다.
    /// </summary>
    /// <returns></returns>
    internal static string GetAssemblyConfigPath()
    {
        string returnResult = string.Empty;

        try
        {
            string assemblyConfigPath = "Nameless";
            string[] tmpArray = null;

            if (System.Reflection.Assembly.GetExecutingAssembly() != null)
            {
                // EntryAssembly 가 .exe 일 경우 
                assemblyConfigPath = System.Reflection.Assembly.GetExecutingAssembly().CodeBase;
            }
            else
            {
                // System.Reflection.Assembly.GetEntryAssembly() 가 null 일 경우는 Web 으로 가정
                assemblyConfigPath = System.Web.HttpContext.Current.Server.MapPath("~") + _EXECUTING_ASSEMBLY_NAME;
            }

            // .exe 가 아닐 경우 다른 방법으로 구하기 위함
            tmpArray = assemblyConfigPath.Split(new char[] { '.' }, StringSplitOptions.RemoveEmptyEntries);

            // exe 파일의 경우 실행 파일 명을 구하고, 그 외의 경우( WEB ) /bin 한 단계 위 경로까지 구함
            if (tmpArray != null && tmpArray[tmpArray.Length - 1] == "exe")
                assemblyConfigPath = System.Reflection.Assembly.GetExecutingAssembly().Location;
            else
            {
                // URI 형태를 물리 경로로 변환
                string tmpLocalPath = new Uri(assemblyConfigPath).LocalPath;
                string[] tmp = tmpLocalPath.Split(new char[] { '\\' }, StringSplitOptions.RemoveEmptyEntries);

                string tmpResult = string.Empty;

                // /BIN 의 상위 폴더명 찾기
                foreach (string n in tmp)
                {
                    if (n.ToUpper().Equals("BIN"))
                    {
                        // /bin 의 상위 폴더 경로 + Assembly Name
                        tmpResult += _EXECUTING_ASSEMBLY_NAME;
                        break;
                    }

                    tmpResult += n + "\\";
                }

                assemblyConfigPath = tmpResult;
            }

            returnResult = assemblyConfigPath;
        }
        catch (Exception ex)
        {
            HelperCommon.RegisterLogForHelperCommon(ex.ToString());
        }

        return returnResult;
    }

    /// <summary>
    /// 현재 Assembly 가 존재하는 물리적 폴더명을 반환합니다.
    /// </summary>
    /// <returns></returns>
    internal static string GetEntryAssemblyFolderName()
    {
        string returnResult = string.Empty;

        try
        {
            string entryAssemblyName = "Nameless";
            string[] tmpArray = null;

            if (System.Reflection.Assembly.GetEntryAssembly() != null)
            {
                // EntryAssembly 가 .exe 일 경우 
                entryAssemblyName = System.Reflection.Assembly.GetEntryAssembly().CodeBase;
            }
            else
            {
                // System.Reflection.Assembly.GetEntryAssembly() 가 null 일 경우는 Web 으로 가정
                entryAssemblyName = System.Web.HttpContext.Current.Server.MapPath("~"); // + _EXECUTING_ASSEMBLY_NAME;
            }

            // .exe 가 아닐 경우 다른 방법으로 구하기 위함
            tmpArray = entryAssemblyName.Split(new char[] { '.' }, StringSplitOptions.RemoveEmptyEntries);

            // exe 파일의 경우 실행 파일 명을 구하고, 그 외의 경우( WEB ) /bin 한 단계 위 폴더명을 구함
            if (tmpArray != null && tmpArray[tmpArray.Length - 1] == "exe")
            {
                string[] tmp = entryAssemblyName.Split(new char[] { '\\' }, StringSplitOptions.RemoveEmptyEntries);

                entryAssemblyName = tmp[tmp.Length - 1];
            }
            else
            {
                string[] tmp = entryAssemblyName.Split(new char[] { '\\' }, StringSplitOptions.RemoveEmptyEntries);

                entryAssemblyName = tmp[tmp.Length - 1];
            }

            returnResult = entryAssemblyName;
        }
        catch (Exception ex)
        {
            HelperCommon.RegisterLogForHelperCommon(ex.ToString());
        }

        return returnResult;
    }

    /// <summary>
    /// Json Object 에서 AssemblySettings 에 속한 Key 값을 매개변수로 받아 해당 값을 반환합니다.
    /// </summary>
    /// <param name="keyName"></param>
    /// <returns></returns>
    internal static string GetAssemblySetting(string keyName)
    {
        string returnResult = string.Empty;

        if (_ASSEMBLY_CONFIGURATION != null)
        {
            returnResult = _ASSEMBLY_CONFIGURATION["Data"]["AssemblySettings"][keyName];
        }

        return returnResult;
    }

    #endregion / Settings For NLog


    #region Methods - Log

    /// <summary>
    /// INTERPARKTOUR.UTIL.HelperCommon 에서 생성되는 ERROR 를 NLOG 로 등록합니다.
    /// </summary>
    /// <param name="message"></param>
    public static void RegisterLogForHelperCommon(string message)
    {
        try
        {
            _NLOGGER_HelperCommon.Error(message);
        }
        catch (Exception ex)
        { }
    }

    /// <summary>
    /// INTERPARKTOUR.UTIL.HelperFile 에서 생성되는 ERROR 를 NLOG 로 등록합니다.
    /// </summary>
    /// <param name="message"></param>
    internal static void RegisterLogForHelperFile(string message)
    {
        try
        {
            _NLOGGER_HelperFile.Error(message);
        }
        catch (Exception ex)
        { }
    }

    /// <summary>
    /// INTERPARKTOUR.UTIL.HelperNetwork 에서 생성되는 ERROR 를 NLOG 로 등록합니다.
    /// </summary>
    /// <param name="message"></param>
    internal static void RegisterLogForHelperNetwork(string message)
    {
        try
        {
            _NLOGGER_HelperNetwork.Error(message);
        }
        catch (Exception ex)
        { }
    }

    /// <summary>
    /// INTERPARKTOUR.UTIL.HelperSecurity 에서 생성되는 ERROR 를 NLOG 로 등록합니다.
    /// </summary>
    /// <param name="message"></param>
    internal static void RegisterLogForHelperSecurity(string message)
    {
        try
        {
            _NLOGGER_HelperSecurity.Error(message);
        }
        catch (Exception ex)
        { }
    }

    /// <summary>
    /// INTERPARKTOUR.UTIL.HelperSecurity 에서 생성되는 ERROR 를 NLOG 로 등록합니다. ( XSS, Injection 시도 확인 용도 )
    /// </summary>
    /// <param name="message"></param>
    internal static void RegisterLogForHelperSecurityForSecure(string message)
    {
        try
        {
            _NLOGGER_HelperSecurityForSecure.Error(message);
        }
        catch (Exception ex)
        { }
    }

    #endregion / Methods - Log


    #region Methods - Common Utility

    private static Random random = new Random();

    /// <summary>
    /// Random 문자열을 생성하여 반환합니다.
    /// </summary>
    /// <param name="length">반환될 문자열 길이</param>
    /// <returns></returns>
    public static string GenerateRandomString(int length)
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        return new string(Enumerable.Repeat(chars, length)
          .Select(s => s[random.Next(s.Length)]).ToArray());
    }

    #endregion / Methods - Common Utility
}