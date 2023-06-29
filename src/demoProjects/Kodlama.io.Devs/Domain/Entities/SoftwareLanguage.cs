using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class SoftwareLanguage:Entity
    {
        public string Name { get; set; }
        public IList<Technology> Technologies { get; set; }
        public SoftwareLanguage()
        {

        }
        public SoftwareLanguage(int id,string name):this()
        {
            Id=id;
            Name = name;
        }
    }
}
