using Microsoft.AspNetCore.Mvc;
using Ubee.Domain.Configurations;
using Ubee.Service.DTOs.Users;
using Ubee.Service.Interfaces;
using Ubee.Web.Helpers;

namespace Ubee.Web.Controllers
{
	public class UserController : BaseController
	{
		private readonly IUserService userService;
		public UserController(IUserService userService)
		{
			this.userService = userService;
		}

		[HttpPost("create")]
		public async Task<IActionResult> CreateUserAsync(UserForCreationDto dto)
			=> Ok(new Response
			{
				Code = 200,
				Message = "Success",
				Data = await this.userService.AddUserAsync(dto)
			});

		[HttpDelete("delete/{id:long}")]
		public async Task<IActionResult> DelateUserAsync(int id)
			=> Ok(new Response
			{
				Code = 200,
				Message = "Success",
				Data = await this.userService.RemoveUserAsync(id)
			});

		[HttpPut("Update")]
		public async Task<IActionResult> UpdateUserAsync(UserForUpdateDto dto)
			=> Ok(new Response
			{
				Code = 200,
				Message = "Success",
				Data = await this.userService.ModifyUserAsync(dto)
			});

		[HttpGet("get-by-id{id:long}")]
		public async Task<IActionResult> GetByIdAsync(long id)
			=> Ok(new Response
			{
				Code = 200,
				Message = "Success",
				Data = await this.userService.RetrieveUserByIdAsync(id)
			});

		[HttpGet("get-list")]
		public async Task<IActionResult> GetAllUsers([FromQuery] PaginationParams @params, string search)
			=> Ok(new Response
			{
				Code = 200,
				Message = "Success",
				Data = await this.userService.RetrieveAllUserAsync(@params)
			});



	
	}
}
