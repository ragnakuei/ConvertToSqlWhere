using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConvertToSqlLibrary;

namespace ConvertToSqlTest
{
    [TestClass]
    public class ConvertToSqlWhereTest
    {
        [TestMethod]
        public void ToWhere_equals_number()
        {
            var target = new ConvertToSql();
            var input = "age:equals(20)";
            var expected = "where age = 20";

            var actual = target.ToWhere(input);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToWhere_equals_string()
        {
            var target = new ConvertToSql();
            var input = "age:equals(\"20\")";
            var expected = "where age = '20'";

            var actual = target.ToWhere(input);

            Assert.AreEqual(expected, actual);
        }

        //[TestMethod]
        //public void ToWhere_equals_string_not_replace_string()
        //{
        //    var target = new ConvertToSql();
        //    var input = "comment:equals(\"age:equals(20)\")";
        //    var expected = "where comment = 'age:equals(20)'";

        //    var actual = target.ToWhere(input);

        //    Assert.AreEqual(expected, actual);
        //}

        [TestMethod]
        public void ToWhere_not_equals_number()
        {
            var target = new ConvertToSql();
            var input = "not(age:equals(20))";
            var expected = "where age <> 20";

            var actual = target.ToWhere(input);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToWhere_not_equals_string()
        {
            var target = new ConvertToSql();
            var input = "not(age:equals(\"20\"))";
            var expected = "where age <> '20'";

            var actual = target.ToWhere(input);

            Assert.AreEqual(expected, actual);
        }
        
    }
}
