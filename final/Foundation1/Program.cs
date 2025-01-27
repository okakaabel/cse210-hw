using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create a list to store videos
        List<Video> videos = new List<Video>();

        // Create and populate the first video
        Video video1 = new Video("C# Programming Tutorial", "CodeMaster", 600);
        video1.AddComment("John Doe", "Great explanation of OOP concepts!");
        video1.AddComment("Alice Smith", "This helped me understand abstraction better.");
        video1.AddComment("Bob Wilson", "Could you make a video about inheritance next?");
        videos.Add(video1);

        // Create and populate the second video
        Video video2 = new Video("Cooking Italian Pasta", "ChefSupreme", 480);
        video2.AddComment("Maria Garcia", "The sauce recipe was perfect!");
        video2.AddComment("Sam Brown", "Love the tips for al dente pasta.");
        video2.AddComment("Emma Davis", "Made this for dinner - delicious!");
        videos.Add(video2);

        // Create and populate the third video
        Video video3 = new Video("Guitar Basics", "MusicMaster", 720);
        video3.AddComment("Chris Lee", "Finally learned how to tune properly!");
        video3.AddComment("David Kim", "The finger placement guide was helpful.");
        video3.AddComment("Sarah Johnson", "Can you do an advanced chords tutorial?");
        video3.AddComment("Mike Thompson", "Been playing for years and still learned something new.");
        videos.Add(video3);

        // Display information for each video
        foreach (Video video in videos)
        {
            Console.WriteLine($"\nTitle: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length: {video.LengthInSeconds} seconds");
            Console.WriteLine($"Number of comments: {video.GetNumberOfComments()}");

            Console.WriteLine("\nComments:");
            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($"- {comment.CommenterName}: {comment.Text}");
            }
            Console.WriteLine("----------------------------------------");
        }
    }
}
