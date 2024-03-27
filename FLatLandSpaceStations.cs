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

class Solution {

    // Complete the flatlandSpaceStations function below.
    
    static int flatlandSpaceStations(int n, int[] c, int m) {
        if(n == m)
            return 0;
        
        List<int> distances = new List<int>();
        for(int i = 0; i < n; i++)
        {
            int minimumDistance = Int32.MaxValue;
            
            if(c.Length > 1)
            {
                foreach(int number in c)
                    if(Math.Abs(number - i) < minimumDistance)
                        minimumDistance = Math.Abs(number - i);
            }
            else
                minimumDistance = Math.Abs(i - c[0]);
            distances.Add(minimumDistance); 
        }
        
        distances.Sort();
        return distances[distances.Count - 1];
    }

    static void Main(string[] args) {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string[] nm = Console.ReadLine().Split(' ');

        int n = Convert.ToInt32(nm[0]);

        int m = Convert.ToInt32(nm[1]);

        int[] c = Array.ConvertAll(Console.ReadLine().Split(' '), cTemp => Convert.ToInt32(cTemp))
        ;
        int result = flatlandSpaceStations(n, c, m);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
