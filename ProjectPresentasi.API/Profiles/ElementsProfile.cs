using AutoMapper;
using ProjectPresentasi.API.Dtos;
using ProjectPresentasi.Domain;

namespace ProjectPresentasi.API.Profiles
{
    public class ElementsProfile : Profile
    {
        public ElementsProfile()
        {
            CreateMap<Element, ElementReadDto>();
            CreateMap<ElementCreateDto, Element>();
        }
    }
}
