using NUnit.Framework;
using System;

namespace Tests
{
    public class DatabaseTests
    {
        private Database database;
        private readonly int[] initDate = new int[] { 1, 2 };
        private const int Capacity = 17;
        [SetUp]
        public void Setup()
        {
            this.database = new Database(1, 2);
        }

        [Test]
        public void TestConstructor()
        {
            var integer = new int[] { 1, 2, 3 };
            var date = new Database(integer);

            int expect = integer.Length;

            Assert.That(date.Count,Is.EqualTo(expect));
        }
        [Test]
        public void ConstructorShouldThrow()
        {
            var date = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17 };
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.database = new Database(date);
            });
        }
        [Test]
        public void TestAdd()
        {
            var count = 3;
            this.database.Add(3);
            int actualCount = this.database.Count;
            
            Assert.AreEqual(count, actualCount);
        }
        [Test]
        public void TestThrowInvalidAdd()
        {
            for (int i = 3; i <= 16; i++)
            {
                this.database.Add(i);
            }
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.database.Add(17);
            });
                
        }
        [Test]
        public void TestRemove()
        {
            var count = 1;

            database.Remove();

            Assert.That(database.Count, Is.EqualTo(count));

        }
        [Test]
        public void TestThrowInvalidRemove()
        {
            for (int i = 0; i < 2; i++)
            {
                this.database.Remove();
            }
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.database.Remove();
            });

        }
        [Test]
        public void ShouldReturnElementsAsArray()
        {
            int[] masive = database.Fetch();
            CollectionAssert.AreEqual(initDate, masive);

        }
    }
}