// <copyright file="CategoryModel.cs" company="MartiAndKoceto">
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

    [Table("Categories")]
    public class CategoryModel
    {
        [Key]
        [Column("Id")]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("Name")]
        [Required]
        public string Name { get; set; }
    }
}
