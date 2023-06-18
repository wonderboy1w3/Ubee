using Microsoft.AspNetCore.Mvc;
using Ubee.Domain.Configurations;
using Ubee.Service.DTOs;
using Ubee.Service.DTOs.Wallet;
using Ubee.Service.Interfaces;
using Ubee.Web.Helpers;

namespace Ubee.Web.Controllers
{
    public class WalletsController : BaseController
    {
        private readonly IWalletService service;
        public WalletsController(IWalletService service) 
        {
            this.service = service;
        }
        [HttpPost("create")]
        public async Task<IActionResult> AddAsync(WalletForCreationDto dto)
        {
            return Ok(new Response
            {
                Code = 200,
                Message = "Success",
                Data = await this.service.AddAsync(dto)
            });
        }
        [HttpPut("Update")]
        public async Task<IActionResult> UpdateAsync(long id,WalletForUpdateDto dto)
        {
            return Ok(new Response
            {
                Code = 200,
                Message = "Success",
                Data = await this.service.ModifyAsync(dto)
            });
        }
        [HttpDelete("delete/{id:long}")]
        public async Task<IActionResult> DeleteByIdAsync(long id)
        {
            return Ok(new Response
            {
                Code = 200,
                Message = "Success",
                Data = await this.service.RemoveAsync(id)
            });
        }
        [HttpGet("get-by-id{id:long}")]
        public async Task<IActionResult> GetByIdAsync(long id)
        {
            return Ok(new Response
            {
                Code = 200,
                Message = "Success",
                Data = await this.service.RetrieveByIdAsync(id)
            });
        }
        [HttpGet("get-list")]
        public async Task<IActionResult> GetAllAsync([FromQuery]PaginationParams @params)
        {
            return Ok(new Response
            {
                Code = 200,
                Message = "Seccess",
                Data = await this.service.RetrieveAllAsync(@params)
            });
        }
    }
}
