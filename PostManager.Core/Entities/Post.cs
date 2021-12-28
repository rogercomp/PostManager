using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostManager.Core.Entities
{
    public class Post
    {

        public Post(int id, string description, string nameUser)
        {
            this.Id = id;
            this.Description = description;
            this.NameUser = nameUser;
            this.Status = true;
            RegistrationDate = DateTime.UtcNow;
        }
        public int Id { get; private set; } 
        public string Description { get; private set; }
        public string NameUser { get; private set; }
        public bool Status { get; private set; }
        public DateTime RegistrationDate { get; private set; }

    }
}
