using NUnit.Framework;
using System;
namespace Tests
{
    
    

    public class CarTests
    {
        private const double FuelfuelConsumption = 1.25;
        private const double FuelCap = 200;
        private const string Make = "Lada";
        private const string Model = "Samara";

        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void TestConstructor()
        {
            Car cars = new Car(Make, Model, FuelfuelConsumption, FuelCap);

            Assert.AreEqual(Make, cars.Make);
            Assert.AreEqual(Model, cars.Model);
            Assert.AreEqual(FuelfuelConsumption, cars.FuelConsumption);
            Assert.AreEqual(FuelCap, cars.FuelCapacity);
        }
        [Test]
        [TestCase(null, "asd", 2, 5)]
        [TestCase("asd", null, 5, 2)]
        [TestCase("asd", "dsa", 0, 10)]
        [TestCase("asd", "dsa", -1, 10)]
        [TestCase("asd", "dsa", 10, 0)]
        [TestCase("asd", "dsa", 10, -1)]
        public void AllPropertiesShouldThrowArgumentExeption
            (string make, string model, double fuelCon, double fuelCap)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                new Car(make, model, fuelCon, fuelCap);
            });
        }
        [Test]
        public void Refuel()
        {
            Car car = new Car(Make, Model, FuelfuelConsumption, FuelCap);
            car.Refuel(10);
            var addfuel = 10;
            var expected = car.FuelAmount;

            Assert.AreEqual(expected, addfuel);

        }
        [Test]
        public void RefuelCapacity()
        {
            Car car = new Car(Make, Model, FuelfuelConsumption, FuelCap);

            var addfuel = 1000;
            car.Refuel(addfuel);
            var expected = car.FuelAmount;

            var cap = car.FuelCapacity;

            Assert.AreEqual(expected, cap);
        }
        [Test]
        [TestCase(0)]
        [TestCase(-10)]
        public void RefuelShouldThrowArgumentExep(double fueltorefuel)
        {
            Car car = new Car(Make, Model, FuelfuelConsumption, FuelCap);
            Assert.Throws<ArgumentException>(() =>
            {
                car.Refuel(fueltorefuel);
            });

        }
        [Test]
        public void Drive()
        {
            Car car = new Car(Make, Model, FuelfuelConsumption, FuelCap);
            var distans = 20;
            var amount = 20;
            car.Refuel(amount);
            car.Drive(distans);
            var expected = 19.75;
            Assert.AreEqual(car.FuelAmount, expected);
        }
        [Test]
        public void DriveArgumentExep()
        {
            Car car = new Car(Make, Model, FuelfuelConsumption, FuelCap);
            car.Refuel(2);
            var driveDistance = 200;
            
            Assert.Throws<InvalidOperationException>(() =>
            {
                car.Drive(driveDistance);
            });
        }
    }
}