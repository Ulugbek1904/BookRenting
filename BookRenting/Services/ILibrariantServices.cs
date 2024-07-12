using BookRenting.Models;

namespace BookRenting.Services
{
    public interface ILibrariantServices
    {
        IList<User> RetrieveLibrariants(string name = null);

        User RetrieveLibrariant(int librariabtId);
        User AddLibrariant(User librariant);
        User ModifyLibrariant(int librariantId, User librariant);
        bool RemoveLibrariant(int librariantId);
    }
}
