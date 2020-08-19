﻿using System;
using System.ComponentModel.DataAnnotations;
using VaporStore.Data.Models.Enums;

namespace VaporStore.Data.Models
{
    public class Purchase
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public PurchaseType Type { get; set; }

        [Required]
        public string ProductKey { get; set; }
        
        [Required]
        public DateTime Date { get; set; }

        [Required]
        public int CardId { get; set; }

        [Required]
        public virtual Card Card { get; set; }

        [Required]
        public int GameId { get; set; }

        [Required]
        public virtual Game Game { get; set; }
    }
}
