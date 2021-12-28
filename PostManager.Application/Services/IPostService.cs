using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PostManager.Application.InputModels;
using PostManager.Application.ViewModels;

namespace PostManager.Application.Services
{
    public interface IPostService
    { 
        Task<PostViewModel> Get(int id);

        Task<List<PostViewModel>> GetAll();

        Task<PostViewModel> Save(PostInputModel postInputModel);

        Task Delete(int id);

    }
}
