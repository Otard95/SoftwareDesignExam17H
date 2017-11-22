using System;
using System.Collections.Generic;
using System.IO;
using NUnit.Framework;

namespace Bot_B.Test
{
    [TestFixture]
    public class Bot_BTest
    {
        private Bot_B _botB;

        [SetUp]
        public void init()
        {
            _botB = new Bot_B();
        }

        [Test]
        public void TestReadfile()
        {
            
            List<String> testList = _botB.readFile(@"test.txt");
            Console.WriteLine(testList);
            
            Assert.True(testList.Count == 4);
            Assert.True(testList.Contains("test1"));
            Assert.True(testList.Contains("test2"));
            Assert.True(testList.Contains("test3"));
            Assert.True(testList.Contains("test4"));
        }
    }
}