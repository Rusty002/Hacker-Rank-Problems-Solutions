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
     * Complete the 'cavityMap' function below.
     *
     * The function is expected to return a STRING_ARRAY.
     * The function accepts STRING_ARRAY grid as parameter.
     */

    public static List<string> cavityMap(List<string> grid)
    {
        for(int i = 1; i < grid.Count - 1; i++)
            for(int j = 1; j < grid[i].Length - 1; j++)
                if
                (
                    grid[i][j] > grid[i][j - 1] && // left
                    grid[i][j] > grid[i][j + 1] && // right
                    grid[i][j] > grid[i - 1][j] && // up
                    grid[i][j] > grid[i + 1][j]    // down
                )
                    grid[i] = updateString(j, grid[i]);
        return grid;
    }
    
    public static string updateString(int j, string previousString)
    {
        StringBuilder updatedString = new StringBuilder(previousString);
        updatedString[j] = 'X';
        return updatedString.ToString();
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine().Trim());

        List<string> grid = new List<string>();

        for (int i = 0; i < n; i++)
        {
            string gridItem = Console.ReadLine();
            grid.Add(gridItem);
        }

        List<string> result = Result.cavityMap(grid);

        textWriter.WriteLine(String.Join("\n", result));

        textWriter.Flush();
        textWriter.Close();
    }
}
