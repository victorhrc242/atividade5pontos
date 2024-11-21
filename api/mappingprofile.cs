using AutoMapper;
using Core.DTO;

namespace apictrgamer
{
    public class mappingprofile : Profile
    {
        public mappingprofile()
        {
            CreateMap<CreateCarroDTO, Carro>().ReverseMap();

          

        }
    }
}
