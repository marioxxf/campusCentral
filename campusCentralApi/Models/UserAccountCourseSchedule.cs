﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace campusCentralApi.Models
{
    public partial class UserAccountCourseSchedule
    {
        [Key]
        public int UserAccountCourseScheduleId { get; set; }
        public int? UserAccountId { get; set; }
        [StringLength(100)]
        [Unicode(false)]
        public string TopicNameAssigned { get; set; }
        public int? TopicTravelStatus { get; set; }
        [Column(TypeName = "float")]
        public float TopicFinalScore { get; set; }
        public int? TopicPeriodAttended { get; set; }
        public int? CourseId { get; set; }
        public TimeSpan? StartPeriodScheduled { get; set; }
        public TimeSpan? EndPeriodScheduled { get; set; }
        [StringLength(25)]
        [Unicode(false)]
        public string ClassDay { get; set; }
        [StringLength(25)]
        [Unicode(false)]
        public string PeriodTypeScheduled { get; set; }
        public int? ClassGroupId { get; set; }
    }
}