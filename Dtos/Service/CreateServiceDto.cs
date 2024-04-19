﻿using System.ComponentModel.DataAnnotations;

namespace BrochureAPI.Dtos.Service
{
    public class CreateServiceDto
    {
        [Required]

        public string Title { get; set; } = string.Empty;
        [Required]

        public string Description { get; set; } = string.Empty;
    }
}
