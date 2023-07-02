using Application.Features.SoftwareLanguages.Command.CreateSoftwareLanguage;
using Application.Features.SoftwareLanguages.Command.DeleteSoftwareLanguage;
using Application.Features.SoftwareLanguages.Command.UpdateSoftwareLanguage;
using Application.Features.SoftwareLanguages.Dtos.CRUD;
using Application.Features.SoftwareLanguages.Dtos.Get;
using Application.Features.SoftwareLanguages.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.SoftwareLanguages.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<SoftwareLanguage, CreatedSoftwareLanguageDto>().ReverseMap();
            CreateMap<SoftwareLanguage, CreateSoftwareLanguageCommand>().ReverseMap();
            CreateMap<SoftwareLanguage, UpdatedSoftwareLanguageDto>().ReverseMap();
            CreateMap<SoftwareLanguage, UpdateSoftwareLanguageCommand>().ReverseMap();
            CreateMap<SoftwareLanguage, DeletedSoftwareLanguageDto>().ReverseMap();
            CreateMap<SoftwareLanguage, DeleteSoftwareLanguageCommand>().ReverseMap();
            CreateMap<IPaginate<SoftwareLanguage>, SoftwareLanguageListModel>().ReverseMap();
            CreateMap<SoftwareLanguage, SoftwareLanguageListDto>().ReverseMap();
            CreateMap<SoftwareLanguage, SoftwareLanguageGetByIdDto>().ReverseMap();
        }
    }
}
