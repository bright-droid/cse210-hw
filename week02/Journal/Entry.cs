public class Entry
{
    public string _date;
    public string _promptText;
    public string _entryText;

    public Entry(string prompt, string response)
    {
        _promptText = prompt;
        _entryText = response;
        DateTime currentDate = DateTime.Now;
        _date = currentDate.ToShortDateString();
    }


    public void Display()
    {
        Console.WriteLine($"On: {_date} - {_promptText}");
        Console.WriteLine($"> {_entryText}");
    }

   
}