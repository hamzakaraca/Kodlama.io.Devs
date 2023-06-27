using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.SoftwareLanguages.Rules
{
    public class SoftwareLanguageBusinessRules
    {
        private readonly ISoftwareLanguageRepository _softwareLanguageRepository;

        public SoftwareLanguageBusinessRules(ISoftwareLanguageRepository softwareLanguageRepository)
        {
            _softwareLanguageRepository = softwareLanguageRepository;
        }

        public async Task SoftwareLanguageNameCanNotBeDuplicatedWhenInserted(string name)
        {
            IPaginate<SoftwareLanguage> result = await _softwareLanguageRepository.GetListAsync(b => b.Name == name);
            if (result.Items.Any()) throw new BusinessException("SoftwareLanguage name exists.");
        }

        public void SoftwareLanguageShouldExistWhenRequested(SoftwareLanguage softwareLanguage)
        {
            if (softwareLanguage == null) throw new BusinessException("Requested softwarelanguage does not exists.");
        }
    }
}
