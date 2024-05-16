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
     * Complete the 'dayOfProgrammer' function below.
     *
     * The function is expected to return a STRING.
     * The function accepts INTEGER year as parameter.
     */

    public static string dayOfProgrammer(int year)
    {
        if(year > 1919)
            return CalculateDaysForGregorianCalendar(year); 
        else
            return CalculateDaysForJulianCalendar(year);
    }
    
    public static string CalculateDaysForGregorianCalendar(int year)
    {
        if((year % 400 == 0) || (year % 4 == 0 && year % 100 != 0))
            return String.Format("{0}.0{1}.{2}", 12, 9, year);
        else
            return String.Format("{0}.0{1}.{2}", 13, 9, year);
    }
    
    public static string CalculateDaysForJulianCalendar(int year)
    {
        if(year % 4 == 0)
            return String.Format("{0}.0{1}.{2}", 12, 9, year);
        else if(year == 1918)
            return String.Format("{0}.0{1}.{2}", 26, 9, year);
        else
            return String.Format("{0}.0{1}.{2}", 13, 9, year);
    }
}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int year = Convert.ToInt32(Console.ReadLine().Trim());

        string result = Result.dayOfProgrammer(year);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
