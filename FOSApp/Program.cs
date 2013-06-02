using FOSApp.ProcessorImplementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FOSApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter a comma separated list of input.");
            var input = Console.ReadLine();
            List<string> inputValues = new List<string>();
            inputValues= input.Replace(" ","").Split(',').ToList();

            List<string> finalValues;

            //Brute force implementation
            //finlValues = SimpleProcessor.Instance.FilterData(inputValues);

            //Improved Implementation
            finalValues = OptimizedProcessor.Instance.FilterData(inputValues);
                        
            Console.WriteLine();
            Console.WriteLine("===============================OUTPUT=============================");
            Console.WriteLine();
            foreach (string item in finalValues)
            {
                Console.WriteLine(item);
            }

            Console.ReadKey();

        }
    }
}
