using AutoMapper;
using Ubee.Domain.Entities;
using Ubee.Service.DTOs;

namespace Ubee.Service.Mappers;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<UserForCreationDto, User>().ReverseMap();
        CreateMap<UserDto, User>().ReverseMap();
        CreateMap<WalletDto, Wallet>().ReverseMap();
        CreateMap<WalletForCreationDto, Wallet>().ReverseMap();
        CreateMap<TransactionDto, Transaction>().ReverseMap();
        CreateMap<TransactionForCreationDto, Transaction>().ReverseMap();

    }
}
