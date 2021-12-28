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

        public async Task<List<PostViewModel>> GetAll()
        {
            var posts = await _postRepository.GetAll();
            List<PostViewModel> lista = new List<PostViewModel>();
            foreach (var item in posts)
            {
               var post = new PostViewModel(item.Id, item.Description, item.NameUser);
                lista.Add(post);
            }
            return lista;
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
