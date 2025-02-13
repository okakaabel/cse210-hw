using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.Json.Nodes;

public class QuestManager
{
    private List<Goal> mGoals;
    private int mScore;
    private int mLevel;

    public QuestManager()
    {
        mGoals = new List<Goal>();
        mScore = 0;
        mLevel = 1;
    }

    public void AddGoal(Goal goal)
    {
        mGoals.Add(goal);
    }

    public void RecordEvent(int index)
    {
        if (index >= 0 && index < mGoals.Count)
        {
            int points = mGoals[index].RecordEvent();
            mScore += points;
            CheckLevelUp();
            Console.WriteLine($"Congratulations! You earned {points} points!");
            Console.WriteLine($"You now have {mScore} points.");
        }
    }

    private void CheckLevelUp()
    {
        int newLevel = (mScore / 1000) + 1;
        if (newLevel > mLevel)
        {
            Console.WriteLine($"\n🎉 LEVEL UP! 🎉");
            Console.WriteLine($"You are now a Level {newLevel} Quest Master!");
            mLevel = newLevel;
        }
    }

    public void DisplayGoals()
    {
        Console.WriteLine("\nCurrent Goals:");
        for (int i = 0; i < mGoals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {mGoals[i].GetStatusString()}");
        }
    }

    public void DisplayScore()
    {
        Console.WriteLine($"\nYou have {mScore} points (Level {mLevel})");
    }

    public void SaveToFile(string filename)
    {
        var savedData = new Dictionary<string, object>
        {
            { "score", mScore },
            { "level", mLevel },
            { "goals", mGoals.Select(static g => new { Type = g.GetType().Name, Name = g.GetName(), Description = g.GetStatusString(), Points = g.mBasePoints }).ToList() }
        };

        string jsonString = JsonSerializer.Serialize(savedData);
        File.WriteAllText(filename, jsonString);
    }

    public void LoadFromFile(string filename)
    {
        if (File.Exists(filename))
        {
            string jsonString = File.ReadAllText(filename);
            var savedData = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonString);
            mScore = Convert.ToInt32(savedData["score"]);
            mLevel = Convert.ToInt32(savedData["level"]);
            // Deserialize goals
            foreach (var goalData in (savedData["goals"] as JsonArray))
            {
                var goalType = goalData[0].ToString();
                Goal goal = goalType switch
                {
                    "SimpleGoal" => new SimpleGoal(goalData[1].ToString(), goalData[2].ToString(), Convert.ToInt32(goalData[3])),
                    "EternalGoal" => new EternalGoal(goalData[1].ToString(), goalData[2].ToString(), Convert.ToInt32(goalData[3])),
                    "ChecklistGoal" => new ChecklistGoal(goalData[1].ToString(), goalData[2].ToString(), Convert.ToInt32(goalData[3]), 0, 0),
                    _ => throw new InvalidOperationException("Unknown goal type")
                };
                mGoals.Add(goal);
            }
        }
    }
}
