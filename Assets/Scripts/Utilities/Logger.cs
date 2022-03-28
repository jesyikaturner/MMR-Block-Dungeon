using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public static class Logger
{
    public static List<string> log = new();

    public static void WriteToLog(string data)
    {

#if UNITY_EDITOR
        string line = string.Format("{0} {1}", DateTime.Now, data);
        FileHandler.WriteTextFile("logfile", line);
#endif
    }
}
