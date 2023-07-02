using Application.Features.SoftwareLanguages.Dtos.CRUD;
using Application.Features.SoftwareLanguages.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.SoftwareLanguages.Command.CreateSoftwareLanguage
{
    public class CreateSoftwareLanguageCommand:IRequest<CreatedSoftwareLanguageDto>
    {
        public string Name { get; set; }
        public class CreateSoftwareLanguageCommandHandler : IRequestHandler<CreateSoftwareLanguageCommand, CreatedSoftwareLanguageDto>
        {
            private readonly ISoftwareLanguageRepository _softwareLanguageRepository;
            private readonly IMapper _mapper;
            private readonly SoftwareLanguageBusinessRules _softwareLanguageBusinessRules;

            public CreateSoftwareLanguageCommandHandler(ISoftwareLanguageRepository softwareLanguageRepository, IMapper mapper, SoftwareLanguageBusinessRules softwareLanguageBusinessRules)
            {
                _softwareLanguageRepository = softwareLanguageRepository;
                _mapper = mapper;
                _softwareLanguageBusinessRules = softwareLanguageBusinessRules;
            }

            public async Task<CreatedSoftwareLanguageDto> Handle(CreateSoftwareLanguageCommand request, CancellationToken cancellationToken)
            {
                await _softwareLanguageBusinessRules.SoftwareLanguageNameCanNotBeDuplicatedWhenInserted(request.Name);

                SoftwareLanguage mappedSoftwareLanguage = _mapper.Map<SoftwareLanguage>(request);
                SoftwareLanguage createdSoftwareLanguage = await _softwareLanguageRepository.AddAsync(mappedSoftwareLanguage);
                CreatedSoftwareLanguageDto createdSoftwareLanguageDto = _mapper.Map<CreatedSoftwareLanguageDto>(createdSoftwareLanguage);

                return createdSoftwareLanguageDto;
            }
        }
    }
}
