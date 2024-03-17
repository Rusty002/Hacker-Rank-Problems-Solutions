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
     * Complete the 'kaprekarNumbers' function below.
     *
     * The function accepts following parameters:
     *  1. INTEGER p
     *  2. INTEGER q
     */

    public static void kaprekarNumbers(int p, int q)
    {
        string numbers = "";
        for(double i = p; i <= q; i++)
            if(IsNumberKaprekar(i))
                numbers += i + " ";
        
        if(numbers.Length == 0)
            Console.WriteLine("INVALID RANGE");
        else
            Console.WriteLine(numbers);
    }
    
    public static bool IsNumberKaprekar(double num)
    {
        string square = Convert.ToString(num*num);
        int d = square.Length / 2;
        double sum = 1;
        if(square.Length > 1)
            sum =  Convert.ToDouble(square.Substring(0, d)) +
                    Convert.ToDouble(square.Substring(d));
        if(sum == num)
            return true;
        else 
            return false;
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        int p = Convert.ToInt32(Console.ReadLine().Trim());

        int q = Convert.ToInt32(Console.ReadLine().Trim());

        Result.kaprekarNumbers(p, q);
    }
}
 
