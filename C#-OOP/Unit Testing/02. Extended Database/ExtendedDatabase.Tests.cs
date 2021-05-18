using System;
using NUnit.Framework;

namespace Tests
{
   
   

    public class ExtendedDatabaseTests
    {
        private Person ivan;
        private Person pesho;

        [SetUp]
        public void TestInitialization()
        {
            ivan = new Person(1234, "Ivan");
            pesho = new Person(985124736, "Pesho");

        }

        [Test]
        public void TestConstructor()
        {
            var expected = new Person[] { ivan, pesho };
            var db = new ExtendedDatabase(expected);

            var actual = 2;

            Assert.That(db.Count, Is.EqualTo(actual));
        }
        [Test]
        public void ShouldAddValidPerson()
        {
            var person = new Person[] { ivan, pesho };
            var db = new ExtendedDatabase(person);
            var newperson = new Person(845126, "Stamat");
            db.Add(newperson);
            var expected = 3;
            Assert.That(db.Count, Is.EqualTo(expected));

        }
        [Test]
        public void ShouldThrowInvalidOperationIfThereIsTheSameName()
        {
            var person = new Person[] { ivan, pesho };
            var db = new ExtendedDatabase(person);
            var newperson = new Person(347278, "Ivan");
            Assert.That(() => db.Add(newperson), Throws.InvalidOperationException);
        }

        [Test]
        public void ShouldThrowInvalidOperationIfThereIsTheSameId()
        {
            var person = new Person[] { ivan, pesho };
            var db = new ExtendedDatabase(person);
            var newperson = new Person(1234, "Galq");
            Assert.That(() => db.Add(newperson), Throws.InvalidOperationException);
        }
        [Test]
        public void ShouldRemovePerson()
        {
            var person = new Person[] { ivan, pesho };
            var db = new ExtendedDatabase(person);
            db.Remove();

            var expected = 1;

            Assert.AreEqual(db.Count, expected);
        }
        [Test]
        public void ShouldThrowInvalidOperatioIfIsEmpty()
        {
            var person = new Person[] { };
            var db = new ExtendedDatabase(person);

            Assert.That(() => db.Remove(), Throws.InvalidOperationException);
        }
        [Test]
        public void ShouldFindByUsername()
        {
            var person = new Person[] { ivan, pesho };
            var db = new ExtendedDatabase(person);
            var find = ivan;

            var people = db.FindByUsername("Ivan");

            Assert.AreEqual(people, find);
        }

        [Test]
        public void FindByShouldThrowNoUser()
        {
            var person = new Person[] { ivan, pesho };
            var db = new ExtendedDatabase(person);

            Assert.That(() => db.FindByUsername("Stamat"), Throws.InvalidOperationException);
        }

        [Test]
        public void FindByShouldThrowNullUsername()
        {
            var person = new Person[] { ivan, pesho };
            var db = new ExtendedDatabase(person);


            Assert.That(() => db.FindByUsername(null), Throws.ArgumentNullException);
        }

        [Test]
        public void FindByShouldCaseSensitive()
        {
            var person = new Person[] { ivan, pesho };
            var db = new ExtendedDatabase(person);


            Assert.That(() => db.FindByUsername("IVAN"), Throws.InvalidOperationException);
        }
        [Test]
        public void FindById()
        {
            var person = new Person[] { ivan, pesho };
            var db = new ExtendedDatabase(person);
            var id = ivan;

            var expected = db.FindById(1234);

            Assert.AreEqual(expected, id);
        }
        [Test]
        public void FindByIdShouldThrowIfNoUserWithId()
        {
            var person = new Person[] { ivan, pesho };
            var db = new ExtendedDatabase(person);

            Assert.That(() => db.FindById(542168), Throws.InvalidOperationException);
        }
        [Test]
        public void FindByIdShouldThrowNegativeId()
        {
            var person = new Person[] { ivan, pesho };
            var db = new ExtendedDatabase(person);

            Assert.That(() => db.FindById(-542168), Throws.Exception);
        }
    }
}