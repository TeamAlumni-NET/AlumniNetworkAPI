﻿using System.ComponentModel.DataAnnotations;

namespace AlumniNetworkAPI.Models.DTOs.Topic
{
    public class TopicDto
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
