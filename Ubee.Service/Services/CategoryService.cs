using AutoMapper;
using Ubee.Domain.Entities;
using Ubee.Data.IRepositories;
using Ubee.Service.Exceptions;
using Ubee.Service.Extensions;
using Ubee.Service.Interfaces;
using Ubee.Domain.Configurations;
using Ubee.Service.DTOs.Categories;
using Microsoft.EntityFrameworkCore;

namespace Ubee.Service.Services;

public class CategoryService : ICategoryService
{
	private readonly IMapper mapper;
	private readonly IRepository<Category> categoryRepository;

	public CategoryService(IMapper mapper, IRepository<Category> categoryRepository)
	{
		this.mapper = mapper;
		this.categoryRepository = categoryRepository;
	}

	public async ValueTask<CategoryForResultDto> CreateAsync(CategoryForCreationDto dto)
	{
		var category = await this.categoryRepository.SelectAsync(c => c.Name.ToLower().Equals(dto.Name.ToLower()));
		if (category is not null)
			throw new CustomException(409, "Category is already created");

		var mappedCategory = this.mapper.Map<Category>(dto);
		mappedCategory.CreatedAt = DateTime.UtcNow;
		var result = await this.categoryRepository.InsertAsync(mappedCategory);
		await this.categoryRepository.SaveAsync();

		return this.mapper.Map<CategoryForResultDto>(result);
	}

	public async ValueTask<CategoryForResultDto> ModifyAsync(CategoryForUpdateDto dto)
	{
		var category = await this.categoryRepository.SelectAsync(c => c.Id == dto.Id);
		if (category is null)
			throw new CustomException(404, "Category is not found");

		var mappedCategory = this.mapper.Map(dto, category);
		mappedCategory.UpdatedAt = DateTime.UtcNow;
		await this.categoryRepository.SaveAsync();

		return this.mapper.Map<CategoryForResultDto>(mappedCategory);
	}

	public async ValueTask<bool> RemoveAsync(long id)
	{
		var category = await this.categoryRepository.DeleteAysnyc(c => c.Id == id);
		if (!category)
			throw new CustomException(404, "Category is not found");

		await this.categoryRepository.SaveAsync();

		return category;
	}

	public async ValueTask<IEnumerable<CategoryForResultDto>> RetrieveAllAsync(PaginationParams @params)
	{
		var categories = await this.categoryRepository.SelectAll(c => !c.IsDeleted)
			.ToPagedList(@params)
			.ToListAsync();

		return this.mapper.Map<IEnumerable<CategoryForResultDto>>(categories);
	}

	public async ValueTask<CategoryForResultDto> RetrieveByIdAsync(long id)
	{
		var category = await this.categoryRepository.SelectAsync(c => c.Id == id);
		if (category is null)
			throw new CustomException(404, "Category is not found");

		return this.mapper.Map<CategoryForResultDto>(category);
	}
}
