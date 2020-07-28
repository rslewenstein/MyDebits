using AutoMapper;
using MyDebits.Domain;
using MyDebits.Dto;

namespace MyDebits.Dto
{
    public class MyDebitsProfile : Profile
    {
        public MyDebitsProfile()
        {
            CreateMap<Debit, DebitDto>();
            CreateMap<DebitDto, Debit>();
            CreateMap<Debit, DebitRegister>().ReverseMap();
        }
    }
}