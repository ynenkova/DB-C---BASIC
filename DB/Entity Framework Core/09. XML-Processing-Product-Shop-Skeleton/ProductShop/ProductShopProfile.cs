using AutoMapper;
using ProductShop.Dtos.Export;
using ProductShop.Dtos.Import;
using ProductShop.Models;
using System.Linq;

namespace ProductShop
{
    public class ProductShopProfile : Profile
    {
        public ProductShopProfile()
        {
            this.CreateMap<ImportUserDTO, User>();
            this.CreateMap<ImportProductDTO, Product>();
            this.CreateMap<ImportCategoryDTO, Category>();
            this.CreateMap<ImportCategoryProductDTO, CategoryProduct>();

            this.CreateMap<Product, ExportProductsInRangeDTO>()
                .ForMember(x => x.BuyerName, y => y.MapFrom(s => s.Buyer.FirstName + " " + s.Buyer.LastName))
                .ForMember(x => x.Price, y => y.MapFrom(z => z.Price))
                .ForMember(x => x.Name, y => y.MapFrom(z => z.Name));

            this.CreateMap<Product, ExportProduct>();

         

            this.CreateMap<Category, ExportCategoryByProducts>()
                .ForMember(c => c.Name, y => y.MapFrom(n => n.Name))
                .ForMember(c => c.Count, y => y.MapFrom(n => n.CategoryProducts.Count))
                 .ForMember(c => c.Average, y => y.MapFrom(n => n.CategoryProducts.Average(p => p.Product.Price)))
                  .ForMember(c => c.TotalRevenue, y => y.MapFrom(n => n.CategoryProducts.Sum(p => p.Product.Price)));

       
               
        }
    }
}
