using AutoMapper;
using Ubee.Domain.Entities;
using Ubee.Service.DTOs.Infos;
using Ubee.Service.DTOs.Transactions;
using Ubee.Service.DTOs.Users;
using Ubee.Service.DTOs.Wallets;

namespace Ubee.Service.Mappers;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<UserForCreationDto, User>().ReverseMap();
        CreateMap<UserForResultDto, User>().ReverseMap();
        CreateMap<WalletForResultDto, Wallet>().ReverseMap();
        CreateMap<WalletForCreationDto, Wallet>().ReverseMap();
        CreateMap<InfoForCreationDto, Info>().ReverseMap();
        CreateMap<InfoForResultDto , Info>().ReverseMap();
        CreateMap<TransactionDto, Transaction>().ReverseMap();
        CreateMap<TransactionForCreationDto, Transaction>().ReverseMap();
    }
}
