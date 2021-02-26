// <copyright file="OrderModel.cs" company="PlaceholderCompany">
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

    [Table("Orders")]
    public class OrderModel
    {
        [Key]
        [Column("Id")]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("ProductId")]
        [ForeignKey("OrdersProductId")]
        [Required]
        public ProductModel Product { get; set; }

        [Column("Count")]
        [Required]
        public int Count { get; set; }

        [Column("Date")]
        [Required]
        public DateTime Date { get; set; }

    }
}
