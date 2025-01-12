using _2FA.DTOs;
using _2FA.Models;
using AutoMapper;

namespace _2FA.Mappings
{
    public class EntitiesToDTOMappingProfile : Profile
    {
        public EntitiesToDTOMappingProfile()
        {
            CreateMap<Costumer, LoginDTO>().ReverseMap();
            CreateMap<Costumer, RegisterDTO>().ReverseMap();
        }
    }
}
