﻿namespace campusCentralMvc.Models
{
    public class UserAccountCourseSchedule
    {
        public int UserAccountCourseScheduleId { get; set; }
        public int UserAccountId { get; set; }
        public string TopicNameAssigned { get; set;}
        public int TopicTravelStatus { get; set; }
        public float TopicFinalScore { get; set;}
        public int TopicPeriodAttended { get; set;}
        public int CourseId { get; set;}
        public TimeSpan? StartPeriodScheduled { get; set; }
        public TimeSpan? EndPeriodScheduled { get; set; }
        public string ClassDay { get; set; }
        public string PeriodTypeScheduled { get; set; }
        public int ClassGroupId { get; set; }
    }
}