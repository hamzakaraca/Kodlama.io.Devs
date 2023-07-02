using Application.Features.SoftwareLanguages.Command.CreateSoftwareLanguage;
using Application.Features.SoftwareLanguages.Command.DeleteSoftwareLanguage;
using Application.Features.SoftwareLanguages.Command.UpdateSoftwareLanguage;

using Application.Features.SoftwareLanguages.Models;
using Application.Features.Technologies.Command.CreateTechnology;
using Application.Features.Technologies.Command.DeleteTechnology;
using Application.Features.Technologies.Command.UpdateTechnology;
using Application.Features.Technologies.Dtos;
using Application.Features.Technologies.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Technologies.Profiles
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<Technology, CreatedTechnologyDto>().ReverseMap();
            CreateMap<Technology, CreateTechnologyCommand>().ReverseMap();
            CreateMap<Technology, UpdatedTechnologyDto>().ReverseMap();
            CreateMap<Technology, UpdateTechnologyCommand>().ReverseMap();
            CreateMap<Technology, DeletedTechnologyDto>().ReverseMap();
            CreateMap<Technology, DeleteTechnologyCommand>().ReverseMap();
            CreateMap<IPaginate<Technology>, TechnologyListModel>().ReverseMap();
            CreateMap<Technology, TechnologyListDto>().ForMember(c=>c.SoftwareLanguageName,opt=>opt.MapFrom(c=>c.SoftwareLanguage.Name)).ReverseMap();
            //CreateMap<Technology, SoftwareLanguageGetByIdDto>().ReverseMap();
        }
    }
}
