using AutoMapper;
using ProjectPresentasi.API.Dtos;
using ProjectPresentasi.Domain;

namespace ProjectPresentasi.API.Profiles
{
    public class SamuraisProfile : Profile
    {
        public SamuraisProfile()
        {
            CreateMap<Samurai, SamuraiReadDto>();
            CreateMap<SamuraiCreateDto, Samurai>();

            CreateMap<Samurai, SamuraiWithSwordReadDto>();
            CreateMap<SamuraiWithSwordCreateDto, Samurai>();

            CreateMap<Samurai, SamuraiWithSwordAndElementReadDto>();

            CreateMap<Sword, SamuraiSwordReadDto>();
            CreateMap<SamuraiSwordCreateDto, Sword>();

            CreateMap<Samurai, SamuraiWithSwordAndElementReadDto>();
            CreateMap<SamuraiWithSwordAndElementCreateDto, Samurai>();

        }
    }
}
