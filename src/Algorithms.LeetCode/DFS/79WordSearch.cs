using System.Linq;

namespace Algorithms.LeetCode.DFS
{
    public class WordSearch 
    {
        public bool Exist(char[][] board, string word) 
        {
            var wordChars = word.ToArray();
            for(int row = 0; row < board.Length; row++)
            {
                for(int col = 0; col < board[0].Length; col++)
                {
                    if(ExistCheck(row, col, board, wordChars, 0))
                    {
                        return true;
                    }
                }
            }
        
            return false;
        }
    
        private static bool ExistCheck(int row, int col, char[][] board, char[] word, int wordIndex)
        {
            if(!IsValid(row, col, board) || board[row][col] != word[wordIndex])
            {
                return false;
            }
        
        
            if(wordIndex == word.Length - 1)
            {
                return true;
            }
        
            board[row][col] ^= (char)256;
        
            if(ExistCheck(row - 1, col, board, word, wordIndex + 1))
            {
                return true;
            }
            if(ExistCheck(row, col - 1, board, word, wordIndex + 1))
            {
                return true;
            }
            if(ExistCheck(row + 1, col, board, word, wordIndex + 1))
            {
                return true;
            }
            if(ExistCheck(row, col + 1, board, word, wordIndex + 1))
            {
                return true;
            }
        
            board[row][col] ^= (char)256;
        
            return false;
        }
    
        private static bool IsValid(int row, int col, char[][] board)
        {
            if(row < 0)
                return false;
            if(col < 0)
                return false;
            if(row >= board.Length)
                return false;
            if(col >= board[0].Length)
                return false;
        
            return true;
        }
    }
}