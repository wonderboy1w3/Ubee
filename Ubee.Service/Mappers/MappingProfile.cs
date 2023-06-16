using AutoMapper;
using Ubee.Domain.Entities;
using Ubee.Service.DTOs;
using Ubee.Service.DTOs.Users;

namespace Ubee.Service.Mappers;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // Info
        //CreateMap<InfoDto , Info>().ReverseMap();
        //CreateMap<InfoCreationDto, Info>().ReverseMap();

        // User
        CreateMap<UserForResultDto, User>().ReverseMap();
        CreateMap<UserForCreationDto, User>().ReverseMap();

        // Wallet
        //CreateMap<WalletDto, Wallet>().ReverseMap();
        //CreateMap<WalletForCreationDto, Wallet>().ReverseMap();

        // Transaction
        //CreateMap<TransactionDto, Transaction>().ReverseMap();
        //CreateMap<TransactionForCreationDto, Transaction>().ReverseMap();
    }
}
