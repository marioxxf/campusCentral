﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace campusCentralApi.Models
{
    public partial class Course
    {
        [Key]
        public int CourseId { get; set; }
        [StringLength(100)]
        [Unicode(false)]
        public string Name { get; set; }
        public int? Duration { get; set; }
        [StringLength(100)]
        [Unicode(false)]
        public string Category { get; set; }
    }
}