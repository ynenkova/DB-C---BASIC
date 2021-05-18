
using FightingArena;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Tests
{
    public class ArenaTests
    {
        private Warrior pesho;
        private Warrior gosho;
        [SetUp]
        public void Setup()
        {
            pesho = new Warrior("Pesho", 20, 100);
            gosho = new Warrior("Gosho", 30, 100);
        }

        [Test]
        public void Constructor()
        {
            var arena = new Arena();
            var listWarriors = new List<Warrior>();
            Assert.AreEqual(listWarriors, arena.Warriors);
            
        }
        [Test]
        public void EnrollCprrectly()
        {
            var arena = new Arena();
            arena.Enroll(pesho);
            arena.Enroll(gosho);
            var listWarriors = new List<Warrior> { pesho, gosho };

            Assert.AreEqual(listWarriors, arena.Warriors);
        }
        [Test]
        public void EnrollInvalid()
        {
            var arena = new Arena();
            arena.Enroll(pesho);
            Assert.Throws<InvalidOperationException>(() =>
            {
                arena.Enroll(pesho);
            });
            
        }
        [Test]
        public void EnrollCount()
        {
            var arena = new Arena();
            arena.Enroll(pesho);
            arena.Enroll(gosho);
            var expected = 2;

            Assert.AreEqual(arena.Count, expected);
        }
        [Test]
        public void AttacedIsMissing()
        {
            var arena = new Arena();
            arena.Enroll(gosho);

            Assert.Throws<InvalidOperationException>(() =>
            {
                arena.Fight("Pesho", "Gosho");
            });

        }
        [Test]
        public void DeffenderIsMissing()
        {
            var arena = new Arena();
            arena.Enroll(pesho);

            Assert.Throws<InvalidOperationException>(() =>
            {
                arena.Fight("Pesho", "Gosho");
            });

        }
        [Test]
        public void Fight()
        {
            var arena = new Arena();
            arena.Enroll(gosho);
            arena.Enroll(pesho);
            arena.Fight("Gosho","Pesho");
            var expected = 80;
            var actual = gosho.HP;
            Assert.AreEqual(actual, expected);

        }
    }
}
