namespace Algorithms.Interviews.Microsoft
{
    public class MicrosoftTest 
    {
        public string solution(string S) 
        {

            // 4 possible state => 
            // 0) not occur
            // 1) lowcase occur
            // 2) uppercase occur
            // 3) bothcases occur

            // So, bit manipulation or bool[] are not suitable here
            var occurred = new byte[26];

            foreach(var letter in S)
            {
                if( letter >= 'a' && letter <= 'z')
                {
                    var letterIndex = letter - 'a';
                    var letterStatus = occurred[letterIndex];

                    if(letterStatus == 2)
                    {
                        occurred[letterIndex] = 3;
                    }
                    else if(letterStatus != 3)
                    {
                        occurred[letterIndex] = 1;
                    }
                }
                if( letter >= 'A' && letter <= 'Z')
                {
                    var letterIndex = letter - 'A';
                    var letterStatus = occurred[letterIndex];

                    if(letterStatus == 1)
                    {
                        occurred[letterIndex] = 3;
                    }
                    else if(letterStatus != 3)
                    {
                        occurred[letterIndex] = 2;
                    }
                }
            }

            for(int letterIndex = 25; letterIndex >= 0; letterIndex--)
            {
                if(occurred[letterIndex] == 3)
                {
                    return char.ToString((char)(letterIndex + 'A'));
                }
            }

            return "NO";
        }
        
        public int[] solution(int N) 
        {
            var isCountEven = N % 2 == 0;
            var uniquePairs = N / 2;

            var array = new int[N];

            for(var pairCount = 0; pairCount < uniquePairs; pairCount++)
            {
                array[pairCount * 2] = pairCount + 1;
                array[(pairCount * 2) + 1] = -1 * (pairCount + 1);
            }

            if(!isCountEven)
            {
                array[N - 1] = 0;
            }
       
            return array;
        }
    }
    
}