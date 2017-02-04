using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConvertToSqlLibrary;

namespace ConvertToSqlTest
{
    [TestClass]
    public class ConvertToSqlWhereTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            var target = new ConvertToSql();
            var input = "age:equals(20)";
            var expected = "where age = 20";

            var actual = target.ToWhere(input);

            Assert.AreEqual(expected, actual);
        }
    }
}
