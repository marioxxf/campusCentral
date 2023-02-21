namespace campusCentralMvc.Models
{
    public class UserAccount
    {
        public int UserAccountId { get; set; }
        public string Name { get; set;}
        public string Username { get; set;}
        public string Email { get; set;}
        public string ContactNumber { get; set;}
        public string Password { get; set;}
        public string AccessLevel { get; set;}
        public string LoginStatus { get; set;}
        public string CreationDate { get; set;}
        public string SessionId { get; set;}
    }
}