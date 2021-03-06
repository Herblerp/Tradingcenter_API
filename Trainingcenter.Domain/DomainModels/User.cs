﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Trainingcenter.Domain.DomainModels
{
    public class User
    {
        public int UserId { get; set; }
        [Required]
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Description { get; set; }
        [Required]
        public string Email { get; set; }

        [Required]
        public byte[] PasswordHash { get; set; }
        [Required]
        public byte[] PasswordSalt { get; set; }

        public DateTime CreatedOn { get; set; }
        public DateTime LastActive { get; set; }

        public string PictureURL { get; set; }
        public string VerificationKey { get; set; }
        public bool IsVerified { get; set; }
        public ICollection<Order> Orders { get; set; }
        public ICollection<Portfolio> Portfolios { get; set; }
        public ICollection<ExchangeKey> ExchangeKeys { get; set; }
    }
}
