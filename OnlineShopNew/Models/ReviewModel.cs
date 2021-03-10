// <copyright file="Reviews.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace OnlineShop.Models
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using OnlineShop.Data;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Threading.Tasks;

    [Table("Reviews")]
    public class ReviewModel
    {
        [Key]
        [Column("Id")]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ReviewId { get; set; }

        [Column("StarCount")]
        [Required]
        public int StarCount { get; set; }

        [Column("TextReview")]
        [Required]
        public string TextReview { get; set; }

        [Column("ProductId")]
        [Required]
        [ForeignKey("ProductModel")]
        public ProductModel Product { get; set; }

        [Column("AccountId")]
        [Required]
        [ForeignKey("FKAccountId")]
        public OnlineShopUser Account { get; set; }
    }
}
