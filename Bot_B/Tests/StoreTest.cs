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
    public void Test1()
    {
      Store store = new Store("test");
      Iitem testItem = store.Buy(new Item("Audi", 100, "Dette er en bil"));
      Console.Write(testItem);
      Assert.True(true);
    }
  }
}
