using System;
using System.Collections.Generic;

namespace Linear_algebra_substitution_task
{
    class ParamPermutation
    {
        private string formatPermutation;
        private int variablesNumber;

        public List<int> CertainNumbers { get; private set; }
        public int Length => CertainNumbers.Count + variablesNumber;

        public ParamPermutation()
        {
            CertainNumbers = new List<int>();
        }

        /// <summary>
        /// Add element to permutation.
        /// If its a parameter it will be inserted like "0" or "1" and etc
        /// </summary>
        /// <param name="element"></param>
        public void AddElement(string element)
        {
            int parsed;
            if (int.TryParse(element, out parsed))
            {
                CertainNumbers.Add(parsed);
                formatPermutation += parsed.ToString();
            }
            else
            {
                formatPermutation += $"\"{variablesNumber++}\"";
            }
        }

        /// <summary>
        /// This method returns all certained values from parametrized permutation
        /// </summary>
        /// <returns></returns>
        public List<string> GetAllCertainPermutations()
        {
            var leftValues = GetAllLeftValues();
            var combinations = new List<List<int>>();

            CalculateAllCombinations(leftValues, ref combinations); // Getting all possible combinations from free numbers

            var permutations = new List<string>();
            foreach (var combination in combinations)
            {
                var counter = 0;
                var currentString = formatPermutation;

                foreach (var insert in combination)
                {
                    currentString = currentString.Replace($"\"{counter++}\"", insert.ToString()); // Replacing parameter from permutation
                }

                permutations.Add(currentString);
            }

            return permutations;
        }

        /// <summary>
        /// This method calculates all possible combinations of inputed numbers
        /// </summary>
        /// <typeparam name="T"> Type of number </typeparam>
        /// <param name="numbers"> Numbers to calculate </param>
        /// <param name="allCombinations"> List with all combinations </param>
        /// <param name="currentCombination"> Current combination (Needed in recursion) </param>
        private void CalculateAllCombinations<T>(List<T> numbers, ref List<List<T>> allCombinations, 
            List<T> currentCombination = null)
        {
            if (currentCombination == null)
                currentCombination = new List<T>();

            if (numbers.Count == 0)
            {
                allCombinations.Add(currentCombination);
                return;
            }
            for (int i = 0; i < numbers.Count; i++)
            {
                var newNumbers = new List<T>(numbers);
                var newCurrentCombination = new List<T>(currentCombination);

                newNumbers.RemoveAt(i); // Removing i element from new list
                newCurrentCombination.Add(numbers[i]); // Now current combination contains deleted element att left
                CalculateAllCombinations(newNumbers, ref allCombinations, newCurrentCombination);
            }
        }

        /// <summary>
        /// This method finds all left values, that can exist in current permutation
        /// </summary>
        /// <returns> List of all possible values </returns>
        private List<int> GetAllLeftValues()
        {
            var leftValues = new List<int>();

            for(int i = 1; i <= Length; i++)
                if (!CertainNumbers.Contains(i))
                    leftValues.Add(i); // getting all values from range [1, Length], that are free from CertainNumbers list

            return leftValues;
        }
    }
}
