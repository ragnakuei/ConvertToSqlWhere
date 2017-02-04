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

        [TestMethod]
        public void ToWhere_and_equal_number_string()
        {
            var target = new ConvertToSql();
            var input = "and(age:equals(20),name:equals(\"Tom\"))";
            var expected = "where (age = 20 and name = 'Tom')";

            var actual = target.ToWhere(input);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToWhere_and_equal_string_number()
        {
            var target = new ConvertToSql();
            var input = "and(name:equals(\"Tom\"),age:equals(20))";
            var expected = "where (name = 'Tom' and age = 20)";

            var actual = target.ToWhere(input);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToWhere_or_equal_number_string()
        {
            var target = new ConvertToSql();
            var input = "or(age:equals(20),name:equals(\"Tom\"))";
            var expected = "where (age = 20 or name = 'Tom')";

            var actual = target.ToWhere(input);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToWhere_or_equal_string_number()
        {
            var target = new ConvertToSql();
            var input = "or(name:equals(\"Tom\"),age:equals(20))";
            var expected = "where (name = 'Tom' or age = 20)";

            var actual = target.ToWhere(input);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToWhere_and_not_equal_number_string()
        {
            var target = new ConvertToSql();
            var input = "and(not(age:equals(20)),not(name:equals(\"Tom\")))";
            var expected = "where (age <> 20 and name <> 'Tom')";

            var actual = target.ToWhere(input);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToWhere_and_not_equal_string_number()
        {
            var target = new ConvertToSql();
            var input = "and(not(name:equals(\"Tom\")),not(age:equals(20)))";
            var expected = "where (name <> 'Tom' and age <> 20)";

            var actual = target.ToWhere(input);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToWhere_or_not_equal_number_string()
        {
            var target = new ConvertToSql();
            var input = "or(not(age:equals(20)),not(name:equals(\"Tom\")))";
            var expected = "where (age <> 20 or name <> 'Tom')";

            var actual = target.ToWhere(input);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToWhere_or_not_equal_string_number()
        {
            var target = new ConvertToSql();
            var input = "or(not(name:equals(\"Tom\")),not(age:equals(20)))";
            var expected = "where (name <> 'Tom' or age <> 20)";

            var actual = target.ToWhere(input);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToWhere_and_and_equal()
        {
            var target = new ConvertToSql();
            var input = "and(and(age:equals(20),name:equals(\"Tom\")),id:equals(32))";
            var expected = "where ((age = 20 and name = 'Tom') and id = 32)";

            var actual = target.ToWhere(input);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToWhere_and_equal_and()
        {
            var target = new ConvertToSql();
            var input = "and(id:equals(32),and(age:equals(20),name:equals(\"Tom\")))";
            var expected = "where (id = 32 and (age = 20 and name = 'Tom'))";

            var actual = target.ToWhere(input);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToWhere_or_and_equal()
        {
            var target = new ConvertToSql();
            var input = "or(and(age:equals(20),name:equals(\"Tom\")),id:equals(32))";
            var expected = "where ((age = 20 and name = 'Tom') or id = 32)";

            var actual = target.ToWhere(input);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToWhere_or_equal_and()
        {
            var target = new ConvertToSql();
            var input = "or(id:equals(32),and(age:equals(20),name:equals(\"Tom\")))";
            var expected = "where (id = 32 or (age = 20 and name = 'Tom'))";

            var actual = target.ToWhere(input);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToWhere_and_or_equal()
        {
            var target = new ConvertToSql();
            var input = "and(or(age:equals(20),name:equals(\"Tom\")),id:equals(32))";
            var expected = "where ((age = 20 or name = 'Tom') and id = 32)";

            var actual = target.ToWhere(input);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToWhere_and_equal_or()
        {
            var target = new ConvertToSql();
            var input = "and(id:equals(32),or(age:equals(20),name:equals(\"Tom\")))";
            var expected = "where (id = 32 and (age = 20 or name = 'Tom'))";

            var actual = target.ToWhere(input);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToWhere_or_or_equal()
        {
            var target = new ConvertToSql();
            var input = "or(or(age:equals(20),name:equals(\"Tom\")),id:equals(32))";
            var expected = "where ((age = 20 or name = 'Tom') or id = 32)";

            var actual = target.ToWhere(input);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToWhere_or_equal_or()
        {
            var target = new ConvertToSql();
            var input = "or(id:equals(32),or(age:equals(20),name:equals(\"Tom\")))";
            var expected = "where (id = 32 or (age = 20 or name = 'Tom'))";

            var actual = target.ToWhere(input);

            Assert.AreEqual(expected, actual);
        }

    }
}
