using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutoMapper;
using Newtonsoft.Json;
using ProductShop.Data;
using ProductShop.DTO;
using ProductShop.Models;
using Microsoft.EntityFrameworkCore;

namespace ProductShop
{
    public class StartUp
    {
        static IMapper mapper;
        private const string Path = @"../../../Datasets/";
        private const string PathResult = @"../../../Datasets/Result/";
        public static void Main(string[] args)
        {
            ProductShopContext context = new ProductShopContext();
          //  EnsureCreateDatabase(context);
            // string inputJson = File.ReadAllText(Path + "categories-products.json");
            //  var result = ImportCategoryProducts(context,inputJson);
            var result = GetUsersWithProducts(context);
            Console.WriteLine(result);
        }
        private static void InitializeAutoMapper()
        {
            var config = new MapperConfiguration(c =>
              {
                  c.AddProfile<ProductShopProfile>();
              });
            mapper = config.CreateMapper();
        }
        private static void EnsureCreateDatabase(ProductShopContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
        }
        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            InitializeAutoMapper();
            var json = JsonConvert.DeserializeObject<ImportUsersDTO[]>(inputJson);
            var users = mapper.Map<User[]>(json);
            context.Users.AddRange(users);
            context.SaveChanges();
            return $"Successfully imported {users.Length}";
        }
        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            InitializeAutoMapper();
            var json = JsonConvert.DeserializeObject<ImportProductsDTO[]>(inputJson);
            var products = mapper.Map<Product[]>(json);
            context.Products.AddRange(products);
            context.SaveChanges();
            return $"Successfully imported {products.Length}";
        }
        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            InitializeAutoMapper();
            var json = JsonConvert.DeserializeObject<ImportCategoriesDTO[]>(inputJson);
            var category = mapper.Map<Category[]>(json.Where(x=>x.Name!=null));
            context.Categories.AddRange(category);
            context.SaveChanges();
            return $"Successfully imported {category.Length}";
        }
         public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            InitializeAutoMapper();
            var json = JsonConvert.DeserializeObject<ImportCategoriesProductsDTO[]>(inputJson);
            var catPro = mapper.Map<CategoryProduct[]>(json);
            context.CategoryProducts.AddRange(catPro);
            context.SaveChanges();
            return $"Successfully imported {catPro.Length}";
        }
        public static string GetProductsInRange(ProductShopContext context)
        {
            var product = context.Products
                .Where(p => p.Price > 500 && p.Price < 1000)
             .Select(p => new
             {
                 name = p.Name,
                 price = p.Price,
                 seller = p.Seller.FirstName + " " + p.Seller.LastName
             }).OrderBy(p => p.price).ToList();
            var json = JsonConvert.SerializeObject(product, Formatting.Indented);
            return json;
        }
        public static string GetSoldProducts(ProductShopContext context)
        {
            var users = context.Users.Where(u => u.ProductsSold.Any(x => x.BuyerId != null)).Select(u => new
            {
                firstName = u.FirstName,
                lastName = u.LastName,
                soldProducts = u.ProductsSold.Where(x => x.BuyerId != null).Select(p => new
                {
                    name = p.Name,
                    price = p.Price,
                    buyerFirstName = p.Buyer.FirstName,
                    buyerLastName = p.Buyer.LastName
                })
            }).OrderBy(u => u.lastName).ThenBy(u => u.firstName).ToList();
            var json = JsonConvert.SerializeObject(users, Formatting.Indented);
            return json;
        }
        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categories = context.Categories.Select(c => new
            {
                category = c.Name,
                productsCount = c.CategoryProducts.Count(),
                averagePrice = c.CategoryProducts.Average(x => x.Product.Price).ToString("F2"),
                totalRevenue = c.CategoryProducts.Sum(x => x.Product.Price).ToString("F2")
            }).OrderByDescending(p => p.productsCount).ToList();

            var jsonResult = JsonConvert.SerializeObject(categories, Formatting.Indented);
            return jsonResult;
        }
        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var allUsers = context
                 .Users
                 .Include(x=>x.ProductsSold)
                 .ToList()
                 .Where(x => x.ProductsSold.Any(p => p.Buyer != null))
                 .Select(b => new
                 {
                     firstName=b.FirstName,
                     lastName = b.LastName,
                     age = b.Age,
                     soldProducts = new
                     {
                         count = b.ProductsSold.Count(l => l.Buyer != null),
                         products = b.ProductsSold
                         .Where(s => s.Buyer != null)
                         .Select(n => new
                         {
                             name = n.Name,
                             price = n.Price
                         })
                     }
                 })
                 .OrderByDescending(x=>x.soldProducts.products.Count())
                 .ToList();

            var finalUsers = new
            {
                usersCount = context.Users.Where(x => x.ProductsSold.Any(b => b.BuyerId != null)).Count(),
                users = allUsers
            };

            var jsonSettings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                NullValueHandling = NullValueHandling.Ignore
            };

            var jsonResult = JsonConvert.SerializeObject(finalUsers, jsonSettings);

            return jsonResult;
        }
    }
}