﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace campusCentralApi.Models
{
    public partial class UserAccount
    {
        [Key]
        public int UserAccountId { get; set; }
        [StringLength(35)]
        [Unicode(false)]
        public string Name { get; set; }
        [StringLength(25)]
        [Unicode(false)]
        public string Username { get; set; }
        [StringLength(40)]
        [Unicode(false)]
        public string Email { get; set; }
        [StringLength(15)]
        [Unicode(false)]
        public string ContactNumber { get; set; }
        [StringLength(20)]
        [Unicode(false)]
        public string Password { get; set; }
        public int? AccessLevel { get; set; }
        public int? LoginStatus { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreationDate { get; set; }
        [StringLength(175)]
        [Unicode(false)]
        public string SessionId { get; set; }
        public int? ClassGroupId { get; set; }
    }
}