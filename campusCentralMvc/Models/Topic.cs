namespace campusCentralMvc.Models
{
    public class Topic
    {
        public int TopicId { get; set; }
        public string Name { get; set; }
        public string Acronym { get; set;}
        public int TeacherAssignedUserAccountId { get; set; }
        public int CourseId { get; set;}
        public int SemesterAvailability { get; set;}
        public int TotalHours { get; set;}
        public int ClassQuantity { get; set;}
    }
}