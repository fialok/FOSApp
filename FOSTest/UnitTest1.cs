using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using FOSApp.Abstractions;
using System.Collections.Generic;
using FOSApp.ProcessorImplementations;

namespace FOSTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ProcessInput()
        {
            var processor = new Mock<IProcessor>();

            var inputList = new List<string>() { "beaver","tai","lor","tailor","bea","ver" };

            processor.Setup<List<string>>(p => p.FilterData(It.IsAny<List<string>>())).Returns((List<string> p)=>p);

            Assert.IsTrue(processor.Object.FilterData(inputList).Count == inputList.Count );
        }

        [TestMethod]
        public void TestSimpleProcessorWithResults()
        {
            var processor = SimpleProcessor.Instance;

            var inputList = new List<string>() { "beaver", "tai", "lor", "tailor", "bea", "ver" };
                      
            Assert.IsTrue(processor.FilterData(inputList).Count == 2);
        }

        [TestMethod]
        public void TestSimpleProcessorWithNoResults()
        {
            var processor = SimpleProcessor.Instance;

            var inputList = new List<string>() { "beavr", "tai", "lor", "taor", "bea", "ver" };

            Assert.IsTrue(processor.FilterData(inputList).Count == 0);
        }

    }
}
