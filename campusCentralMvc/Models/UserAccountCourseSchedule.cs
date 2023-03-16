namespace campusCentralMvc.Models
{
    public class UserAccountCourseSchedule
    {
        public int UserAccountCourseScheduleId { get; set; }
        public int UserAccountId { get; set; }
        public string TopicNameAssigned { get; set;}
        public int TopicTravelStatus { get; set; }
        public float TopicFinalScore { get; set;}
        public int TopicPeriodAttended { get; set;}
    }
}