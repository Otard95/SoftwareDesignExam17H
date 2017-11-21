using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Bot_B.Test
{
  [TestFixture]
  public class StoreTests
  {
    
    [Test]
    public void TestIfBuyDeliverTheItemIfExistInStore()
    {
      Store store = new Store("test");
      Iitem tesItem = new Item("Audi", 100, "Dette er en bil");
      
      store.DeliverItem(tesItem);
      Iitem testItem2 = store.Buy(tesItem);
      
      Assert.True(testItem2.Equals(tesItem));
    }
  }
}
