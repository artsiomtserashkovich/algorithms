namespace Algorithms.Intuit.DynamicProgramming
{
    public class Combinations
    {
        private const byte CAT = 0;
        private const byte DOG = 1; 
        
        // conveyor with animals cell destributed line
        // each cell have restriction: cells with same animals can't placed more than 3 in line 
        // Example: |C|C|C|
        // Correct Order: |C|C|D|
        // Animal coding: Cat - 0; Dog - 1;
        // Reccurent expression = A[index][animalCode] = A[index-1][1-animalCode] + A[index-2][1-animalCode]
        public int GetPetStoreCombination(int cellNumber)
        {
            if (cellNumber == 1)
            {
                return 2;
            } else if (cellNumber == 2)
            {
                return 4;
            }

            var combinations = new int [cellNumber, 2];

            combinations[0, CAT] = 1;
            combinations[0, DOG] = 1;
            combinations[1, CAT] = 2;
            combinations[1, DOG] = 2;

            for (var index = 2; index < cellNumber; index++)
            {
                combinations[index, CAT] = combinations[index - 1, GetOppositeAnimal(CAT)] +
                                           combinations[index - 2, GetOppositeAnimal(CAT)];
                
                combinations[index, DOG] = combinations[index - 1, GetOppositeAnimal(DOG)] +
                                           combinations[index - 2, GetOppositeAnimal(DOG)];
            }

            return combinations[cellNumber - 1, CAT] + combinations[cellNumber - 1, DOG];
        }

        private static int GetOppositeAnimal(byte animalType) => 1 - animalType;
    }
}