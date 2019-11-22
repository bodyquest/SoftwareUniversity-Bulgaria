using CarDealer.Models;
using CarDealer.Dtos.Import;

using AutoMapper;

namespace CarDealer
{
    public class CarDealerProfile : Profile
    {
        public CarDealerProfile()
        {
            this.CreateMap<ImportSupplierDto, Supplier>();
        }
    }
}
