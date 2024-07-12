using BookRenting.Services;

namespace BookRenting
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IHomeService homeService = new HomeService();

            homeService.LoadExistedMenus();

        }
    }
}
