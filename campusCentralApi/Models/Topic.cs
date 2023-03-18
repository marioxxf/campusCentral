﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace campusCentralApi.Models
{
    public partial class Topic
    {
        [Key]
        public int TopicId { get; set; }
        [StringLength(100)]
        [Unicode(false)]
        public string Name { get; set; }
        [StringLength(20)]
        [Unicode(false)]
        public string Acronym { get; set; }
        public int? TeacherAssignedUserAccountId { get; set; }
        public int? CourseId { get; set; }
        public int? SemesterAvailability { get; set; }
        public int? TotalHours { get; set; }
        public int? ClassQuantity { get; set; }
    }
}