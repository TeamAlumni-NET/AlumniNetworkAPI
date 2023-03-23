using AlumniNetworkAPI.Exceptions;
using AlumniNetworkAPI.Models;
using AlumniNetworkAPI.Models.DTOs.PostDtos;
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
        public async Task<ChildPostRootDto> GetAllChildPosts(int id)
        {
            var postList = await _dbContext.Posts
                .Where(p => p.ParentPostId == id)
                .ToListAsync();
            var result = new ChildPostRootDto();
            result.ChildPosts = new List<ChildPostDto>();

            foreach (var post in postList)
            {
                var single = new ChildPostDto();
                var user = await _dbContext.Users
                .Where(u => u.Id == post.UserId)
                .FirstOrDefaultAsync();

                single.Id = post.Id;
                single.Content = post.Content;
                single.TimeStamp = post.TimeStamp;
                single.username = user.Username;
                result.ChildPosts.Add(single);
            }
            return result;
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
        public async Task<IEnumerable<Post>> GetTimeline(int userId)
        {
            var posts = await _dbContext.Posts
                .Where(p => (p.Group.Users.Any(u => u.Id == userId)) || (p.Topic.Users.Any(u => u.Id == userId)))
                .Where(p => p.Title != null)
                .Include(p => p.Group)
                .Include(p => p.Topic)
                .Include(p => p.User)
                .Include(p => p.ChildPosts)
                .ToListAsync();

            return posts;
        }
        public async Task<IEnumerable<Post>> GetGroup(int groupid)
        {
            var list = await _dbContext.Groups
                .Where(g => g.Id == groupid)
                .Include(p => p.Posts)
                .ThenInclude(p => p.ChildPosts)
                .ThenInclude(p => p.User)
                .ThenInclude(p => p.Groups)
                .Select(g => g.Posts.Where(p => p.Title != null))
                .SingleOrDefaultAsync();

            return list;
        }
    }
}
