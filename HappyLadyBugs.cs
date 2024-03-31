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
     * Complete the 'happyLadybugs' function below.
     *
     * The function is expected to return a STRING.
     * The function accepts STRING b as parameter.
     */
     
    public static string happyLadybugs(string b)
    {
        if(b.Length == 1)
            return b[0] == '_' ? "YES" : "NO";
        
        if(b.Contains('_'))
        {
            if(b.Count(c => c == '_') == b.Length)
                return "YES";
            return b.Any(c => c != '_' && b.Count(x => x == c) == 1) ? "NO" : "YES";
        }
        
        for(int i = 0; i < b.Length; i++)
            if(i == 0 && b[i + 1] != b[i])
                return "NO";
            else if(i == b.Length -1 && b[i] != b[i - 1])
                return "NO";
            else if(i != 0 && i != b.Length - 1 && b[i] != b[i - 1] && b[i] != b[i + 1])
                return "NO";
        
        return "YES";
        // bool canLadyBugsBeMadeHappy = false;
        // int emptySpaces = 0;
        // bool hasEveryLadyBugPair = true;
        // bool hasAllLadyBugsSameColor = false;
        // for(int i = 0; i < b.Length; i++)
        // {
        //     int pairs = 0;
        //     if(b[i] == '_')
        //         emptySpaces++;
        //     else
        //         for(int j = 0; j < b.Length; j++)
        //             if(b[i] == b[j] && b[j] != '_')
        //                 pairs++;
            
        //     if(pairs == 1)
        //     {
        //         hasEveryLadyBugPair = false;
        //         break;
        //     }
        //     else if(pairs == b.Length)
        //     {
        //         hasAllLadyBugsSameColor = true;
        //         break;
        //     }
        // }
        // if((emptySpaces > 0 && hasEveryLadyBugPair) || hasAllLadyBugsSameColor)
        //     canLadyBugsBeMadeHappy = true;
        
        // return canLadyBugsBeMadeHappy ? "YES" : "NO";
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int g = Convert.ToInt32(Console.ReadLine().Trim());

        for (int gItr = 0; gItr < g; gItr++)
        {
            int n = Convert.ToInt32(Console.ReadLine().Trim());

            string b = Console.ReadLine();

            string result = Result.happyLadybugs(b);

            textWriter.WriteLine(result);
        }

        textWriter.Flush();
        textWriter.Close();
    }
}
