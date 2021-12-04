using AutoMapper;
using ProductShop.Data;
using ProductShop.Dtos.Export;
using ProductShop.Dtos.Import;
using ProductShop.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace ProductShop
{
    public class StartUp
    {
        private const string Path= @"../../../Datasets/";
        private const string ResultPath = Path + "ResultPath/";
        public static void Main(string[] args)
        {
            var db = new ProductShopContext();
           
            var result = GetUsersWithProducts(db);
            Console.WriteLine(result);
            File.WriteAllText(ResultPath + "categories-by-product-count.xml", result);

            //var result = GetCategoriesByProductsCount(db);
            //Console.WriteLine(result);
            //File.WriteAllText(ResultPath + "categories-by-product-count.xml", result);

            //var result = GetSoldProducts(db);
            //Console.WriteLine(result);
            //File.WriteAllText(ResultPath + "sold-product.xml", result);

            //var result = GetProductsInRange(db);
            //Console.WriteLine(result);
            //File.WriteAllText(ResultPath + "products-in-range.xml", result);

            //var inputXml = File.ReadAllText(Path + "categories-products.xml");
            //var result = ImportCategoryProducts(db, inputXml);
            //Console.WriteLine(result);

            //var inputXml = File.ReadAllText(Path + "categories.xml");
            //var result = ImportCategories(db, inputXml);
            //Console.WriteLine(result);

            //var inputXml = File.ReadAllText(Path + "products.xml");
            //var result = ImportProducts(db, inputXml);
            //Console.WriteLine(result);

            //var inputXml = File.ReadAllText(Path + "users.xml");
            //var result = ImportUsers(db, inputXml);
            //Console.WriteLine(result);


        }
        private static void InitializeMapper()
        {
            Mapper.Initialize(cfg => { cfg.AddProfile<ProductShopProfile>(); });
        }
        public static string GetUsersWithProducts(ProductShopContext context)
        {

            var users = context.Users
               .AsEnumerable()
               .Where(u => u.ProductsSold.Any())
               .Select(u => new UserDTO
               {
                   FirstName = u.FirstName,
                   LastName = u.LastName,
                   Age = u.Age,
                   SoldProduct = new UserSoldProductDTO
                   {
                       Count = u.ProductsSold.Count,
                       Products = u.ProductsSold.Select(ps => new ProductDTO
                       {
                           Name = ps.Name,
                           Price = ps.Price
                       })
                       .OrderByDescending(p => p.Price)
                       .ToArray()
                   }
               })
               .OrderByDescending(p => p.SoldProduct.Count)
               .Take(10)
               .ToArray();

            var result = new UserProductDTO
            {
                Count = context.Users.Count(u => u.ProductsSold.Any()),
                Users = users
            };

            XmlSerializer serializer = new XmlSerializer(typeof(UserProductDTO), new XmlRootAttribute("Products"));
            var sb = new StringBuilder();
            var namespaces = new XmlSerializerNamespaces(new[]
            {
                new XmlQualifiedName("","")
            });
            serializer.Serialize(new StringWriter(sb), result, namespaces);
            return sb.ToString().TrimEnd();

        }
        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            StringBuilder sb = new StringBuilder();
            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add(String.Empty, String.Empty);

            var categories = context.Categories.Select(c => new ExportCategoryByProducts()
            {
                Name = c.Name,
                Count = c.CategoryProducts.Count,
                Average = c.CategoryProducts.Average(p => p.Product.Price),
                TotalRevenue = c.CategoryProducts.Sum(p => p.Product.Price)
            }).OrderByDescending(c => c.Count).ThenBy(c => c.TotalRevenue).ToArray();

            XmlSerializer serializer = new XmlSerializer(typeof(ExportCategoryByProducts[]), new XmlRootAttribute("Categories"));
            serializer.Serialize(new StringWriter(sb), categories, namespaces);

            return sb.ToString().TrimEnd();
        }
        public static string GetSoldProducts(ProductShopContext context)
        {
            var sb = new StringBuilder();
            var namespaces = new XmlSerializerNamespaces(new[]
            {
                new XmlQualifiedName("","")
            });
            var users = context.Users
                .Where(u => u.ProductsSold.Count>=1)
                .OrderBy(u=>u.LastName)
                .ThenBy(u=>u.FirstName)
                .Take(5)
                .Select(x => new ExportSoldProducts
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    SoldProducts = x.ProductsSold
                        .Select(p => new SoldProductDTO()
                        {
                            Name = p.Name,
                            Price = p.Price
                        }).ToArray()

                }).ToArray();
            XmlSerializer serializer = new XmlSerializer(typeof(ExportSoldProducts[]), new XmlRootAttribute("Users"));
            serializer.Serialize(new StringWriter(sb), users, namespaces);
            return sb.ToString().TrimEnd();
        }
        public static string GetProductsInRange(ProductShopContext context)
        {
     
            var products = context.Products
                .Where(p => p.Price >= 500 && p.Price <= 1000).OrderBy(pr => pr.Price).Take(10)
                .Select(pr => new ExportProductsInRangeDTO
                {
                Name = pr.Name,
                Price = pr.Price,
                 BuyerName = pr.Buyer.FirstName + " " + pr.Buyer.LastName
            }).ToArray();

            XmlSerializer serializer = new XmlSerializer(typeof(ExportProductsInRangeDTO[]), new XmlRootAttribute("Products"));
            var sb = new StringBuilder();
            var namespaces = new XmlSerializerNamespaces(new[]
            {
                new XmlQualifiedName("","")
            });
            serializer.Serialize(new StringWriter(sb), products,namespaces);
            return sb.ToString().TrimEnd();
        }
        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            InitializeMapper();
            XmlSerializer serializer = new XmlSerializer(typeof(ImportUserDTO[]), new XmlRootAttribute("Users"));

            ImportUserDTO[] usersDtos = (ImportUserDTO[])serializer.Deserialize(new StringReader(inputXml));
            List<User> users = new List<User>();
            foreach (var userD in usersDtos)
            {
                var user = Mapper.Map<User>(userD);
                users.Add(user);
            }
           
            context.Users.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Count}";
        }
        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            XmlSerializer xmlSerializer =
                new XmlSerializer(typeof(ImportCategoryDTO[]), new XmlRootAttribute("Categories"));

            var categoriesDtos = (ImportCategoryDTO[])xmlSerializer.Deserialize(new StringReader(inputXml));

          
            List<Category> categories = new List<Category>();

            foreach (var categoryDto in categoriesDtos)
            {
                Category category = new Category()
                {
                    Name = categoryDto.Name
                };
                if (!categories.Any(c => c.Name == category.Name))
                {
                    categories.Add(category);
                }

            }
            context.Categories.AddRange(categories.Distinct());
            context.SaveChanges();

            return $"Successfully imported {categories.Count}";

        }
        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            XmlSerializer xmlSerializer =
                new XmlSerializer(typeof(ImportProductDTO[]), new XmlRootAttribute("Products"));

            var productsDtodDtos = (ImportProductDTO[])xmlSerializer.Deserialize(new StringReader(inputXml));

            List<Product> products = new List<Product>();

            foreach (var productDto in productsDtodDtos)
            {
                Product product = new Product()
                {
                    BuyerId = productDto.BuyerId,
                    Name = productDto.Name,
                    SellerId = productDto.SellerId,
                    Price = productDto.Price
                };
                products.Add(product);
            }

          

            context.Products.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Count}";

        }
        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportCategoryProductDTO[]),
                new XmlRootAttribute("CategoryProducts"));

            var categoryProductsDtos =
                (ImportCategoryProductDTO[])xmlSerializer.Deserialize(new StringReader(inputXml));

           
            List<CategoryProduct> categoryProducts = new List<CategoryProduct>();

            foreach (var categoryProductDto in categoryProductsDtos)
            {
                if (context.Categories.Any(c => c.Id == categoryProductDto.CategoryId) &&
                    context.Products.Any(p => p.Id == categoryProductDto.ProductId))
                {
                    CategoryProduct categoryProduct = new CategoryProduct()
                    {
                        CategoryId = categoryProductDto.CategoryId,
                        ProductId = categoryProductDto.ProductId
                    };
                    categoryProducts.Add(categoryProduct);
                }

            }

            context.CategoryProducts.AddRange(categoryProducts);
            context.SaveChanges();

            return $"Successfully imported {categoryProducts.Count}";

        }
    }
}