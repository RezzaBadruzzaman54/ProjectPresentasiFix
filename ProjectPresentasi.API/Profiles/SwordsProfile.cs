using AutoMapper;
using ProjectPresentasi.API.Dtos;
using ProjectPresentasi.Domain;

namespace ProjectPresentasi.API.Profiles
{
    public class SwordsProfile : Profile
    {
        public SwordsProfile()
        {
            CreateMap<Sword, SwordReadDto>();
            CreateMap<SwordCreateDto, Sword>();

            CreateMap<Sword, SwordWithElementReadDto>();
            CreateMap<SwordWithElementReadDto, Sword>();

        }
    }
}
