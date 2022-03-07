public class MinimumDeletionsMakeCharacterFrequenciesUnique 
{
    public int MinDeletions(string s) 
    {
        var lettersFrequency = new int[26];
        
        foreach(var letter in s)
        {
            lettersFrequency[letter - 'a'] ++;
        }
        
        Array.Sort(lettersFrequency);
        
        int keepLetters = lettersFrequency[lettersFrequency.Length - 1], previousLetterCount = keepLetters;
        for(int index = lettersFrequency.Length - 2; index >= 0 && lettersFrequency[index] != 0; index --)
        {
            // We can keep no more than previous letter count - 1
            previousLetterCount = Math.Min(lettersFrequency[index], previousLetterCount - 1);
		    keepLetters += previousLetterCount;
        }
        
        return s.Length - keepLetters;
    }
}
