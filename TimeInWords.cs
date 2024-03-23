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
     * Complete the 'timeInWords' function below.
     *
     * The function is expected to return a STRING.
     * The function accepts following parameters:
     *  1. INTEGER h
     *  2. INTEGER m
     */

    public static string timeInWords(int h, int m)
    {
        string time = "";
        time = timeInMinutes(m);
        if(m > 0 && m <= 30)
            time += " past ";
        if(m > 30)
            time += " to ";
        
        if(m == 0)
            time = timeInHours(h) + time;
        else if(m > 0 && m <= 30)
            time += timeInHours(h);
        else if(m > 30 && m < 60 && h != 12)
            time += timeInHours(h + 1);
        else if(m > 30 && m < 60 && h == 12)
            time += timeInHours(1);
        return time;
    }
    
    public static string timeInMinutes(int m)
    {
        if(m == 0)
            return " o' clock";
        else if(m == 1 || m == 59)
            return "one minute";
        else if(m == 2 || m == 58)
            return "two minutes";
        else if(m == 3 || m == 57)
            return "three minutes";
        else if(m == 4 || m == 56)
            return "four minutes";
        else if(m == 5 || m == 55)
            return "five minutes";
        else if(m == 6 || m == 54)
            return "six minutes";
        else if(m == 7 || m == 53)
            return "seven minutes";
        else if(m == 8 || m == 52)
            return "eight minutes";
        else if(m == 9 || m == 51)
            return "nine minutes";
        else if(m == 10 || m == 50)
            return "ten minutes";
        else if(m == 11 || m == 49)
            return "eleven minutes";
        else if(m == 12 || m == 48)
            return "twelve minutes";
        else if(m == 13 || m == 47)
            return "thirteen minutes";
        else if(m == 14 || m == 46)
            return "fourteen minutes";
        else if(m == 15 || m == 45)
            return "quarter";
        else if(m == 16 || m == 44)
            return "sixteen minutes";
        else if(m == 17 || m == 43)
            return "seventeen minutes";
        else if(m == 18 || m == 42)
            return "eighteen minutes";
        else if(m == 19 || m == 41)
            return "nineteen minutes";
        else if(m == 20 || m == 40)
            return "twenty minutes";
        else if(m == 21 || m == 39)
            return "twenty one minutes";
        else if(m == 22 || m == 38)
            return "twenty two minutes";
        else if(m == 23 || m == 37)
            return "twenty three minutes";
        else if(m == 24 || m == 36)
            return "twenty four minutes";
        else if(m == 25 || m == 35)
            return "twenty five minutes";
        else if(m == 26 || m == 34)
            return "twenty six minutes";
        else if(m == 27 || m == 33)
            return "twenty seven minutes";
        else if(m == 28 || m == 32)
            return "twenty eight minutes";
        else if(m == 29 || m == 31)
            return "twenty nine minutes";
        else if(m == 30)
            return "half";
        else
            return "";        
    }
    
    public static string timeInHours(int h)
    {
        if(h == 1)
            return "one";
        else if(h == 2)
            return "two";
        else if(h == 3)
            return "three";
        else if(h == 4)
            return "four";
        else if(h == 5)
            return "five";
        else if(h == 6)
            return "six";
        else if(h == 7)
            return "seven";
        else if(h == 8)
            return "eight";
        else if(h == 9)
            return "nine";
        else if(h == 10)
            return "ten";
        else if(h == 11)
            return "eleven";
        else if(h == 12)
            return "twelve";
        else 
            return "";   
    }
}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int h = Convert.ToInt32(Console.ReadLine().Trim());

        int m = Convert.ToInt32(Console.ReadLine().Trim());

        string result = Result.timeInWords(h, m);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
