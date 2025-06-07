using System.Runtime.InteropServices;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words;

    public Scripture(Reference Reference, string text)
    {
        _reference = Reference;

        _words = [];

        string[] words = text.Split(" ");

        for (int i = 0; i < words.Length; i++)
        {
            Word word = new Word(words[i]);
            _words.Add(word);
        }
    }

     private string GetReference()
    {
        return _reference.GetDisplayText();
    }

    private string GetWords()
    {
        List<string> texts = [];

        foreach (Word word in _words)
        {
            texts.Add(word.GetDisplayText());
        }

        return string.Join(" ", texts);
    }

    public void HideRandomWords(int numberToHide)
    {
        Random random = new Random();

        List<Word> wordsToHide = new List<Word>();
        foreach (Word word in _words)
        {
            if (!word.IsHidden())
            {
                wordsToHide.Add(word);
            }
        }

        for (int i = 0; i < numberToHide && wordsToHide.Count > 0; i++)
        {
            int index = random.Next(0, wordsToHide.Count);
            wordsToHide[index].Hide();
            wordsToHide.RemoveAt(index);
        }
    }

    public string GetDisplayText()
    {
        return GetReference() + "" + GetWords();
    }

    public bool IsCompletelyHidden()
    {
        foreach (Word word in _words)
        {
            if (!word.IsHidden())
            {
                return false;
            }
        }

        return true;
    }    
}