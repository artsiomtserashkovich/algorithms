public class HIndex 
{
    // Requirements:
    // 1) h papers have at least h citations each
    // 2) other n - h papers have no more than h citations
    
    // Bucket sort approach
    public int HIndexV2(int[] citations) 
    {
        var prefixSum = new int[citations.Length + 1];
        var result = 0;
        
        for(int index = 0; index < citations.Length; index++)
        {
            var hindex = Math.Min(citations[index], citations.Length);
            prefixSum[hindex] ++;
        }
        
        // The hardest part to understand is that "accumulative" count from highest hindex to lowest
        for(int hindex = citations.Length, count = 0; hindex >= 0; hindex--)
        {
            count += prefixSum[hindex];
            if(count >= hindex)
            {
                result = hindex;
                break;
            }
        }
        
        return result;
    }
    
    public int HIndexV1(int[] citations) 
    {
        int hindex = 0;
        for(int succeedCitations = 0; hindex < citations.Length + 1; hindex++)
        {
            succeedCitations = 0;
            for(int index = 0; index < citations.Length; index++)
            {
                if(citations[index] >= hindex)
                {
                    succeedCitations ++;
                }
            }
            
            if(succeedCitations < hindex)
            {
                break;
            }
            
        }
        
        return hindex - 1;
    }
}
