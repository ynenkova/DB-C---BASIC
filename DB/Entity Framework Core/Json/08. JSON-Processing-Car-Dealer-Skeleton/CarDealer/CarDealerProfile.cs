using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using CarDealer.DTO;
using CarDealer.Models;

namespace CarDealer
{
    public class CarDealerProfile : Profile
    {
        public CarDealerProfile()
        {
            this.CreateMap<ImportSuppliersDTO, Supplier>();
            this.CreateMap<ImportPartsDTO, Part>();
            this.CreateMap<ImportCarsDTO, Car>();
            this.CreateMap<ImportCustomersDTO, Customer>();
            this.CreateMap<ImportSalesDTO, Sale>();

        }
    }
}
