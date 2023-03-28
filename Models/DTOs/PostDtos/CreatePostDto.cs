﻿using AlumniNetworkAPI.Models.DTOs.UserDtos;

namespace AlumniNetworkAPI.Models.DTOs.PostDtos
{
    public class CreatePostDto
    {
        public string? Title { get; set; }
        public string Content { get; set; }
        public int? TargetUserId { get; set; }
        public UserDto User { get; set; }
        public int? TopicId { get; set; }
        public int? GroupId { get; set; }
        public int? ParentPostId { get; set; }
        public int? EventId { get; set; }

    }
}
