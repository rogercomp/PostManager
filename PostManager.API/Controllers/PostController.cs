using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PostManager.Application.InputModels;
using PostManager.Application.Services;

namespace PostManager.API.Controllers
{
    
    [Route("api/[controller]")]
    public class PostController : ControllerBase
    {
        private readonly IPostService _postService;

        public PostController(IPostService postService)
        {
            _postService = postService;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(int id)
        {
            var post = await _postService.Get(id);

            if (post == null)
                return NotFound();

            return Ok(post);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]       
        public async Task<IActionResult> GetAll()
        {
            var posts = await _postService.GetAll();           

            return Ok(posts);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Post([FromBody] PostInputModel postInputModel)
        {
            var addedPost = await _postService.Save(postInputModel);

            return Ok(addedPost);
        }


        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]     
        public async Task<IActionResult> Delete(int id)
        {
            var post = await _postService.Get(id);
            if(post == null)
                return NotFound();
            await _postService.Delete(id);
            return NoContent();            
        }
    }
}
