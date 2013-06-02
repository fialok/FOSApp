using FOSApp.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FOSApp.ProcessorImplementations
{
    /// <summary>
    /// Simple processor implemented as a Singleton.
    /// Brute force analysis of all the input to get the results.
    /// </summary>
    public class SimpleProcessor: IProcessor
    {
        private static IProcessor singletonObj;
        private static object locker = new object();
        private const int FIXED_WORD_LENGTH = 6;

        private SimpleProcessor() { }

        public static IProcessor Instance
        {
            get
            {   lock(locker)
                {
                    if (singletonObj == null)
	                {
		                 singletonObj=new SimpleProcessor();
	                }
                    return singletonObj;
                } 
            } 
        }
        
        /// <summary>
        /// This function processes the input list
        /// and validates the logic that it works.
        /// However, there is a bug in this implementation, it does not loop over all possible 
        /// start ad end options and just picks the first macthing, which works for the provided input list
        /// but will fail where we have multiple mathing strings for example a, al, alb for albums.
        /// This issue is fixed in the better implementation of the same logic in OptimizedProcessor class.
        /// </summary>
        /// <param name="inputList"></param>
        /// <returns></returns>
        public List<string> FilterData(List<string> inputList)
        {
            List<string> finalValues = new List<string>();

            foreach (string item in inputList)
            {
                if (item.Length == FIXED_WORD_LENGTH)
                {
                    string startString = inputList.FirstOrDefault(p => item.StartsWith(p, StringComparison.OrdinalIgnoreCase) && item != p);
                    string endString = inputList.FirstOrDefault(p => item.EndsWith(p, StringComparison.OrdinalIgnoreCase) && item != p);
                    
                    if (startString == null || endString == null)
                    {
                        continue;
                    }

                    if (startString.Length + endString.Length == item.Length)
                            finalValues.Add(item);                    
                }
            }            
            return finalValues;            
        }
    }
       
}
