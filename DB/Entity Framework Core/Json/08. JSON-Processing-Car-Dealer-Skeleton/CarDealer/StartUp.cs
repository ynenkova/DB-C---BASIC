using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using AutoMapper;
using CarDealer.Data;
using CarDealer.DTO;
using CarDealer.Models;
using Newtonsoft.Json;

namespace CarDealer
{
    public class StartUp
    {
        static IMapper mapper;
        private const string Path = @"../../../Datasets/";
        public static void Main(string[] args)
        {
            var context = new CarDealerContext();
            // EnsureCreateDatabase(context);

            var result = GetSalesWithAppliedDiscount(context);
            Console.WriteLine(result);


        }
        private static void InitializeAutoMapper()
        {
            var conf = new MapperConfiguration(c =>
              {
                  c.AddProfile<CarDealerProfile>();
              });
            mapper = conf.CreateMapper();
        }
        private static void EnsureCreateDatabase(CarDealerContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
        }
        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            InitializeAutoMapper();
            var json = JsonConvert.DeserializeObject<ImportSuppliersDTO[]>(inputJson);
            var suppliers = mapper.Map<Supplier[]>(json);
            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();
            return $"Successfully imported {suppliers.Length}.";
        }
        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            InitializeAutoMapper();
            var suppliers = context.Suppliers.Select(s => s.Id).ToArray();
            var partsDto = JsonConvert.DeserializeObject<ImportPartsDTO[]>(inputJson).Where(x => suppliers.Contains(x.SupplierId)).ToList();
            var parts = mapper.Map<Part[]>(partsDto);

            context.Parts.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Count()}.";
        }
        public static string ImportCars(CarDealerContext context, string inputJson)
        {

            InitializeAutoMapper();

            var carsDTO = JsonConvert.DeserializeObject<IEnumerable<ImportCarsDTO>>(inputJson);

            var cars = new List<Car>();

            foreach (var car in carsDTO)
            {
                var currentCar = new Car
                {
                    Make = car.Make,
                    Model = car.Model,
                    TravelledDistance = car.TravelledDistance
                };

                foreach (var partId in car.PartsId.Distinct())
                {
                    var currentPart = new PartCar()
                    {
                        Car = currentCar,
                        PartId = partId
                    };

                    currentCar.PartCars.Add(currentPart);

                }

                cars.Add(currentCar);

            }


            context.Cars.AddRange(cars);

            context.SaveChanges();

            return $"Successfully imported { cars.Count()}.";

        }
        public static string ImportCustomers(CarDealerContext context, string inputJson)
        {
            InitializeAutoMapper();
            var json = JsonConvert.DeserializeObject<ImportCustomersDTO[]>(inputJson);
            var customers = mapper.Map<Customer[]>(json);
            context.Customers.AddRange(customers);
            context.SaveChanges();
            return $"Successfully imported {customers.Length}.";
        }
        public static string ImportSales(CarDealerContext context, string inputJson)
        {

            InitializeAutoMapper();
            var json = JsonConvert.DeserializeObject<ImportSalesDTO[]>(inputJson);
            var sales = mapper.Map<Sale[]>(json);
            context.Sales.AddRange(sales);
            context.SaveChanges();
            return $"Successfully imported {sales.Length}.";
        }
        public static string GetOrderedCustomers(CarDealerContext context)
        {
            var customers = context.Customers.OrderBy(d => d.BirthDate).ThenBy(d => d.IsYoungDriver).Select(d => new
            {
                Name = d.Name,
                BirthDate = d.BirthDate.ToString("dd/MM/yyyy"),
                IsYoungDriver = d.IsYoungDriver
            })
               .ToList();

            var result = JsonConvert.SerializeObject(customers, Formatting.Indented);
            return result;
        }
        public static string GetCarsFromMakeToyota(CarDealerContext context)
        {

            var cars = context.Cars
                .Where(c => c.Make == "Toyota")
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TravelledDistance)
                .Select(c => new
                {
                    Id = c.Id,
                    Make = c.Make,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance,
                })
                .ToList();

            string result = JsonConvert.SerializeObject(cars, new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                Culture = CultureInfo.InvariantCulture,

            });

            return result;
        }
        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var suppliers = context.Suppliers.Where(x => x.IsImporter == false).Select(x => new
            {
                Id = x.Id,
                Name = x.Name,
                PartsCount = x.Parts.Count()
            }).ToList();
            var json = JsonConvert.SerializeObject(suppliers, Formatting.Indented);
            return json;
        }
        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var cars = context.Cars
                .Select(c => new
                {
                    car = new
                    {
                        Make = c.Make,
                        Model = c.Model,
                        TravelledDistance = c.TravelledDistance
                    },
                    parts = c.PartCars.Select(pc => new
                    {
                        Name = pc.Part.Name,
                        Price = pc.Part.Price.ToString("f2")
                    })
                    .ToList()
                })
                .ToList();

            string result = JsonConvert.SerializeObject(cars, Formatting.Indented);

            return result;
        }
        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var customers = context.Customers.Where(c => c.Sales.Any(s => s.Car != null))
                .Select(c => new
                {
                    fullName = c.Name,
                    boughtCars = c.Sales.Count(),
                    spentMoney = c.Sales.Sum(p => p.Car.PartCars.Sum(s => s.Part.Price))
                }).OrderByDescending(x => x.spentMoney).ThenByDescending(x => x.boughtCars).ToList();

            var result = JsonConvert.SerializeObject(customers, Formatting.Indented);
            return result;
        }
        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var cars = context
                .Sales
                .Select(x => new
                {
                    car = new 
                    {
                       Make = x.Car.Make, 
                       Model = x.Car.Model, 
                       TravelledDistance = x.Car.TravelledDistance 
                    },

                    customerName = x.Customer.Name,
                    Discount = x.Discount.ToString("F2"),
                    price = x.Car.PartCars.Sum(ss => ss.Part.Price).ToString("F2"),
                    priceWithDiscount = (x.Car.PartCars.Sum(b => b.Part.Price) * (1 - x.Discount / 100)).ToString("F2")
                })
                .Take(10)
                .ToList();

            var jsonOutput = JsonConvert.SerializeObject(cars,Formatting.Indented);
            return jsonOutput;
        }
    }
}