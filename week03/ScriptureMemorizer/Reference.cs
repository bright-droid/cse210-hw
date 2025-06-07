public class Reference
{
    private string _book;
    private int _chapter;
    private int _verse;
    private int _endVerse;

    public Reference(string book, int chapter, int verse)
    {
        _book = book;
        _chapter = chapter;
        _verse = verse;
    }

    public Reference(string book, int chapter, int startVerse, int endVerse)
    {
        _book = book;
        _chapter = chapter;
        _verse = startVerse;
        _endVerse = endVerse;
    }

    private string GetBook()
    {
        return _book;
    }

    private int GetChapter()
    {
        return _chapter;
    }

    private int GetStartVerse()
    {
        return _verse;
    }

    private string GetEndVerse()
    {
        string end = _endVerse.ToString();
        end = end == "0" ? "" : $"-{end}";
        return end;
    }


    public string GetDisplayText()
    {
        string book = GetBook();
        string chapter = GetChapter().ToString();
        string startVerse = GetStartVerse().ToString();
        string endVerse = GetEndVerse();
        return $"\n{book} {chapter} : {startVerse}{endVerse}- ";
    }

}