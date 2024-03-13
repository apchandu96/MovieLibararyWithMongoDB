using MoviesLibrary.Components.Interfaces;
using MoviesLibrary.Components.Models;
using MongoDB.Driver;

namespace MoviesLibrary.Components.Repository
{
    public class MoviesRepo : IMovies
    {
        private MongoClient _mongoClient = null;
        private IMongoDatabase _database = null;
        private IMongoCollection<MoviesModel> _moviesCollection = null;
        public MoviesRepo()
        {
            _mongoClient = new MongoClient("mongodb://localhost:27017");
            _database = _mongoClient.GetDatabase("MoviesDB");
            _moviesCollection = _database.GetCollection<MoviesModel>("Movies");
        }

        public async Task<string> AddOrEdit(MoviesModel movie)
        {
            try
            {


                var filter = Builders<MoviesModel>.Filter.Eq(m => m.Id, movie.Id);
                var update = Builders<MoviesModel>.Update
                    .Set(m => m.Name, movie.Name)
                    .Set(m => m.Description, movie.Description)
                    .Set(m => m.Year, movie.Year)
                    .Set(m => m.Rating, movie.Rating)
                    .Set(m => m.Comments, movie.Comments)
                    .Set(m => m.Budget, movie.Budget);

                var options = new UpdateOptions { IsUpsert = true };

                _moviesCollection.UpdateOne(filter, update, options);
                return "The values is successfully Added";
            }
            catch (Exception ex)
            {
                return "Error while saving data";
            }
        }

        public List<MoviesModel> GetListofMovies()
        {
            return _moviesCollection.Find(FilterDefinition<MoviesModel>.Empty).ToList();
        }

        public MoviesModel GetMovie(string id)
        {
            return _moviesCollection.Find(x => x.Id == id).FirstOrDefault();
        }

        public string Delete(string id)
        {
            _moviesCollection.DeleteOne(x => x.Id == id);
            return "Deleted";
        }
    }
}
