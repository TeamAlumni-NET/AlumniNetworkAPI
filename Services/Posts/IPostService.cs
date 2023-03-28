﻿using AlumniNetworkAPI.Models.DTOs.PostDtos;
using AlumniNetworkAPI.Models.Models;

namespace AlumniNetworkAPI.Services.Posts
{
    public interface IPostService : ICrudService<Post, int>
    {
        Task<IEnumerable<Post>> GetAllChildPostsEvent(int id);
        Task<IEnumerable<Post>> GetAllChildPosts(int id);
        Task<IEnumerable<Post>> GetTimeline(int userId);
        Task<IEnumerable<Post>> GetGroup(int groupId);
        Task<IEnumerable<Post>> GetTopicsPosts(int topicsId);
        Task<IEnumerable<Post>> GetDashboard(int userId);
    }
}
