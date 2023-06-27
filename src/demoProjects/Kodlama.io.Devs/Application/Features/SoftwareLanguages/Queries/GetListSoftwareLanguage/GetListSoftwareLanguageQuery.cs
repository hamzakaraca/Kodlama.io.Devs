﻿using Application.Features.SoftwareLanguages.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.SoftwareLanguages.Queries.GetListSoftwareLanguage
{
    public class GetListSoftwareLanguageQuery:IRequest<SoftwareLanguageListModel>
    {
        public PageRequest PageRequest { get; set; }
        public class GetListSoftwareLanguageQueryHandler:IRequestHandler<GetListSoftwareLanguageQuery, SoftwareLanguageListModel>
        {
            private readonly ISoftwareLanguageRepository _softwareLanguageRepository;
            private readonly IMapper _mapper;

            public GetListSoftwareLanguageQueryHandler(ISoftwareLanguageRepository softwareLanguageRepository, IMapper mapper)
            {
                _softwareLanguageRepository = softwareLanguageRepository;
                _mapper = mapper;
            }

            public async Task<SoftwareLanguageListModel> Handle(GetListSoftwareLanguageQuery request, CancellationToken cancellationToken)
            {
                IPaginate<SoftwareLanguage> softwareLanguages = await _softwareLanguageRepository.GetListAsync(index:request.PageRequest.Page,size:request.PageRequest.PageSize);
                SoftwareLanguageListModel mappedSoftwareLanguageListModel = _mapper.Map<SoftwareLanguageListModel>(softwareLanguages);
                return mappedSoftwareLanguageListModel;
            }
        }
    }
}
