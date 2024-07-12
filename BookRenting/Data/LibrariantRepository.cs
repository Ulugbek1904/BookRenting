using BookRenting.Models;

namespace BookRenting.Data
{
    public class LibrariantRepository : ILibrariantRepository
    {
        Dictionary<int, User> librariants;

        public LibrariantRepository()
        {
            this.librariants = new Dictionary<int, User>();
        }
        public IList<User> SelectAllLibrariants()=>
            librariants.Values.ToList();

        public User SelectLibrariantById(int LibrariantId)
        {
            if (!librariants.ContainsKey(LibrariantId))
                throw new KeyNotFoundException("librariant not found");
            return librariants[LibrariantId];
        }

        public User InsertLibrariant(User Librariant)
        {
            if (librariants.ContainsKey(Librariant.UserId))
                throw new ArgumentException("librariant with this key already exists");

            librariants.Add(Librariant.UserId, Librariant);

            return Librariant;
        }

        public User UpdateLibrariant(int LibrariantId, User Librariant)
        {
            var existedlibrariant = librariants[LibrariantId];

            if(!string.IsNullOrEmpty(Librariant.Name))
                existedlibrariant.Name = Librariant.Name;
                existedlibrariant.Birthday = Librariant.Birthday;
                existedlibrariant.Gender = Librariant.Gender;
                existedlibrariant.Type = Librariant.Type;
            return existedlibrariant;
        }
        public bool DeleteLibrariant(int LibrariantId)
        {
            if (!librariants.ContainsKey(LibrariantId))
                throw new ArgumentException("librariant with this key does not exist");
            librariants.Remove(LibrariantId);

            return librariants.Remove(LibrariantId);

        } 
    }
}
