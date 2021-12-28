using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PostManager.Core.Entities;

namespace PostManager.Core.Repository
{
    public interface IPostRepository
    {
        Task<List<Post>> GetAll();
        Task<Post> Get(int id);
        Task Add(Post post);
        Task Delete(int id);

    }
}
