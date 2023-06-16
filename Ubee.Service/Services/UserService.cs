using AutoMapper;
using Ubee.Domain.Entities;
using Ubee.Data.IRepositories;
using Ubee.Service.DTOs.Users;
using Ubee.Service.Exceptions;
using Ubee.Service.Extensions;
using Ubee.Service.Interfaces;
using Ubee.Domain.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Ubee.Service.Services;

public class UserService : IUserService
{

	private readonly IMapper mapper;
	private readonly IRepository<User> userReposotpry;

	public UserService(IMapper mapper, IRepository<User> userRepository)
	{
		this.mapper = mapper;
		this.userReposotpry = userRepository;
	}
	public async ValueTask<UserForResultDto> AddUserAsync(UserForCreationDto dto)
	{
		var user = await this.userReposotpry.SelectAsync(u => u.Username.ToLower() == dto.Username.ToLower());
		if (user is not null)
			throw new CustomException(409, "User is already exists");

		var mappedUser = this.mapper.Map<User>(dto);
		mappedUser.CreatedAt = DateTime.UtcNow;
		var result = await this.userReposotpry.InsertAsync(mappedUser);
		await this.userReposotpry.SaveAsync();

		return this.mapper.Map<UserForResultDto>(result);
	}

	public async ValueTask<bool> RemoveUserAsync(long id)
	{
		var result = await this.userReposotpry.DeleteAysnyc(u => u.Id == id);
		if (!result)
			throw new CustomException(404, "User is not found");
		await this.userReposotpry.SaveAsync();

		return result;
	}


	public async ValueTask<IEnumerable<UserForResultDto>> RetrieveAllUserAsync(PaginationParams @params, string search = null)
	{
		var users = await this.userReposotpry.SelectAll()
			.ToPagedList(@params).ToListAsync();
		if (!string.IsNullOrWhiteSpace(search))
		{
			users = users.FindAll(u => u.Username.ToLower().Contains(search));
		}
		return this.mapper.Map<IEnumerable<UserForResultDto>>(users);
	}

	public async ValueTask<UserForResultDto> RetrieveUserByIdAsync(long id)
	{
		var user = await this.userReposotpry.SelectAsync(u => u.Id == id);
		if (user is null)
			throw new CustomException(404, "User is not found ");
		var result = this.mapper.Map<UserForResultDto>(user);

		return result;
	}


	public async ValueTask<UserForResultDto> ModifyUserAsync(UserForUpdateDto dto)
	{
		var user = await this.userReposotpry.SelectAsync(u => u.Id == dto.Id);
		if (user is null)
			throw new CustomException(404, "User is not found ");

		var result = this.mapper.Map(dto, user);
		result.UpdatedAt = DateTime.UtcNow;
		await this.userReposotpry.SaveAsync();

		return this.mapper.Map<UserForResultDto>(result);
	}
}
