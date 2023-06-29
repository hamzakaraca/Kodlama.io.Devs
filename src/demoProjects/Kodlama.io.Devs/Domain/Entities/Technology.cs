using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Technology:Entity
    {
        
        public int SoftwareLanguageId { get; set; }
        public string Name { get; set; }
        public SoftwareLanguage? SoftwareLanguage { get; set; }

        public Technology()
        {
                
        }
        public Technology(int ıd, int softwareLanguageId, string name)
        {
            Id = ıd;
            SoftwareLanguageId = softwareLanguageId;
            Name = name;
        }
    }
}
