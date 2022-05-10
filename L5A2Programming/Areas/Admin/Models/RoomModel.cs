﻿using System.ComponentModel.DataAnnotations;

namespace L5A2Programming.Models
{
    public class RoomModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
