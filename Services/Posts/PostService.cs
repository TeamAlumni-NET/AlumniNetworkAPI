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

        public async Task<Post> Update(Post entity)
        {
            var foundPost = await _dbContext.Posts.AnyAsync(x => x.Id == entity.Id);

            if (foundPost == null)
            {
                throw new PostNotFoundException(entity.Id);
            }
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return entity;
        }


        public async Task DeleteById(int id)
        {
            var post = await _dbContext.Posts.FindAsync(id);
            if (post == null)
            {
                throw new PostNotFoundException(id);
            }
            _dbContext.Posts.Remove(post);
            await _dbContext.SaveChangesAsync();
        }

       

       

        
    }
}
