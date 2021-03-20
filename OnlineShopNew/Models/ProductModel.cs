// <copyright file="ProductModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace OnlineShop.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Http;

    [Table("Products")]
    public class ProductModel
    {
        [Key]
        [Column("Id")]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [ForeignKey("FK_CATEGORY_ID")]
        [Column("CategoryId")]
        public int CategoryId { get; set; }
        public CategoryModel Category { get; set; }

        [Required]
        [Column("Name")]
        public string Name { get; set; }

        [Required]
        [Column("Price", TypeName = "decimal(5, 2)")]
        public decimal Price { get; set; }

        [Required]
        [Column("Count")]
        public int Count { get; set; }

        [Column("Description")]
        public string Description { get; set; }

    }
}