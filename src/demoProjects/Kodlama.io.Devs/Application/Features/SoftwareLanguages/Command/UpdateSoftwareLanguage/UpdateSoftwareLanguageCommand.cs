using Application.Features.SoftwareLanguages.Dtos.CRUD;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.SoftwareLanguages.Command.UpdateSoftwareLanguage
{
    public class UpdateSoftwareLanguageCommand:IRequest<UpdatedSoftwareLanguageDto>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public class UpdateSoftwareLanguageCommandHandler:IRequestHandler<UpdateSoftwareLanguageCommand, UpdatedSoftwareLanguageDto>
        {
            private readonly ISoftwareLanguageRepository _softwareLanguageRepository;
            private readonly IMapper _mapper;

            public UpdateSoftwareLanguageCommandHandler(ISoftwareLanguageRepository softwareLanguageRepository, IMapper mapper)
            {
                _softwareLanguageRepository = softwareLanguageRepository;
                _mapper = mapper;
            }

            public async Task<UpdatedSoftwareLanguageDto> Handle(UpdateSoftwareLanguageCommand request, CancellationToken cancellationToken)
            {
                SoftwareLanguage mappedSoftwareLanguage = _mapper.Map<SoftwareLanguage>(request);
                SoftwareLanguage updatedSoftwareLanguage = await _softwareLanguageRepository.UpdateAsync(mappedSoftwareLanguage);
                UpdatedSoftwareLanguageDto updatedSoftwareLanguageDto = _mapper.Map<UpdatedSoftwareLanguageDto>(updatedSoftwareLanguage);

                return updatedSoftwareLanguageDto;
            }
        }
    }
}
