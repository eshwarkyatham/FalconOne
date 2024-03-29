﻿using System.ComponentModel.DataAnnotations;

namespace Utilities.DTOs
{
    public class UserClaimDTO
    {
        [Required]
        public string Type { get; set; }
        [Required]
        public string Value { get; set; }
        public string? PolicyId { get; set; }
        public string Description { get; set; }
    }
}
