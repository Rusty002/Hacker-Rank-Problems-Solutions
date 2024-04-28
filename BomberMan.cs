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
     * Complete the 'bomberMan' function below.
     *
     * The function is expected to return a STRING_ARRAY.
     * The function accepts following parameters:
     *  1. INTEGER n
     *  2. STRING_ARRAY grid
     */
     
     public static List<List<char>> Blast(
    List<List<char>> grid, int r, int c)
{
    var O = grid.Select(x =>
        new string('O', c).ToList())
        .ToList();
    var d = '.';

    for (int i = 0; i < r; ++i)
    {
        for (int j = 0; j < c; ++j)
        {
            if (grid[i][j].Equals('O'))
            {
                // right
                O[i][Math.Min(j + 1, c - 1)] = d;
                //left
                O[i][Math.Max(j - 1, 0)] = d;
                // mid
                O[i][j] = d;
                // up
                O[Math.Max(i - 1, 0)][j] = d;
                // down
                O[Math.Min(i + 1, r - 1)][j] = d;
            }
        } 
    }

    return O;
}

public static List<string> bomberMan(int n, List<string> grid)
{
    var cols = grid[0].Length;
    var rows = grid.Count();

    if (n <= 1)
        return grid;
    if (n % 2 == 0)
        return grid.Select(x =>
            new string('O', cols)).ToList();

    var g = grid.Select(x => x.ToList()).ToList();
    g = Blast(g, rows, cols);

    if (n == 5 || n % 4 == 1)
        g = Blast(g, rows, cols);

    var res = new List<string>();
    foreach (var x in g)
        res.Add(string.Concat(x));

    return res;
}

    // public static List<string> bomberMan(int n, List<string> grid)
    // {
    //     if(n == 1 || n == 0)
    //         return grid;
    //     else if(n % 2 == 0)
    //         return CompleteBombGrid(grid.Count, grid[0].Length);
    //     else if(n % 4 == 3)
    //         return UpdateBombGrid(grid);
    //     else
    //         return UpdateBombGrid(grid);
    // }
    
    // public static List<string> CompleteBombGrid(int n, int c)
    // {
    //     var gridContainingAllBombs = new List<string>();
    //     for(int i = 1; i <= n; i++)
    //         gridContainingAllBombs.Add(string.Concat(Enumerable.Repeat("O",c)));
    //     return gridContainingAllBombs;
    // }
    
    // public static List<string> UpdateBombGrid(List<string> grid)
    // {
    //     var updatedGrid = CompleteBombGrid(grid.Count, grid[0].Length);
    //     for(int i = 0; i < updatedGrid.Count; i++)
    //     {
    //         StringBuilder nextRow = new StringBuilder();
    //         if(i + 1 < updatedGrid.Count)
    //             nextRow.Append(updatedGrid[i + 1]);
    //         StringBuilder currentRow = new StringBuilder();
    //         currentRow.Append(updatedGrid[i]);
    //         StringBuilder previousRow = new StringBuilder();
    //         if(i - 1 >= 0)
    //             previousRow.Append(updatedGrid[i - 1]);
    //         for(int j = 0; j < updatedGrid[i].Length; j++)
    //         {
    //             if(grid[i][j] == 'O')
    //             {
    //                 currentRow[j] = '.';
    //                 if(j - 1 >= 0)
    //                     currentRow[j - 1] = '.';
    //                 if(j + 1 < grid[i].Length && grid[i][j + 1] != 'O')
    //                     currentRow[j + 1] = '.';
    //                 if(i - 1 >= 0)
    //                     previousRow[j] = '.';
    //                 if(i + 1 < grid.Count && grid[i + 1][j] != 'O')
    //                     nextRow[j] = '.';
    //             }
    //         }
    //         updatedGrid[i] = currentRow.ToString();
    //         Console.WriteLine(currentRow.ToString());
    //         if(i - 1 >= 0)
    //             updatedGrid[i - 1] = previousRow.ToString();
    //         if(i + 1 < updatedGrid.Count)
    //             updatedGrid[i + 1] = nextRow.ToString();
    //     }
    //     return updatedGrid;
    // }
}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

        int r = Convert.ToInt32(firstMultipleInput[0]);

        int c = Convert.ToInt32(firstMultipleInput[1]);

        int n = Convert.ToInt32(firstMultipleInput[2]);

        List<string> grid = new List<string>();

        for (int i = 0; i < r; i++)
        {
            string gridItem = Console.ReadLine();
            grid.Add(gridItem);
        }

        List<string> result = Result.bomberMan(n, grid);

        textWriter.WriteLine(String.Join("\n", result));

        textWriter.Flush();
        textWriter.Close();
    }
}
