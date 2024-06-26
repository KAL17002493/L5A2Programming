﻿//Asset model
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace L5A2Programming.Models
{
    public class AssetModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string AssetName { get; set; }


        [Required]
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public CategoryModel Category { get; set; }

        [Required]
        public int InstitutionId { get; set; }
        [ForeignKey("InstitutionId")]
        public InstitutionModel Institution { get; set; }

        [Required]
        public int RoomId { get; set; }
        [ForeignKey("RoomId")]
        public RoomModel Room { get; set; }
    }
}
