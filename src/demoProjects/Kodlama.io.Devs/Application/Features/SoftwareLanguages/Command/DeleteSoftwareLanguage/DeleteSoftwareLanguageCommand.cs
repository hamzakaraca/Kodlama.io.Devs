﻿using Application.Features.SoftwareLanguages.Dtos.CRUD;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.SoftwareLanguages.Command.DeleteSoftwareLanguage
{
    public class DeleteSoftwareLanguageCommand:IRequest<DeletedSoftwareLanguageDto>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public class DeleteSoftwareLanguageCommandHandler:IRequestHandler<DeleteSoftwareLanguageCommand, DeletedSoftwareLanguageDto>
        {
            private readonly ISoftwareLanguageRepository _softwareLanguageRepository;
            private readonly IMapper _mapper;

            public DeleteSoftwareLanguageCommandHandler(ISoftwareLanguageRepository softwareLanguageRepository, IMapper mapper)
            {
                _softwareLanguageRepository = softwareLanguageRepository;
                _mapper = mapper;
            }

            public async Task<DeletedSoftwareLanguageDto> Handle(DeleteSoftwareLanguageCommand request, CancellationToken cancellationToken)
            {
                SoftwareLanguage mappedSoftwareLanguage = _mapper.Map<SoftwareLanguage>(request);
                SoftwareLanguage deletedSoftwareLanguage = await _softwareLanguageRepository.DeleteAsync(mappedSoftwareLanguage);
                DeletedSoftwareLanguageDto deletedSoftwareLanguageDto = _mapper.Map<DeletedSoftwareLanguageDto>(deletedSoftwareLanguage);

                return deletedSoftwareLanguageDto;
            }
        }
    }
}
