using AutoMapper;
using pasaj.Entities;
using pasaj.Service.DataTransferObjects.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pasaj.Service.MappingProfile
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Product, ProductCardResponse>();
            CreateMap<Product, ProductForAddToCard>();
        }
    }
}
