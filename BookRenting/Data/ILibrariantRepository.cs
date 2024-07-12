using BookRenting.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRenting.Data
{
    public interface ILibrariantRepository
    {
        IList<User> SelectAllLibrariants();
        User SelectLibrariantById(int LibrariantId);
        User InsertLibrariant(User Librariant);
        User UpdateLibrariant(int LibrariantId, User Librariant);
        bool DeleteLibrariant(int LibrariantId);

    }
}
