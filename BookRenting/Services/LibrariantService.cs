using BookRenting.Data;
using BookRenting.Models;

namespace BookRenting.Services
{
    public class LibrariantService : ILibrariantServices
    {
        private readonly ILibrariantRepository librariantrepository;

        public LibrariantService()
        {
            this.librariantrepository =
                new LibrariantRepository();
        }

        public IList<User> RetrieveLibrariants(string name = null)
        {
            var librariants =
                this.librariantrepository.SelectAllLibrariants();

            if(!string.IsNullOrEmpty(name))
            {
                var filtredLibrariants = new List<User>();
                foreach(var librariant in librariants)
                    if(librariant.Name.Contains(name))
                        filtredLibrariants.Add(librariant);

                return filtredLibrariants;
            }
            return librariants;
        }
        public User RetrieveLibrariant(int librariantId)
        {
            User librariant = null;

            try
            {
                librariant =
                    this.librariantrepository.SelectLibrariantById(librariantId);

                return librariant;
            }
            catch(KeyNotFoundException exception)
            {
                Console.WriteLine(exception.Message);
            }
            return librariant;
        }
        public User AddLibrariant(User librariant)
        {
            User insertedLibrariant = null;

            try
            {
                insertedLibrariant =
                    this.librariantrepository.InsertLibrariant(librariant);

            }
            catch (ArgumentException exception)
            {
                Console.WriteLine(exception.Message);
            }
            return insertedLibrariant;
        }

        public User ModifyLibrariant(int librariantId, User librariant)
        {
            User modifiedLibrariant = null;

            try
            {
                modifiedLibrariant =
                    this.librariantrepository.UpdateLibrariant(librariantId, librariant);

            }
            catch (KeyNotFoundException exception)
            {
                Console.WriteLine(exception.Message);
            }
            return modifiedLibrariant;
        }

        public bool RemoveLibrariant(int librariantId)
        {
            bool isRemoved = false;

            try
            {
                isRemoved =
                    this.librariantrepository.DeleteLibrariant(librariantId);
                return !isRemoved;
            }
            catch (ArgumentException exception)
            {
                Console.WriteLine(exception.Message);
            }
            return isRemoved;
        }
    }
}
