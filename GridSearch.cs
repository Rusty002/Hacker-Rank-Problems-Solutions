using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Result
{

    /*
     * Complete the 'gridSearch' function below.
     *
     * The function is expected to return a STRING.
     * The function accepts following parameters:
     *  1. STRING_ARRAY G
     *  2. STRING_ARRAY P
     */

    public static string gridSearch(List<string> G, List<string> P)
    {
        var diff = G[0].Length - P[0].Length + 1;
        var pattern = string.Join($".{{{diff}}}", P);
        var input = string.Join('|', G);
        if (Regex.IsMatch(input, pattern))
            return "YES";
        return "NO";
    }
    
    // public static string gridSearch(List<string> G, List<string> P)
    // {
        
        
    //     bool isPatternPresent = false;
    //     int matchPatternIndex = 0;
    //     for(int i = 0; i < G.Count; i++)
    //     {
    //         if(matchPatternIndex == P.Count)
    //         {
    //             isPatternPresent = true;
    //             break;
    //         }
    //         if(G[i].Contains(P[matchPatternIndex]))
    //             matchPatternIndex++;
    //         else if(matchPatternIndex > 0)
    //             matchPatternIndex = 0;
    //     }
    //     if(G.Count == matchPatternIndex)
    //         isPatternPresent = true;
    //     return isPatternPresent ? "YES" : "NO";
    // }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int t = Convert.ToInt32(Console.ReadLine().Trim());

        for (int tItr = 0; tItr < t; tItr++)
        {
            string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

            int R = Convert.ToInt32(firstMultipleInput[0]);

            int C = Convert.ToInt32(firstMultipleInput[1]);

            List<string> G = new List<string>();

            for (int i = 0; i < R; i++)
            {
                string GItem = Console.ReadLine();
                G.Add(GItem);
            }

            string[] secondMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

            int r = Convert.ToInt32(secondMultipleInput[0]);

            int c = Convert.ToInt32(secondMultipleInput[1]);

            List<string> P = new List<string>();

            for (int i = 0; i < r; i++)
            {
                string PItem = Console.ReadLine();
                P.Add(PItem);
            }

            string result = Result.gridSearch(G, P);

            textWriter.WriteLine(result);
        }

        textWriter.Flush();
        textWriter.Close();
    }
}
