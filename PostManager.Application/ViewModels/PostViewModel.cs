using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostManager.Application.ViewModels
{
    public class PostViewModel
    {
        public PostViewModel(int id, string description, string nameUser)
        {
            this.Id = id;
            this.Description = description;
            this.NameUser = nameUser;
            this.Status = true;
            RegistrationDate = DateTime.UtcNow;
        }
        public int Id { get; set; } 
        public string Description { get; set; } 
        private string NameUser { get; set; }
        public bool Status { get; private set; }
        public DateTime RegistrationDate { get; private set; }

    }
}
