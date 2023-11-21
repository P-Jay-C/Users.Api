﻿using System.ComponentModel.DataAnnotations.Schema;

namespace Users.Api.Models
{
    public class Username
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int? UserId { get; set; }

        [ForeignKey("UserId")]
        public User? User { get; set; }
    }
}
