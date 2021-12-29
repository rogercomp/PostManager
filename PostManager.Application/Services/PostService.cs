using PostManager.Application.InputModels;
using PostManager.Application.ViewModels;
using PostManager.Core.Entities;
using PostManager.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostManager.Application.Services
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;

        public PostService(IPostRepository postRepository)
        {
            _postRepository = postRepository;   
        }

        public async Task<IEnumerable<PostViewModel>> GetAll()
        {
            var lista = await _postRepository.GetAll();
           
            return from t in lista select new PostViewModel(t.Id, t.Description, t.NameUser);
        }

        public async Task<PostViewModel> Get(int id)
        {
            var post = await _postRepository.Get(id);

            PostViewModel? postReturn = null;

            if(post != null)
                postReturn = new PostViewModel(post.Id, post.Description, post.NameUser);        

            return postReturn;
        }

        public async Task<PostViewModel> Save(PostInputModel postInputModel)
        {
            Post post = new Post(postInputModel.PostId, postInputModel.Description, postInputModel.NameUser);
                   
            await _postRepository.Add(post);

            return new PostViewModel(post.Id, post.Description, post.NameUser);
        }

        public async Task Delete(int id)
        {
            await _postRepository.Delete(id);
        }

       
    }
}
