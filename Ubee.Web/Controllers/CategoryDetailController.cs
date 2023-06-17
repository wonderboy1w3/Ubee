using Microsoft.AspNetCore.Mvc;
using Ubee.Domain.Configurations;
using Ubee.Service.DTOs.Categories;
using Ubee.Service.Interfaces;
using Ubee.Web.Helpers;

namespace Ubee.Web.Controllers
{
	public class CategoryDetailController : BaseController
	{
		private readonly ICategoryDetailService categoryDetailService;

		public CategoryDetailController(ICategoryDetailService categoryDetailService)
		{
			this.categoryDetailService = categoryDetailService;
		}

		[HttpPost("create")]
		public async Task<IActionResult> CreateCategoryDetailAsync(CategoryDetailForCreationDto dto)
		=> Ok(new Response
		{
			Code = 200,
			Message = "Success",
			Data = await this.categoryDetailService.CreateAsync(dto)
		});

		[HttpDelete("delete/{id:long}")]
		public async Task<IActionResult> DelateCategoryDetailAsync(int id)
			=> Ok(new Response
			{
				Code = 200,
				Message = "Success",
				Data = await this.categoryDetailService.RemoveAsync(id)
			});

		[HttpPut("Update")]
		public async Task<IActionResult> UpdateCategoryDetailAsync(CategoryDetailForUpdateDto dto)
			=> Ok(new Response
			{
				Code = 200,
				Message = "Success",
				Data = await this.categoryDetailService.ModifyAsync(dto)
			});

		[HttpGet("get-by-id{id:long}")]
		public async Task<IActionResult> GetByIdAsync(long id)
			=> Ok(new Response
			{
				Code = 200,
				Message = "Success",
				Data = await this.categoryDetailService.RetrieveByIdAsync(id)
			});

		[HttpGet("get-list")]
		public async Task<IActionResult> GetAllCategories([FromQuery] PaginationParams @params)
			=> Ok(new Response
			{
				Code = 200,
				Message = "Success",
				Data = await this.categoryDetailService.RetrieveAllAsync(@params)
			});
	}
}
