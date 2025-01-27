// Represents a job in a resume with title, company, and years worked.
public class Job
{
    private string _jobTitle;
    private string _company;
    private int _startYear;
    private int _endYear;

    // Constructor to initialize job details.
    public Job(string jobTitle, string company, int startYear, int endYear)
    {
        _jobTitle = jobTitle;
        _company = company;
        _startYear = startYear;
        _endYear = endYear;
    }

    // Display method to show job details.
    public void DisplayJobDetails()
    {
        Console.WriteLine($"{_jobTitle} ({_company}) {_startYear}-{_endYear}");
    }
}
