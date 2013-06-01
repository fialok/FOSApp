using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FOSApp.Abstractions;

namespace FOSApp.ProcessorImplementations
{
    class OptimizedProcessor : IProcessor
    {
        private static IProcessor singletonObj;
        private static object locker = new object();
        private const int FIXED_WORD_LENGTH = 6;

        private OptimizedProcessor() { }

        public static IProcessor Instance
        {
            get
            {   lock(locker)
                {
                    if (singletonObj == null)
	                {
                        singletonObj = new OptimizedProcessor();
	                }
                    return singletonObj;
                } 
            } 
        }

        public List<string> FilterData(List<string> inputList)
        {
            List<string> finalValues = new List<string>();
            inputList = inputList.OrderBy(p => p.Length).ToList();
            foreach (string item in inputList)
            {
                if (item.Length == FIXED_WORD_LENGTH)
                {
                    string startString = inputList.Where(p => item.StartsWith(p, StringComparison.OrdinalIgnoreCase) && item != p).FirstOrDefault();
                    string endString = inputList.Where(p => item.EndsWith(p, StringComparison.OrdinalIgnoreCase) && item != p).FirstOrDefault();

                    if (startString.Length + endString.Length == item.Length)
                        finalValues.Add(item);

                }
            }

            return finalValues;
        }
    }
}
