using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using FOSApp.Abstractions;
using System.Collections.Generic;
using FOSApp.ProcessorImplementations;

namespace FOSTest
{
    [TestClass]
    public class OptimizedProcessorTests
    {
        [TestMethod]
        public void TestOptimzedProcessorWithResults()
        {
            var processor = OptimizedProcessor.Instance;

            var inputList = new List<string>() { "beaver", "tai", "lor", "tailor", "bea", "ver" };

            Assert.IsTrue(processor.FilterData(inputList).Count == 2);
        }

        [TestMethod]
        public void TestOptimzedProcessorWithNoResults()
        {
            var processor = OptimizedProcessor.Instance;

            var inputList = new List<string>() { "beavr", "tai", "lor", "taor", "bea", "ver" };

            Assert.IsTrue(processor.FilterData(inputList).Count == 0);
        }

        [TestMethod]
        public void TestOptimizedProcessorWithMultipleStartOptions()
        {
            var processor = OptimizedProcessor.Instance;

            var inputList = new List<string>() { "beaver", "tai", "lor", "tailor", "be", "bea", "ver" };

            //result will include beaver, known bug in simple processor fixed here.
            Assert.IsTrue(processor.FilterData(inputList).Count == 2);
        }

    }
}
