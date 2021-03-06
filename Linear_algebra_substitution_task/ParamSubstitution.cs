﻿using System;
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
                            if (invNumber % 2 == 0)
                            {
                                varNumber++;
                                PrintCertainSubstitution(higherPerm, lowerPerm);
                            }
                            break;
                        case SubstitutionAssign.Negative:
                            if (invNumber % 2 != 0)
                            {
                                varNumber++;
                                PrintCertainSubstitution(higherPerm, lowerPerm);
                            }
                            break;
                    }
                }
            }

            return varNumber;
        }

        /// <summary>
        /// This method sorts lower permutation by higher values
        /// </summary>
        /// <param name="higherPerm"> Higher permutation </param>
        /// <param name="lowerPerm"> Lower permutation </param>
        /// <returns> sorted lower permutation </returns>
        private string SortPermutationByHigher(string higherPerm, string lowerPerm)
        {
            var sortedPermutation = new StringBuilder(higherPerm);

            for (int i = 0; i < higherPerm.Length; i++)
            {
                int intVal = higherPerm[i] - '0'; // getting int value from char
                sortedPermutation[intVal - 1] = lowerPerm[i]; // changing value of sorted by value in lower permutation
            }

            return sortedPermutation.ToString();
        }

        /// <summary>
        /// This method sorts and prints lower permutation by higher values 
        /// </summary>
        /// <param name="higherPerm"> Higher permutation </param>
        /// <param name="lowerPerm"> Lower permutation </param>
        private void PrintCertainSubstitution(string higherPerm, string lowerPerm)
        {
            var sortedPermutation = SortPermutationByHigher(higherPerm, lowerPerm);

            Console.WriteLine(sortedPermutation);
        }

        /// <summary>
        /// This methods calculates inversion number of inversions
        /// </summary>
        /// <returns></returns>
        private int InversionNumber(string higherPerm, string lowerPerm)
        {
            var sortedPermutation = SortPermutationByHigher(higherPerm, lowerPerm);
            var inverNumber = 0;

            for (int i = 0; i < sortedPermutation.Length; i++)
                for(int j = i + 1; j < sortedPermutation.Length; j++)
                    if (sortedPermutation[i] > sortedPermutation[j])
                        inverNumber++; // incrementing inverNumber after each invertion in permutation 

            return inverNumber;
        }
    }

    /// <summary>
    /// Enum of possible assign of substitution
    /// </summary>
    enum SubstitutionAssign
    {
        Positive, Negative
    }
}
