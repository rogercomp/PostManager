using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PostManager.Core.Entities;
using PostManager.Core.Repository;
using Microsoft.EntityFrameworkCore;

namespace PostManager.Infrastructure.Persistence.Repositorys
{

    public class PostRepository : IPostRepository
    {

        private readonly PostManagerDbContext _dbContext;

        public PostRepository(PostManagerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Add(Post post)
        {
            await _dbContext.Posts.AddAsync(post);    
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var post = await _dbContext.Posts.FindAsync(id);    

            if (post != null)
            {
                _dbContext.Posts.Remove(post);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<Post> Get(int id)
        {
            return await _dbContext.Posts.SingleOrDefaultAsync(e => e.Id == id);
        }

      
        public async Task<List<Post>> GetAll()
        {
            return await _dbContext.Posts.ToListAsync();
        }
    }
}
