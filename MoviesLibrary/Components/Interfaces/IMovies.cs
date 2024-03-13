using MoviesLibrary.Components.Models;
namespace MoviesLibrary.Components.Interfaces
{
    public interface IMovies
    {
        public List<MoviesModel> GetListofMovies();
        public MoviesModel GetMovie(string id);
        public Task<string> AddOrEdit(MoviesModel movies);
        public string Delete(string id);
    }
}
