using System;
using System.Reflection;
using System.Collections.Generic;

public static class Logger
{
    public const string FILENAME = "logfile";
    public static List<string> log = new();

    /// <summary>
    /// Writes an error to the logfile. Make sure to add 'using System.Reflection;' to the file calling this.
    /// </summary>
    /// <param name="methodBase">MethodBase.GetCurrentMethod() :: Pass the calling method class and name to display in the log.</param>
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
    /// Writes a success to the logfile. Make sure to add 'using System.Reflection;' to the file calling this.
    /// </summary>
    /// <param name="methodBase">MethodBase.GetCurrentMethod() :: Pass the calling method class and name to display in the log.</param>
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
    /// Writes to the logfile. Make sure to add 'using System.Reflection;' to the file calling this.
    /// </summary>
    /// <param name="methodBase">MethodBase.GetCurrentMethod() :: Pass the calling method class and name to display in the log.</param>
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
    /// Writes a warning to the logfile. Make sure to add 'using System.Reflection;' to the file calling this.
    /// </summary>
    /// <param name="methodBase">MethodBase.GetCurrentMethod() :: Pass the calling method class and name to display in the log.</param>
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
