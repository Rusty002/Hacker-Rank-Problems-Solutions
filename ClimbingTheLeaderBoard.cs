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
     * Complete the 'climbingLeaderboard' function below.
     *
     * The function is expected to return an INTEGER_ARRAY.
     * The function accepts following parameters:
     *  1. INTEGER_ARRAY ranked
     *  2. INTEGER_ARRAY player
     *  It is not optimized
     */

    public static List<int> climbingLeaderboard(List<int> ranked, List<int> player)
    {
        if(player.Count == 0)
            return new List<int>();
        else if(ranked.Count == 0)
            return generateRanksForPlayer(player); 
        else
            return generateComparativeRanks(ranked, player);
    }
    
    public static List<int> generateComparativeRanks(List<int> ranked, List<int> player)
    {
        var playerRanking = new List<int>();
        var ranks = new HashSet<int>(ranked);
        var rankedList = new List<int>(ranks);
        foreach(int play in player)
            if(play >= rankedList[0])
                playerRanking.Add(1);
            else if( play < rankedList[rankedList.Count - 1])
                playerRanking.Add(rankedList.Count + 1);
            else if( play == rankedList[rankedList.Count - 1])
                playerRanking.Add(rankedList.Count);
            else
                for(int i = 1; i < rankedList.Count; i++)
                    if(play > rankedList[i])
                    {
                        playerRanking.Add(i + 1);
                        break;
                    }
                    else if(play == rankedList[i])
                    {
                        playerRanking.Add(i + 1);
                        break;
                    }
        return playerRanking;
    }
    
    public static List<int> generateRanksForPlayer(List<int> player)
    {
        var playerRanking = new List<int>();
        var ranks = new HashSet<int>(player);
        var rankedList = new List<int>(ranks);
        for(int i = 0; i < rankedList.Count; i++)
            playerRanking.Add(rankedList.Count - i);
        return playerRanking;    
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int rankedCount = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> ranked = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(rankedTemp => Convert.ToInt32(rankedTemp)).ToList();

        int playerCount = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> player = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(playerTemp => Convert.ToInt32(playerTemp)).ToList();

        List<int> result = Result.climbingLeaderboard(ranked, player);

        textWriter.WriteLine(String.Join("\n", result));

        textWriter.Flush();
        textWriter.Close();
    }
}
