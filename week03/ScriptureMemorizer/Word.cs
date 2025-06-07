public class Word
{
    private string _text;
    private bool _isHidden = false;

    public Word(string text)
    {
        _text = text;
    }

    private string GetText()
    {
        return _text;
    }

    private bool GetIsHidden()
    {
        return _isHidden;
    }

    private void SetIsHidden(bool value)
    {
        _isHidden = value;
    }

    public void Hide()
    {
        SetIsHidden(true);
    }

    public void Show()
    {
        SetIsHidden(false);
    }

    public bool IsHidden()
    {
        return GetIsHidden();
    }

    public string GetDisplayText()
    {
        string displayText = GetText();

        if (IsHidden())
        {
            char[] chars = displayText.ToCharArray();
            for (int i = 0; i < chars.Length; i++)
            {
                chars[i] = '_';
            }

            displayText = new string(chars);
        }

        return displayText;
    }
}