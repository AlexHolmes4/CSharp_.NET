using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace CollectionTypes.Tests
{
    [TestClass]
    public class SortedTests
    {
        [TestMethod]
        public void Can_Use_Sorted_list()
        {
            var list = new SortedList<int, string>();

            list.Add(3, "three");
            list.Add(1, "one");
            list.Add(2, "two");

            Assert.AreEqual(0, list.IndexOfKey(1));
            Assert.AreEqual(1, list.IndexOfValue("two"));
        }

        [TestMethod]
        public void Can_Use_Sorted_Set()
        {
            var set = new SortedSet<int>();

            set.Add(3);
            set.Add(1);
            set.Add(2);

            var enumerator = set.GetEnumerator();
            enumerator.MoveNext();
            Assert.AreEqual(enumerator.Current, 1);
        }

        [TestMethod]
        public void Can_Remove_By_Key()
        {
            var map = new Dictionary<int, string>();
            map.Add(1, "one");
            map.Add(2, "two");

            map.Remove(1);

            Assert.AreEqual(1, map.Count);
        }
    }
}
