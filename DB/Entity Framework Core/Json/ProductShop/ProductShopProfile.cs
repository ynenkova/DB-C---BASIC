﻿using AutoMapper;
using ProductShop.DTO;
using ProductShop.Models;

namespace ProductShop
{
    public class ProductShopProfile : Profile
    {
        public ProductShopProfile()
        {
            this.CreateMap<ImportUsersDTO, User>();
            this.CreateMap<ImportProductsDTO, Product>();
            this.CreateMap<ImportCategoriesDTO, Category>();
            this.CreateMap<ImportCategoriesProductsDTO, CategoryProduct>();
        }
    }
}
