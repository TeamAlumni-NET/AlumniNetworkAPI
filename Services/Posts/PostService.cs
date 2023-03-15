using AlumniNetworkAPI.Exceptions;
using AlumniNetworkAPI.Models;
using AlumniNetworkAPI.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace AlumniNetworkAPI.Services.Posts
{
    public class PostService : IPostService
    {
        private readonly AlumniNetworkDBContext _dbContext;


        public PostService(AlumniNetworkDBContext dBContext)
        {
            _dbContext = dBContext;
        }

        public async Task<IEnumerable<Post>> GetAll()
        {
            return await _dbContext.Posts.ToListAsync();
        }

        public async Task<Post> GetById(int id)
        {
            var post = await _dbContext.Posts.FindAsync(id);
            await _dbContext.Posts.FindAsync(id);

            if (post == null)
            {
                throw new PostNotFoundException(id);
            }

            return post;
        }

        public async Task<Post> Create(Post entity)
        {
            _dbContext.Posts.Add(entity);
            await _dbContext.SaveChangesAsync();

            return entity;
        }



        public Task DeleteById(int id)
        {
            throw new NotImplementedException();
        }

       

       

        public Task<Post> Update(Post entity)
        {
            throw new NotImplementedException();
        }
    }
}
