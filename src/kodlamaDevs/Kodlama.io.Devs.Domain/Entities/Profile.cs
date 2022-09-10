using Core.Persistence.Repositories;
using Core.Security.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Domain.Entities
{
    public class Profile:Entity
    {
        public int UserId { get; set; }
        public string GithubAddress { get; set; }
        //İleri de linkedin, twitter gibi hesapların da eklenmesi istenirse, buradan eklenebilir
        public virtual User? User { get; set; }
        public Profile()
        {

        }

        public Profile(int id, int userId, string githubAddress)
        {
            Id = id;
            UserId = userId;
            GithubAddress = githubAddress;
        }

    }
}
