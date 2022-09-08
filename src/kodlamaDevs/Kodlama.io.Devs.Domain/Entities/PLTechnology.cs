using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Domain.Entities
{
    public class PLTechnology:Entity
    {
        public int ProgrammingLanguageId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        //Bu kısım için ekstradan Entity oluşturmam gerek. Her seferinde şirket belirtmek yerine şirket eklenir ve ona göre seçilir
        //Şuanlık dursun burada
        //public string CompanyBehindTechnology { get; set; }//Like Google for Angular, META for react and Community for Vue
        public string ImageUrl { get; set; } //Teknolojilerin logoları için

        public virtual ProgrammingLanguage? ProgrammingLanguage { get; set; }

        public PLTechnology()
        {

        }

        public PLTechnology(int id, int programmingLanguageId, string name, string description, string imageUrl)
        {
            Id = id;
            ProgrammingLanguageId = programmingLanguageId;
            Name = name;
            Description = description;
            ImageUrl = imageUrl;
        }
    }
}
