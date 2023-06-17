using AutoMapper;
using Ubee.Domain.Entities;
using Ubee.Service.Interfaces;
using Ubee.Service.Exceptions;
using Ubee.Data.IRepositories;
using Ubee.Service.Extensions;
using Ubee.Domain.Configurations;
using Ubee.Service.DTOs.Categories;
using Microsoft.EntityFrameworkCore;

namespace Ubee.Service.Services;

public class CategoryDetailService : ICategoryDetailService
{
	private readonly IMapper mapper;
	private readonly ICategoryService categoryService;
	private readonly IRepository<CategoryDetail> categoryDetailRepository;

	public CategoryDetailService(IMapper mapper,
		ICategoryService categoryService,
		IRepository<CategoryDetail> categoryDetailRepository)
	{
		this.mapper = mapper;
		this.categoryService = categoryService;
		this.categoryDetailRepository = categoryDetailRepository;
	}

	public async ValueTask<CategoryDetailForResultDto> CreateAsync(CategoryDetailForCreationDto dto)
	{
		// Check the category for existing and bring it if exist
		var category = await this.categoryService.RetrieveByIdAsync(dto.CategoryId);
		var categoryDetail = await this.categoryDetailRepository.SelectAsync(cd => cd.Name.ToLower().Equals(dto.Name.ToLower()));
		if (categoryDetail is not null)
			throw new CustomException(409, "CategoryDetail is already exist");

		var mappedCategoryDetail = this.mapper.Map<CategoryDetail>(dto);
		mappedCategoryDetail.CreatedAt = DateTime.UtcNow;
		var result = await this.categoryDetailRepository.InsertAsync(mappedCategoryDetail);
		await this.categoryDetailRepository.SaveAsync();

		return this.mapper.Map<CategoryDetailForResultDto>(result);
	}

	public async ValueTask<CategoryDetailForResultDto> ModifyAsync(CategoryDetailForUpdateDto dto)
	{
		// Check the category for existing and bring it if exist
		var category = await this.categoryService.RetrieveByIdAsync(dto.CategoryId);
		var categoryDetail = await this.categoryDetailRepository.SelectAsync(cd => cd.Id == dto.Id);
		if (categoryDetail is null)
			throw new CustomException(409, "CategoryDetail is not found");
		var mappedCategoryDetail = this.mapper.Map(dto, categoryDetail);
		mappedCategoryDetail.UpdatedAt = DateTime.UtcNow;
		await this.categoryDetailRepository.SaveAsync();

		return this.mapper.Map<CategoryDetailForResultDto>(mappedCategoryDetail);
	}

	public async ValueTask<bool> RemoveAsync(long id)
	{
		var categoryDetail = await this.categoryDetailRepository.DeleteAysnyc(cd => cd.Id == id);
		if (!categoryDetail)
			throw new CustomException(404, "CategoryDetail is not found");
		await this.categoryDetailRepository.SaveAsync();

		return categoryDetail;
	}

	public async ValueTask<IEnumerable<CategoryDetailForResultDto>> RetrieveAllAsync(PaginationParams @params)
	{
		var cd = await this.categoryDetailRepository.SelectAll(cd => !cd.IsDeleted)
			.ToPagedList(@params)
			.ToListAsync();

		return this.mapper.Map<IEnumerable<CategoryDetailForResultDto>>(cd);
	}

	public async ValueTask<CategoryDetailForResultDto> RetrieveByIdAsync(long id)
	{
		var categoryDetail = await this.categoryDetailRepository.SelectAsync(cd => cd.Id == id);
		if (categoryDetail is null)
			throw new CustomException(404, "CategoryDetail is not found");

		return this.mapper.Map<CategoryDetailForResultDto>(categoryDetail);
	}
}
