// <copyright file="AccountModel.cs" company="PlaceholderCompany">
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

    [Table("Accounts")]
    public class AccountModel
    {
        [Key]
        [Column("Id")]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [Column("Type")]
        public bool Type { get; set; }

        [Required]
        [Column("Username")]
        [MinLength(8, ErrorMessage = "Username must be at least 8 characters.")]
        public string Username { get; set; }

        [Required]
        [Column("Password")]
        [RegularExpression("^(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z])(?=.*[@#$%^&-+=()])(?=\\S+$).{8, 20}$", ErrorMessage = "It contains at least 8 characters and at most 20 characters." + "It contains at least one digit." + "It contains at least one upper case alphabet." + "It contains at least one lower case alphabet." + "It contains at least one special character which includes!@#$%&*()-+=^." + "It doesn’t contain any white space.")]
        public string Password { get; set; }

        [Required]
        [EmailAddress]
        [Column("Email")]
        public string Email { get; set; }

        [Required]
        [Column("FirstName")]
        public string FirstName { get; set; }

        [Required]
        [Column("LastName")]
        public string LastName { get; set; }

        [Required]
        [Column("DateOfBirth")]
        [Range(typeof(DateTime), "1/2/1900", "1/1/2010", ErrorMessage = "Value for {0} must be between {1} and {2}")]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [Column("PhoneNumber")]
        [Phone]
        public string PhoneNumber { get; set; }
    }
}
