using Films.Models;
using MongoDB.Driver;

namespace Films.Services
{
    public class Film_service
    {
        private static Film_service film_service;
        private readonly IMongoCollection<Film> films;
        private Film_service()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("db_films");
            films = database.GetCollection<Film>("films");
        }
        public static Film_service Get_film_service()
        {
            if (film_service != null) return film_service;
            else film_service = new Film_service();
            return film_service;
        }
        public List<Film> Get()
        {
            return films.Find(f => true).ToList();
        }
        public Film Get(string id)
        {
            return films.Find(f => f.Id == id).FirstOrDefault();
        }
        public void Create(Film film)
        {
            films.InsertOne(film);
        }
        public void Update(Film film)
        {
            films.ReplaceOne(f => f.Id == film.Id, film);
        }
        public void Remove(Film film)
        {
            films.DeleteOne(f => f.Id == film.Id);
        }
    }
}
