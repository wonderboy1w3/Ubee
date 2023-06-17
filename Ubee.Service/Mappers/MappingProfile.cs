using AutoMapper;
using Ubee.Domain.Entities;
using Ubee.Service.DTOs.Users;
using Ubee.Service.DTOs.Categories;

namespace Ubee.Service.Mappers;

public class MappingProfile : Profile
{
	public MappingProfile()
	{
		// Info
		//CreateMap<InfoDto , Info>().ReverseMap();
		//CreateMap<InfoCreationDto, Info>().ReverseMap();

		// User
		CreateMap<User, UserForResultDto>().ReverseMap();
		CreateMap<User, UserForUpdateDto>().ReverseMap();
		CreateMap<User, UserForCreationDto>().ReverseMap();

		// Category
		CreateMap<Category, CategoryForResultDto>().ReverseMap();
		CreateMap<Category, CategoryForUpdateDto>().ReverseMap();
		CreateMap<Category, CategoryForCreationDto>().ReverseMap();

		// CategoryDetail
		CreateMap<CategoryDetail, CategoryDetailForResultDto>().ReverseMap();
		CreateMap<CategoryDetail, CategoryDetailForUpdateDto>().ReverseMap();
		CreateMap<CategoryDetail, CategoryDetailForCreationDto>().ReverseMap();

		// Wallet
		//CreateMap<WalletDto, Wallet>().ReverseMap();
		//CreateMap<WalletForCreationDto, Wallet>().ReverseMap();

		// Transaction
		//CreateMap<TransactionDto, Transaction>().ReverseMap();
		//CreateMap<TransactionForCreationDto, Transaction>().ReverseMap();
	}
}
