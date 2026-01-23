/*
 * CSE 212 Lesson 6C 
 * 
 * This code will analyze the NBA basketball data and create a table showing
 * the players with the top 10 career points.
 * 
 * Note about columns:
 * - Player ID is in column 0
 * - Points is in column 8
 * 
 * Each row represents the player's stats for a single season with a single team.
 */

using Microsoft.VisualBasic.FileIO;
using System.Collections.Generic;
using System.Linq;

public class Basketball
{
    public static void Run()
    {
        var players = new Dictionary<string, int>();

        using var reader = new TextFieldParser("basketball.csv");
        reader.TextFieldType = FieldType.Delimited;
        reader.SetDelimiters(",");
        reader.ReadFields(); // ignore header row
        while (!reader.EndOfData)
        {
            var fields = reader.ReadFields()!;
            var playerId = fields[0];
            var points = int.Parse(fields[8]);

            /*
            Solution:
            - check if players dictionary key contains player key, if so,
            add the points and increment it to the players key
            - otherwise just add the points
            - create a variable that will take top players (use linq as this is a faster approach)
            - order by descending order then only take the top 10 players
            - loop through and finally show them in the console in  the "{}" fashion
            */

            if (players.ContainsKey(playerId))
            {
                players[playerId] += points;
            }
            else
            {
                players[playerId] = points;
            }

        }

        var topPlayers = players.OrderByDescending(kvp => kvp.Value).Take(10);
        foreach (var kvp in topPlayers)
        {
            Console.WriteLine("{ " + kvp.Key + " : " + kvp.Value + " }"); 
        }

    }
}