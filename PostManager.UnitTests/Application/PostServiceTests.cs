using Xunit;
using Moq;
using System.Threading.Tasks;
using PostManager.Core.Repository;
using PostManager.Application.InputModels;
using PostManager.Application.Services;
using PostManager.Core.Entities;
using PostManager.Application.ViewModels;
using System.Collections.Generic;
using PostManager.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace PostManager.UnitTests.Application
{
    public class PostServiceTests
    {       

        [Fact]
        public async Task PostIsOk_SaveIsCalled_PostViewModelReturned()
        {
            // Arrange
            var postRepositoryMock = new Mock<IPostRepository>();
            var postInputModel = new PostInputModel
            {
                PostId = 1,
                Description = "Post Test 1",
                NameUser = "Rogério"
            };            
           
            var postService = new PostService(postRepositoryMock.Object);

            // Act
            var result = await postService.Save(postInputModel);

            // Assert not null + valid type, 
            Assert.NotNull(result);          
            Assert.IsType<PostViewModel>(result);
            postRepositoryMock.Verify(ccr => ccr.Add(It.IsAny<Post>()), Times.Once);
        }
      
    }
}
