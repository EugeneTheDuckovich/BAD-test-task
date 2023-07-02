using System.Runtime.CompilerServices;

namespace BadTestTask;

public class UniqueCharacterParser
{
    public char GetFirstUniqueChar(string? text)
    {
        if (string.IsNullOrWhiteSpace(text))
        {
            return ' ';
        }

        string[] words = text.Split(' ').Where(w => !string.IsNullOrWhiteSpace(w)).ToArray();
        bool isSingleWord = words.Length == 1;
        var charactersFrequency = new Dictionary<char, int>();

        if (isSingleWord)
        {
            UpdateCharFrequencyInWord(words[0],charactersFrequency);
        }
        else
        {
            UpdateTextCharFrequencyInText(words,charactersFrequency);
        }
        
        KeyValuePair<char,int> pair = charactersFrequency.FirstOrDefault(c => c.Value == 1);
        return pair.Equals(default(KeyValuePair<char,int>)) ? ' ' : pair.Key;
    }

    private void UpdateTextCharFrequencyInText(string[] words, Dictionary<char,int> charactersFrequency)
    {
        foreach (string word in words)
        {
            UpdateCharFrequency(charactersFrequency, GetFirstUniqueChar(word));
        }
    }

    private void UpdateCharFrequencyInWord(string word, Dictionary<char,int> charactersFrequency)
    {
        foreach (char c in word)
        {
            UpdateCharFrequency(charactersFrequency, c);
        }
    }

    private void UpdateCharFrequency(Dictionary<char, int> charactersFrequency, char character)
    {
        if(character == ' ') 
            return;

        if (charactersFrequency.ContainsKey(character))
        {
            charactersFrequency[character]++;
        }
        else
        {
            charactersFrequency.Add(character, 1);
        }
    }
}