using System;
using System.Collections.Generic;

namespace Linear_algebra_substitution_task
{
    class Program
    {
        static void Main(string[] args)
        {
            // string line = "2:1 i:5 4:p 1:3 7:4 j:p 5:8 k:7"; // Task #1
            // string line = "2:l 6:6 u:m 8:7 5:8 v:n 3:5 1:3"; // Task #2
            // string line = "1:3 4:5 p:8 3:s q:t 7:4 8:7 r:1"; // Task #3
            // string line = "3:6 5:2 6:1 2:x m:3 4:y 7:4 n:z"; // Task #4
            // string line = "2:7 i:4 3:5 5:u 4:8 j:2 7:v k:3"; // Task #5
            string line = "2:l 4:8 s:4 7:1 5:6 3:m 8:3 t:n"; // Task #6
            SubstitutionAssign assign = SubstitutionAssign.Negative;

            var paramSubstitution = new ParamSubstitution(line);

            Console.WriteLine("All suitable substitutions:");
            int varNum = paramSubstitution.GetNumberOfVariants(assign);
            Console.WriteLine();

            Console.WriteLine("Number of suitable substitutions:");
            System.Console.WriteLine(varNum);

            Console.ReadLine();
        }
    }
}
