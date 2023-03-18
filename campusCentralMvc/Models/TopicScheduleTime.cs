namespace campusCentralMvc.Models
{
    public class TopicScheduleTime
    {
        public int TopicScheduleTimeId { get; set; }
        public int TopicId { get; set; }
        public int CourseId { get; set; }
        public TimeSpan? StartTime { get; set; }
        public TimeSpan? EndTime { get; set; }
        public string PeriodTypeScheduled { get; set; }
    }
}