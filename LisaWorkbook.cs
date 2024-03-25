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
     * Complete the 'workbook' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts following parameters:
     *  1. INTEGER n
     *  2. INTEGER k
     *  3. INTEGER_ARRAY arr
     */

    public static int workbook(int n, int k, List<int> arr)
    {
        int specialProblems = 0;
        int pageNumber = 0;
        for(int i = 0; i < arr.Count; i++)
        {
            pageNumber++;
            int startProblems = 1;
            int endProblems;
            if(arr[i] < k)
                endProblems = arr[i];
            else
                endProblems = k;
            
            if(pageNumber >= 1 && pageNumber <= endProblems)
                specialProblems++;
            int remainingProblems = arr[i] - k;
            while(remainingProblems > 0)
            {
                pageNumber++;
                if(remainingProblems < k)
                {
                    startProblems  = 1 + endProblems;
                    endProblems += remainingProblems;
                }
                else
                {
                    startProblems += k;
                    endProblems += k;
                }
                if(pageNumber >= startProblems && pageNumber <= endProblems)
                    specialProblems++;
                remainingProblems -= k;
            }
        }
        return specialProblems;
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

        int n = Convert.ToInt32(firstMultipleInput[0]);

        int k = Convert.ToInt32(firstMultipleInput[1]);

        List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();

        int result = Result.workbook(n, k, arr);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
