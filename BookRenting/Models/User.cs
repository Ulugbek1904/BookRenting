namespace BookRenting.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Name { get; set; } 
        public Gender Gender { get; set; } 
        public DateTime Birthday { get; set; } 
        public UserType Type { get; set; } 


    }

    public enum Gender
    {
        male,
        female
    }

    public enum UserType
    {
        Student,
        Librariant
    }
}
