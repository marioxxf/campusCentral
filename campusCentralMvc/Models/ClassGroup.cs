namespace campusCentralMvc.Models
{
    public class ClassGroup
    {
        public int ClassGroupId { get; set; }
        public int CourseId { get; set; }
        public int ClassGroupEnrolledUsersQuantity { get; set; }
        public int Status { get; set; }
        public int MinEnrolledUsers { get; set; }
        public int MaxEnrolledUsers { get; set; }
        public TimeSpan? StartAt { get; set; }
    }
}