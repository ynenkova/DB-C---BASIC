using System;
using NUnit.Framework;

namespace Tests
{
    
   

    public class WarriorTests
    {
        private const string Name = "Ivan";
        private const int Damage = 50;
        private const int HP = 500;
        

        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        public void TestConstructor()
        {
            var warrior = new Warrior(Name, Damage, HP);

            Assert.AreEqual(Name, warrior.Name);
            Assert.AreEqual(Damage, warrior.Damage);
            Assert.AreEqual(HP, warrior.HP);

        }
        [Test]
        [TestCase(null,40,90)]
        [TestCase("Pesho",0,90)]
        [TestCase("Pesho", -1,90)]
        [TestCase("Pesho", 20, -1)]
        public void AllPropertyThrowArgumentExep(string names, int damages,int hps)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                new Warrior(names, damages, hps);
            });
        }
        [Test]
        public void Attac()
        {
            var attaked = new Warrior(Name, Damage, HP);
            var fighter = new Warrior("Stamat", 60, 400);
            attaked.Attack(fighter);
            
            var expexted = 440;
            Assert.That(() => attaked.HP, Is.EqualTo(expexted));
        }
        [Test]
        public void WarriorCannotAttakedHP()
        {
            var attaked = new Warrior(Name, Damage, HP);
            var fighter = new Warrior("Stamat", 40, 30);

            Assert.Throws<InvalidOperationException>(() =>
            {
                attaked.Attack(fighter);
            });
        }
        [Test]
        [TestCase(30)]
        public void WarriorCannotAttakedDamage(int hps)
        {
            var attaked = new Warrior(Name, Damage, hps);
            var fighter = new Warrior("Stamat", 30, 300);

            Assert.Throws<InvalidOperationException>(() =>
            {
                attaked.Attack(fighter);
            });
        }
        [Test]
        [TestCase(40)]
        public void CantAttacedStrogerOpponent(int dam)
        {
            var attaked = new Warrior(Name, Damage, 39);
            var fighter = new Warrior("Stamat", dam, 300);
            Assert.Throws<InvalidOperationException>(() =>
            {
                attaked.Attack(fighter);
            });
        }
    }
}