using System.Collections.Generic;
using System.IO;
using System.Reflection;
using UnityEngine;

public static class FileHandler
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="filename">The filename of the text file to be written to.</param>
    /// <param name="line">The line to be written to the text file.</param>
    public static void WriteTextFile(string filename, string line)
    {
        StreamWriter writer = new StreamWriter(Application.dataPath + "/" + filename, true);
        writer.WriteLine(line);
        writer.Close();
    }

    /// <summary>
    /// Read text file, add each line to a list, then return the output.
    /// </summary>
    /// <param name="filename">The filename of the text file to be read.</param>
    /// <returns>Returns a list of all the previously entered logs from the read text file.</returns>
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
        Logger.WriteSuccessToLog(MethodBase.GetCurrentMethod(), "file read, returning output list");
        return output;
    }
}