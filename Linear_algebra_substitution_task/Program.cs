using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linear_algebra_substitution_task
{
    class Program
    {
        static void Main(string[] args)
        {
            string line = "2:1 i:5 4:p 1:3 7:4 j:p 5:8 k:7";
            // string line = "1:p 2:q 3:r";

            var paramSubstitution = new ParamSubstitution(line);

            System.Console.WriteLine(paramSubstitution.GetNumberOfVariants(SubstitutionAssign.Positive));

            Console.ReadLine();
        }
    }
}
