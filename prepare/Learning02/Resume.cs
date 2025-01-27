using System;
using System.Collections.Generic;

// Represents a resume with a list of jobs.
public class Resume
{
    private string _name;  // Name on the resume
    private List<Job> _jobs;  // List of jobs on the resume

    // Constructor to initialize resume with a name
    public Resume(string name)
    {
        _name = name;
        _jobs = new List<Job>();
    }

    // Method to add a job to the resume
    public void AddJob(Job job)
    {
        _jobs.Add(job);
    }

    // Display method to show resume details
    public void DisplayResume()
    {
        Console.WriteLine($"Name: {_name}");
        Console.WriteLine("Jobs:");
        foreach (Job job in _jobs)
        {
            job.DisplayJobDetails();
        }
    }
}
