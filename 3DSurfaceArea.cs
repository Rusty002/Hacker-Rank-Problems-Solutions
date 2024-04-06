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
     * Complete the 'surfaceArea' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts 2D_INTEGER_ARRAY A as parameter.
     */

    public static int surfaceArea(List<List<int>> A)
    {
        int priceOfToy = 0;
        if(A.Count == 1)
            return A[0][0] == 0 ? 0 : 4*A[0][0] + 2;
        else
        {
            for(int i = 0; i < A.Count; i++)
            {
                int surfaceAreaOfColumn = 0;
                for(int j = 0; j < A[i].Count; j++)
                {
                    int surfaceAreaOfSingleCube = 0;
                    surfaceAreaOfSingleCube++;
                    surfaceAreaOfSingleCube++;
                    if(j - 1 < 0)
                        surfaceAreaOfSingleCube += A[i][j] * 1;
                    else if (j - 1 >= 0 && A[i][j] - A[i][j - 1] > 0)
                        surfaceAreaOfSingleCube += (A[i][j] - A[i][j - 1]) * 1;
                    if(j + 1 < A[i].Count && A[i][j] - A[i][j + 1] > 0)
                        surfaceAreaOfSingleCube += (A[i][j] - A[i][j + 1]) * 1;
                    else if(j + 1 == A[i].Count)
                        surfaceAreaOfSingleCube += A[i][j] * 1;
                    if(i - 1 < 0)
                        surfaceAreaOfSingleCube += A[i][j] * 1;
                    else if( i - 1 >= 0 && A[i][j] - A[i - 1][j] > 0)
                        surfaceAreaOfSingleCube += (A[i][j] - A[i - 1][j]) * 1;
                    if(i + 1 < A.Count && A[i][j] - A[i + 1][j] > 0)
                        surfaceAreaOfSingleCube += (A[i][j] - A[i + 1][j]) * 1;
                    else if(i + 1 == A.Count)
                        surfaceAreaOfSingleCube += A[i][j] * 1;
                    surfaceAreaOfColumn += surfaceAreaOfSingleCube; 
                }
                priceOfToy += surfaceAreaOfColumn;
            }
        }
        return priceOfToy;
    }
}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

        int H = Convert.ToInt32(firstMultipleInput[0]);

        int W = Convert.ToInt32(firstMultipleInput[1]);

        List<List<int>> A = new List<List<int>>();

        for (int i = 0; i < H; i++)
        {
            A.Add(Console.ReadLine().TrimEnd().Split(' ').ToList().Select(ATemp => Convert.ToInt32(ATemp)).ToList());
        }

        int result = Result.surfaceArea(A);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
