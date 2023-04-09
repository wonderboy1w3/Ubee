using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Ubee.Data.IRepositories;
using Ubee.Domain.Entities;
using Ubee.Service.DTOs;
using Ubee.Service.Helpers;
using Ubee.Service.Interfaces;

namespace Ubee.Service.Services
{
    public class InfoService : IInfoService
    {
        private readonly IInfoRepository infoRepository;
        private readonly IMapper mapper;

        public InfoService(IInfoRepository infoRepository, IMapper mapper)
        {
            this.infoRepository = infoRepository;
            this.mapper = mapper;
        }

        public async ValueTask<Response<bool>> DeleteInfoAsync(long id)
        {
            var info = await this.infoRepository.SelectInfoAsync(i => i.Id == id);
            if (info is null)
                return new Response<bool>
                {
                    Code = 404,
                    Message = "Couldn't find for given ID",
                    Value = false
                };

            await this.infoRepository.DeleteInfoAysnyc(id);
            return new Response<bool>
            {
                Code = 200,
                Message = "Success",
                Value = true
            };
        }

        public async ValueTask<Response<InfoDto>> AddInfoAsync(InfoCreationDto infoCreationDto)
        {
            var info = await this.infoRepository.SelectInfoAsync(i => i.WalletId == infoCreationDto.WalletId);

            if (info is null)
            {
                return new Response<InfoDto>
                {
                    Code = 404,
                    Message = "Not found",
                    Value = null,
                };
            }

            var mappedInfo = this.mapper.Map<Info>(infoRepository);
            var addedInfo = await this.infoRepository.InsertInfoAsync(mappedInfo);
            var resultIInfoDto = this.mapper.Map<InfoDto> (addedInfo);

            return new Response<InfoDto>
            {
                Code = 200,
                Message = "Success",
                Value = resultIInfoDto,
            };
        }

        public async ValueTask<Response<List<InfoDto>>> GetAllInfoAsync()
        {
            var infos = await infoRepository.SelectAllInfos().ToListAsync();
            var mappedInfos = mapper.Map<List<InfoDto>>(infos);

            return new Response<List<InfoDto>>
            {
                Code = 200,
                Message = "Success",
                Value = mappedInfos
            };
        }

        public async ValueTask<Response<InfoDto>> GetInfoAsync(long id)
        {
            Info info = await this.infoRepository.SelectInfoAsync(i => i.Id == id);
            if (info is null)
                return new Response<InfoDto>
                {
                    Code = 404,
                    Message = "Couldn't find for given ID",
                    Value = null
                };

            var mappedInfo = this.mapper.Map<InfoDto>(info);
            return new Response<InfoDto>
            {
                Code = 200,
                Message = "Success",
                Value = mappedInfo
            };
        }

        public async ValueTask<Response<InfoDto>> ModifyInfoAsync(long id, InfoCreationDto infoCreationDto)
        {
            Info info = await this.infoRepository.SelectInfoAsync(i => i.Id.Equals(id));
            if (info is null)
                return new Response<InfoDto>
                {
                    Code = 404,
                    Message = "Couldn't find for given ID",
                    Value = null
                };

            var updatedInfo = await this.infoRepository.UpdateInfoAsync(info);
            var mappedInfo = this.mapper.Map<InfoDto>(updatedInfo);
            return new Response<InfoDto>
            {
                Code = 200,
                Message = "Success",
                Value = mappedInfo
            };
        }
    }
}
