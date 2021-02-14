﻿using System;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using OpenA3XX.Core.Dtos;
using OpenA3XX.Core.Models;
using OpenA3XX.Core.Repositories;

namespace OpenA3XX.Core.Services
{
    public class HardwarePanelService : IHardwarePanelService
    {
        private readonly IHttpContextAccessor _accessor;
        private readonly IHardwarePanelTokensRepository _hardwarePanelTokensRepository;
        private readonly IHardwarePanelRepository _hardwarePanelRepository;
        private readonly IMapper _mapper;

        public HardwarePanelService(IHttpContextAccessor accessor,
            IHardwarePanelTokensRepository hardwarePanelTokensRepository,
            IHardwarePanelRepository hardwarePanelRepository, IMapper mapper)
        {
            _accessor = accessor;
            _hardwarePanelTokensRepository = hardwarePanelTokensRepository;
            _hardwarePanelRepository = hardwarePanelRepository;
            _mapper = mapper;
        }

        public void UpdateLastSeenForHardwarePane(Guid token)
        {
            _hardwarePanelTokensRepository.UpdateLastSeenForHardwarePanel(token);
        }

        public HardwarePanelTokenDto GetTokenDetailsByHardwarePanelId(int id)
        {
            var hardwarePanelToken = _hardwarePanelTokensRepository.GetByHardwarePanelId(id);
            var hardwarePanelTokenDto = _mapper.Map<HardwarePanelToken, HardwarePanelTokenDto>(hardwarePanelToken);

            return hardwarePanelTokenDto;
        }

        public HardwarePanelTokenDto GetTokenDetailsByHardwarePanelToken(Guid token)
        {
            var hardwarePanelToken = _hardwarePanelTokensRepository.GetByHardwarePanelToken(token);
            var hardwarePanelTokenDto = _mapper.Map<HardwarePanelToken, HardwarePanelTokenDto>(hardwarePanelToken);

            return hardwarePanelTokenDto;
        }

        public IList<HardwarePanelTokenDto> GetAllHardwarePanelTokens()
        {
            var hardwarePanelTokens = _hardwarePanelTokensRepository.GetAllHardwarePanelTokens();
            var hardwarePanelTokenDtoList =
                _mapper.Map<IList<HardwarePanelToken>, IList<HardwarePanelTokenDto>>(hardwarePanelTokens);

            return hardwarePanelTokenDtoList;
        }

        public IList<HardwarePanelDto> GetAllHardwarePanels()
        {
            var hardwarePanelList = _hardwarePanelRepository.GetAllHardwarePanels();
            var hardwarePaneDtoList = _mapper.Map<IList<HardwarePanel>, IList<HardwarePanelDto>>(hardwarePanelList);
            return hardwarePaneDtoList;
        }

        public HardwarePanelTokenDto RegisterHardwarePanel(DeviceRegistrationRequestDto deviceRegistrationRequest)
        {
            var hardwarePanelToken = new HardwarePanelToken
            {
                DeviceToken = Guid.NewGuid().ToString(),
                HardwarePanelId = deviceRegistrationRequest.HardwarePanelId,
                CreatedDateTime = DateTime.Now,
                DeviceIpAddress = _accessor.HttpContext?.Connection.RemoteIpAddress?.ToString()
            };

            hardwarePanelToken = _hardwarePanelTokensRepository.SaveHardwarePanelToken(hardwarePanelToken);
            var hardwarePanelTokenDto = _mapper.Map<HardwarePanelToken, HardwarePanelTokenDto>(hardwarePanelToken);

            return hardwarePanelTokenDto;
        }
    }
}