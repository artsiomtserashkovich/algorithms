using System;

namespace Algorithms.Intuit.DynamicProgramming
{
    public class TurtleMatrix
    {
        public int GetCountOfRoutes(int targetRow, int targetColumn)
        {
            if (targetRow < 0)
            {
                throw new ArgumentException(nameof(targetRow));
            }
            else if (targetColumn < 0)
            {
                throw new ArgumentException(nameof(targetColumn));
            }
            else
            {
                var matrix = new int[targetRow + 1, targetColumn + 1];

                for (var row = 0; row <= targetRow; row++)
                {
                    for (var column = 0; column <= targetColumn; column++)
                    {
                        var upCountOfRoutes = row != 0 ? matrix[row - 1, column] : 0;
                        var leftCountOfRoutes = column != 0 ? matrix[row, column - 1] : 0;

                        // initialize start point 
                        if (row == 0 && column == 0)
                        {
                            upCountOfRoutes = 1;
                        }

                        // recurrent formula
                        // can be max if we want to found max profitable
                        matrix[row, column] = upCountOfRoutes + leftCountOfRoutes;
                    }
                }


                return matrix[targetRow,targetColumn];
            }
        } 
    }
}