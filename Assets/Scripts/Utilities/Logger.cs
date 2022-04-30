using System;
using System.Reflection;
using System.Collections.Generic;

public static class Logger
{
    public const string FILENAME = "logfile";
    public static List<string> log = new();

    /// <summary>
    /// 
    /// </summary>
    /// <param name="methodBase"></param>
    /// <param name="logString">The string to be written to the logs.</param>
    public static void WriteErrorToLog(MethodBase methodBase, string logString)
    {
        string methodName = string.Format("{0}:{1}", methodBase.DeclaringType.Name, methodBase.Name);
        string line = string.Format("{0} {1}: ERROR: {2}.", DateTime.Now, methodName, logString);

#if UNITY_EDITOR
        FileHandler.WriteTextFile(FILENAME, line);
#endif
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="methodBase"></param>
    /// <param name="logString">The string to be written to the logs.</param>
    public static void WriteSuccessToLog(MethodBase methodBase, string logString)
    {
        string methodName = string.Format("{0}.{1}", methodBase.DeclaringType.Name, methodBase.Name);
        string line = string.Format("{0} {1}: SUCCESS: {2}.", DateTime.Now, methodName, logString);

#if UNITY_EDITOR
        FileHandler.WriteTextFile(FILENAME, line);
#endif
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="methodBase"></param>
    /// <param name="logString">The string to be written to the logs.</param>
    public static void WriteInfoToLog(MethodBase methodBase, string logString)
    {
        string methodName = string.Format("{0}.{1}", methodBase.DeclaringType.Name, methodBase.Name);
        string line = string.Format("{0} {1}: INFO: {2}.", DateTime.Now, methodName, logString);

#if UNITY_EDITOR
        FileHandler.WriteTextFile(FILENAME, line);
#endif
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="methodBase"></param>
    /// <param name="logString">The string to be written to the logs.</param>
    public static void WriteWarningToLog(MethodBase methodBase, string logString)
    {
        string methodName = string.Format("{0}.{1}", methodBase.DeclaringType.Name, methodBase.Name);
        string line = string.Format("{0} {1}: WARNING: {2}.", DateTime.Now, methodName, logString);

#if UNITY_EDITOR
        FileHandler.WriteTextFile(FILENAME, line);
#endif
    }
}
