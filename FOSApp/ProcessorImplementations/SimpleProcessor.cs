﻿using FOSApp.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FOSApp.ProcessorImplementations
{
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
