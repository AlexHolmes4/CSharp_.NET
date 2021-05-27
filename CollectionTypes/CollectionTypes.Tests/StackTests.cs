using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace CollectionTypes.Tests
{
    [TestClass]
    public class StackTests
    {
        [TestMethod]
        public void Can_Peek_At_Next_Item()
        {
            var stack = new Stack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);

            Assert.AreEqual(3, stack.Peek());

        }

        [TestMethod]
        public void Can_Search_With_Contains()
        {
            var stack = new Stack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);

            Assert.IsTrue(stack.Contains(2));
        }

        [TestMethod]
        public void Can_Convert_Stack_to_Array()
        {
            var stack = new Stack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            
            var asArray = stack.ToArray();
            stack.Pop();

            Assert.AreEqual(3, asArray[0]);
            Assert.AreEqual(2, stack.Count);
        }
    }
}
