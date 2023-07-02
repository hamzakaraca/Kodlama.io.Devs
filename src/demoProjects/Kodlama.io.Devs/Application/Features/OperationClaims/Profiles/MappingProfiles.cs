
using Application.Features.OperationClaims.Dtos.CRUD;
using Application.Features.SoftwareLanguages.Command.CreateSoftwareLanguage;
using Application.Features.SoftwareLanguages.Command.DeleteSoftwareLanguage;
using Application.Features.SoftwareLanguages.Command.UpdateSoftwareLanguage;
using Application.Features.SoftwareLanguages.Dtos.CRUD;
using Application.Features.SoftwareLanguages.Dtos.Get;
using Application.Features.SoftwareLanguages.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Core.Security.Entities;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.OperationClaims.Commands.CreateOperationClaim;
using Application.Features.OperationClaims.Commands.DeleteOperationClaim;
using Application.Features.OperationClaims.Commands.UpdateOperationClaim;
using Application.Features.OperationClaims.Dtos.Get;
using Application.Features.OperationClaims.Models;

namespace Application.Features.OperationClaims.Profiles
{
    public class MappingProfiles : Profile
    {
        
        public MappingProfiles()
        {
            CreateMap<OperationClaim, CreatedOperationClaimDto>().ReverseMap();
            CreateMap<OperationClaim, CreateOperationClaimCommand>().ReverseMap();
            CreateMap<OperationClaim, UpdatedOperationClaimDto>().ReverseMap();
            CreateMap<OperationClaim, UpdateOperationClaimCommand>().ReverseMap();
            CreateMap<OperationClaim, DeletedOperationClaimDto>().ReverseMap();
            CreateMap<OperationClaim, DeleteOperationClaimCommand>().ReverseMap();
            CreateMap<IPaginate<OperationClaim>, OperationClaimListModel>().ReverseMap();
            CreateMap<OperationClaim, OperationClaimListDto>().ReverseMap();
            //CreateMap<OperationClaim, OperationClaimGetByIdDto>().ReverseMap();

        }
    }
}
