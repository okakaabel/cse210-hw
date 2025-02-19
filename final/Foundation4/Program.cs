using System;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {
        // Creating a list of activities with different types of activities
        List<Activity> activities = new List<Activity>
        {
            new Running(new DateTime(2024, 2, 19), 30, 5.0),
            new Cycling(new DateTime(2024, 2, 19), 45, 20.0),
            new Swimming(new DateTime(2024, 2, 19), 40, 20)
        };

        // Displaying the summary of each activity
        foreach (var activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}
