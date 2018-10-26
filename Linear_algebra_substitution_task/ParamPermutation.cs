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
                    currentString = currentString.Replace($"\"{counter++}\"", insert.ToString());
                }

                permutations.Add(currentString);
            }

            return permutations;
        }

        private void CalculateAllCombinations<T>(IList<T> arr, ref List<List<T>> allCombinations, 
            List<T> current = null)
        {
            if (current == null)
                current = new List<T>();
            if (arr.Count == 0)
            {
                allCombinations.Add(current);
                return;
            }
            for (int i = 0; i < arr.Count; i++)
            {
                List<T> lst = new List<T>(arr);
                lst.RemoveAt(i);
                var newCurrent = new List<T>(current);
                newCurrent.Add(arr[i]);
                CalculateAllCombinations(lst, ref allCombinations, newCurrent);
            }
        }

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
