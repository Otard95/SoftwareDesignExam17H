using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using NUnit.Framework;

namespace Bot_B.Test
{
    [TestFixture]
    public class ItemFactoryTest
    {
        
        [SetUp]
        public void Init()
        {
        }

        [Test]
        public void CreatejhTest()
        { 
            Iitem item =ItemFactory.CreateRandom(99.99);
           
            Assert.True(item != null && item.GetPrice() == 99.99);
        }

        [Test]
        public void CreateTest()
        { 
            Iitem item =ItemFactory.Create(99.99);
           
            Assert.True(item != null && item.GetPrice() == 99.99);
        }
    }
}