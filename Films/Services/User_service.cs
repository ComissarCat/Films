using Films.Models;
using MongoDB.Driver;

namespace Films.Services
{
    public class User_service
    {
        private static User_service user_service;
        private readonly IMongoCollection<User> users;
        public bool Authorized { get; set; }
        public string Role { get; private set; }
        private User_service()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("db_users");
            users = database.GetCollection<User>("users");
            Authorized = false;
        }
        public static User_service Get_user_service()
        {
            if (user_service != null) return user_service;
            else user_service = new User_service();
            return user_service;
        }
        public List<User> Get()
        {
            return users.Find(u => true).ToList();
        }
        public User Get(string id)
        {
            return users.Find(u => u.Id == id).FirstOrDefault();
        }
        public void Create(User user)
        {
            users.InsertOne(user);
        }
        public void Update(User user)
        {
            users.ReplaceOne(u => u.Id == user.Id, user);
        }
        public void Remove(User user)
        {
            users.DeleteOne(u => u.Id == user.Id);
        }
        public void Check_user(User user)
        {
            Role = users.Find(u => u.Name == user.Name & u.Password == user.Password).FirstOrDefault().Role;
        }
    }
}
