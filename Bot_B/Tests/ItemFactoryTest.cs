using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using NUnit.Framework;

namespace Bot_B.Test
{
    [TestFixture]
    public class ItemFactoryTest
    {
        private List<Iitem> items;
        
        [SetUp]
        public void init()
        {
            items = new List<Iitem>();
        }

        [Test]
        public void createjhTest()
        { 
            Iitem item =ItemFactory.CreateRandom(99.99);
           
            Assert.True(item != null && item.GetPrice() == 99.99);
        }

        [Test]
        public void createTest()
        { 
            Iitem item =ItemFactory.Create(99.99);
           
            Assert.True(item != null && item.GetPrice() == 99.99);
        }
    }
}