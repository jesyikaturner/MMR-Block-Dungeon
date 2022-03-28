using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public static class FileHandler
{
    public static void WriteTextFile(string filename, string line)
    {
        StreamWriter writer = new StreamWriter(Application.dataPath + "/" + filename, true);
        writer.WriteLine(line);
        writer.Close();
    }

    public static List<string> ReadTextFile(string filename)
    {
        List<string> output = new List<string>();
        StreamReader reader = new StreamReader(Application.dataPath + "/" + filename);
        while (!reader.EndOfStream)
        {
            string inputLine = reader.ReadLine();
            output.Add(inputLine);
        }
        reader.Close();
        Logger.WriteToLog("FileHandler: ReadTextFile(): SUCCESS: file read, returning output list.");
        return output;
    }
}