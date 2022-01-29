namespace Algorithms.LeetCode.Strings
{
    public class ValidAnagram
    {
        public bool IsAnagram(string s, string t)
        {
            if (s.Length != t.Length)
            {
                return false;
            }

            var lettersHash = new int[26];

            foreach (var letter in t)
            {
                var letterIndex = letter - 'a';
                lettersHash[letterIndex]++;
            }

            foreach (var letter in s)
            {
                var letterIndex = letter - 'a';
                lettersHash[letterIndex]--;

                if (lettersHash[letterIndex] < 0)
                {
                    return false;
                }
            }

            foreach (var leftLetterCount in lettersHash)
            {
                if (leftLetterCount != 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
}