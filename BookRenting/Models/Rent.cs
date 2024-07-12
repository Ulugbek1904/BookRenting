namespace BookRenting.Models
{
    public class Rent
    {    
        public int RentId { get; set; }
        public int Userid { get; set; }
        public int BookId {  get; set; }
        public DateOnly RentAt { get; set; }
        public DateOnly ReturnAt { get; set; }
        public bool IsReturned { get; set; }

    }
}
