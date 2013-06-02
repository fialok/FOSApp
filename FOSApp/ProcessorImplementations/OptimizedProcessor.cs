using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FOSApp.Abstractions;

namespace FOSApp.ProcessorImplementations
{
    /// <summary>
    /// Optimized processor implemented as a Singleton.
    /// Improved solution over the Simple implementation.
    /// </summary>
    public class OptimizedProcessor : IProcessor
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

        /// <summary>
        /// This function optimizes by first creating a lookup from the 
        /// input set and then only searches the corresponding lists with the matching character key,
        /// which in turn cuts down the search significantly
        /// Further Improvements: This can be further improved by parallelizing these search operations
        /// using TPL/PLINQ..... (If need be..)
        /// </summary>
        /// <param name="inputList"></param>
        /// <returns></returns>
        public List<string> FilterData(List<string> inputList)
        {
            List<string> finalValues = new List<string>();

            //Create a Key, IEnumerable<T> lookup from the input list. Key being the first character of the word.         
            var inputDictionary = inputList.Where(p=>p.Length < FIXED_WORD_LENGTH).ToLookup(p => p[0]);

            foreach (string item in inputList.Where(p=>p.Length==FIXED_WORD_LENGTH).ToList())
            {
                var lookUpKey = item[0];
                var startStringOptions = inputDictionary[lookUpKey]
                                     .Where(p => item.StartsWith(p, StringComparison.OrdinalIgnoreCase)).ToList();

                bool itemFound = false;

                foreach (var startString in startStringOptions)
                {
                    var endLookUpKey = item[startString.Length];

                    if (inputDictionary.Contains(endLookUpKey))
                    {
                        var endStringOptions = inputDictionary[endLookUpKey]
                                      .Where(p => item.EndsWith(p, StringComparison.OrdinalIgnoreCase)).ToList();

                        foreach (var endString in endStringOptions)
                        {
                            if (startString.Length + endString.Length == item.Length)
                            { 
                                finalValues.Add(item);
                                itemFound = true;
                                break;
                            }
                        }                       
                    }
                    if (itemFound) break;                   
                }                                   
            }
            return finalValues;
        }
       
    }
}
