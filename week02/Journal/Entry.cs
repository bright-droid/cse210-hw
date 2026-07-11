public class Entry
{
    public string _date;
    public string _time;
    //showing time as creativity requirement
    public string _promptText;
    public string _entryText;

    public Entry(string prompt, string response)
    {
        _promptText = prompt;
        _entryText = response;
        DateTime now = DateTime.Now;
        _date = now.ToShortDateString();

        //showing time as creativity requirement
        _time = now.ToLongTimeString();
    }


    public void Display()
    {
        Console.WriteLine($"On: {_date}, at {_time} - {_promptText}");
        Console.WriteLine($"> {_entryText}");
    }

   
}