// <copyright file="BuyingHistory.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace OnlineShop.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("BuyingHistory")]
    public class BuyingHistory
    {
        [Key]
        [Column("Id")]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("UserId")]
        [ForeignKey("FKUserId")]
        [Required]
        public AccountModel AccountId { get; set; }

        [Column("OrderId")]
        [ForeignKey("FKOrdersId")]
        [Required]
        public OrderModel OrderId { get; set; }

    }
}
