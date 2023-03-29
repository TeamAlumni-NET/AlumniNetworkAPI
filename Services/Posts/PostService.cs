using AlumniNetworkAPI.Exceptions;
using AlumniNetworkAPI.Models;
using AlumniNetworkAPI.Models.DTOs.PostDtos;
using AlumniNetworkAPI.Models.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

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
        public async Task<IEnumerable<Post>> GetAllChildPosts(int id)
        {
            var postList = await _dbContext.Posts
                .Where(p => p.ParentPostId == id)
                .Include(p => p.User)
                .ToListAsync();
            return postList;
        }

        public async Task<IEnumerable<Post>> GetAllChildPostsEvent(int id)
        {
            var postList = await _dbContext.Posts
                .Where(p => p.EventId == id)
                .Include(p => p.User)
                .ToListAsync();
            var result = new ChildPostRootDto();
            result.ChildPosts = new List<ChildPostDto>();
            return postList;
        }

            public async Task<Post> GetById(int id)
        {
            var post = await _dbContext.Posts
                .Where(p => p.Id == id)
                .Include(p => p.User)
                .FirstOrDefaultAsync();
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
            _dbContext.Posts.Attach(entity);
            _dbContext.Entry(entity).Property(p => p.Title).IsModified = true;
            _dbContext.Entry(entity).Property(p => p.Content).IsModified = true;
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
                .ThenInclude(c => c.User)
                .ToListAsync();

            return posts;
        }
        public async Task<IEnumerable<Post>> GetDashboard(int userId)
        {
            var posts = await _dbContext.Posts
                .Where(p => (p.Group.Users.Any(u => u.Id == userId)) || (p.Topic.Users.Any(u => u.Id == userId)) || (p.ChildPosts.Any(c => c.UserId == userId)))
                .Where(p => p.Title != null)
                .Include(p => p.Group)
                .Include(p => p.Topic)
                .Include(p => p.User)
                .Include(p => p.ChildPosts)
                .ThenInclude(c => c.User)
                .ToListAsync();

            return posts;
        }
        public async Task<IEnumerable<Post>> GetGroup(int groupid)
        {
            var posts = await _dbContext.Posts
                .Where(p => p.GroupId == groupid)
                .Where(p => p.Title != null)
                .Include(p => p.Group)
                .Include(p => p.Topic)
                .Include(p => p.User)
                .Include(p => p.ChildPosts)
                .ThenInclude(c => c.User)
                .ToListAsync();

            return posts;
        }

        public async Task<IEnumerable<Post>> GetTopicsPosts(int topicsId)
        {
            var tlist = await _dbContext.Posts
           .Include(p => p.Topic)
           .Include(p => p.User)
           .Include(p => p.ChildPosts)
           .ThenInclude(c => c.User)
           .Where(t => t.TopicId == topicsId && t.Title != null)
           .ToListAsync();

            return tlist;
        }
    }
}
