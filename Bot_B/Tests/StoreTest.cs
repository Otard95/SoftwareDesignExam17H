using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Serialization;
using NUnit.Framework;

namespace Bot_B.Test
{
  [TestFixture]
  public class StoreTests
  {
    private Store store;
    private Iitem testItem;
    
    [SetUp]
    public void init()
    {
      store = new Store("test");
      testItem = new Item("Audi", 100, "Dette er en bil");
    }
    
    [Test]// test deliver and buy method
    public void TestIfBuyDeliverTheItemIfExistInStore()
    {
      store.DeliverItem(testItem);
      var testItem2 = store.Buy(testItem);
      
      Assert.True(testItem2.Equals(testItem));
      Assert.True(store.Items.Count == 0);
    }

    [Test]
    public void TestIfStartStoreAddItems()
    {
      Thread a = new Thread(store.StartStore);
      a.Start();
      Thread.Sleep(3000);
      store.Shutdown();
      Assert.True(store.Items.Count == 3);

    }
  }
}
