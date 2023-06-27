using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.SoftwareLanguages.Models
{
    public class SoftwareLanguageListModel:BasePageableModel
    {
        public IList<SoftwareLanguage> Items { get; set; }
    }
}
