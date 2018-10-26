using System;
using System.Collections.Generic;

namespace Linear_algebra_substitution_task
{
    class Program
    {
        static void Main(string[] args)
        {
            // string line = "2:1 i:5 4:p 1:3 7:4 j:p 5:8 k:7";
            string line = "1:2 2:p r:3 3:s";
            SubstitutionAssign assign = SubstitutionAssign.Positive;
            // string line = "1:p 2:q 3:r";

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
