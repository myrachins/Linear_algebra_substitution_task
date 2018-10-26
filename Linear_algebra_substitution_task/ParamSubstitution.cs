using System;
using System.Collections.Generic;
using System.Text;

namespace Linear_algebra_substitution_task
{
    class ParamSubstitution
    {
        private static string tokenPattern = @"[a-z]:[\d]+";
        private static string pattern = $@"[{tokenPattern}\s+]+[{tokenPattern}]?";

        public ParamPermutation HigherPermutation { get; private set; }
        public ParamPermutation LowerPermutation { get; private set; }

        public ParamSubstitution(string line)
        {
            HigherPermutation = new ParamPermutation();
            LowerPermutation = new ParamPermutation();

            // TODO: Check pattern of input line
            string[] tokens = line.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries); // Getting tokens like a1:10

            foreach (var token in tokens)
            {
                var indOfSep = token.IndexOf(':'); // finding index of ':' in token
                var higherElement = token.Substring(0, indOfSep); // getting element for higher permutation
                var lowerElement = token.Substring(indOfSep + 1); // getting element for lower permutation

                HigherPermutation.AddElement(higherElement);
                LowerPermutation.AddElement(lowerElement);
            }
        }

        /// <summary>
        /// ATTENTION: This method by now works properly only in situations when same variable
        /// can not exist in both higher and lower permutation
        /// ATTENTION: This method by now works properly only with substitution order less 10
        /// </summary>
        /// <param name="assign"></param>
        /// <returns></returns>
        public int GetNumberOfVariants(SubstitutionAssign assign)
        {
            var higherPerms = HigherPermutation.GetAllCertainPermutations();
            var lowerPerms = LowerPermutation.GetAllCertainPermutations();
            var varNumber = 0;

            foreach (var higherPerm in higherPerms)
            {
                foreach (var lowerPerm in lowerPerms)
                {
                    int invNumber = InversionNumber(higherPerm, lowerPerm);
                    switch (assign)
                    {
                        case SubstitutionAssign.Positive:
                            if (invNumber % 2 == 0) varNumber++;
                            break;
                        case SubstitutionAssign.Negative:
                            if (invNumber % 2 != 0) varNumber++;
                            break;
                    }
                }
            }

            return varNumber;
        }

        private void PrintCertainSubstitution(string higherPerm, string lowerPerm)
        {
            var sortedPermutation = new StringBuilder(higherPerm);

            foreach (var number in higherPerm)
            {
                int intVal = number - '0'; // getting int value from char
                sortedPermutation[intVal - 1] = number;
            }

            Console.WriteLine(sortedPermutation);
        }

        /// <summary>
        /// This methods calculates inversion number of inversions
        /// </summary>
        /// <returns></returns>
        private int InversionNumber(string perm1, string perm2)
        {
            var sortedPermutation = new StringBuilder(perm1);

            for (int i = 0; i < perm1.Length; i++)
            {
                int intVal = perm1[i] - '0'; // getting int value from char
                sortedPermutation[intVal - 1] = perm2[i];
            }

            var inverNumber = 0;

            for (int i = 0; i < sortedPermutation.Length; i++)
                for(int j = i + 1; j < sortedPermutation.Length; j++)
                    if (sortedPermutation[i] > sortedPermutation[j])
                        inverNumber++; // incrementing inverNumber after each invertion in permutation 

            return inverNumber;
        }
    }

    enum SubstitutionAssign
    {
        Positive, Negative
    }
}
