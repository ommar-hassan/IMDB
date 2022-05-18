using IMDB.Models;
using IMDB.ViewModels;

namespace IMDB.Classes
{
    public interface IAdmin
    {
        void SearchData(string SearchValue, Search SearchResult, string[] SearchSplit);

        void Splitter(string SearchValue, Search SearchResult);
    }
}