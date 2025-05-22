using System.Security.Cryptography.X509Certificates;

public class PromptGenerator
{
    public List<string> _prompts = ["Who was the most interesting person I interacted with today? ", "What was the best part of my day? ", "How did I see the hand of the Lord in my life today? ", "What was the strongest emotion I felt today? ", "If I had one thing I could do over today, what would it be? ", "What was the most healthy thing I did today? ", "Did I achieve even the smallest of my goals today? "];

    public string GetRandomPrompt()
    {
        Random random = new Random();
        int index = random.Next(0, _prompts.Count);
        return _prompts[index];
    }
}