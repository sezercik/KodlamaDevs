using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Dtos
{
    public class DefaultBaseDto
    {
        //Diğer tüm DTO'lar da sadece aşağıdaki özellikler olunca onu Default Base olarak ayırmak istedim
        //Ekstra özellikler olursa zaten diğer dtolara eklenir
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
