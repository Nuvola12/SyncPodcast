using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Text.Json.Serialization;
using System.Security.Cryptography;
using System.Text;

namespace HonorsBackend.DataAccess
{
    public class User
    {
        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement("username")]
        public string Username { get; set; }

        [BsonElement("password")]
        public string Password { get; set; }

        [BsonElement("apiKey")]
        public string APIKey { get; set; }

        
    }

    public class UserCredentials
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class UserDB
    {
        private static UserDB _instance;
        private readonly IMongoDatabase _database;

        private UserDB(string connectionString, string databaseName)
        {
            var client = new MongoClient(connectionString);
            _database = client.GetDatabase(databaseName);
        }

        public static UserDB GetInstance()
        {
            if (_instance == null)
            {
                _instance = new UserDB("mongodb://localhost:2717/", "user");
            }

            return _instance;
        }


        private IMongoCollection<User> GetUserCollection()
        {
            return _database.GetCollection<User>("user");
        }

        public IEnumerable<User> GetAllUsers()
        {
            var collection = GetUserCollection();

            List<User> users = collection.Find(_ => true).ToList();

            return users;
        }

        private string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                // Compute hash from the password bytes
                byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
                byte[] hashBytes = sha256.ComputeHash(passwordBytes);

                // Convert the hashed bytes to a hexadecimal string
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    builder.Append(hashBytes[i].ToString("x2"));
                }

                return builder.ToString();
            }
        }

        public void AddUser(User user)
        {
            // Hash the password before storing
            user.Password = HashPassword(user.Password);

            var collection = GetUserCollection();
            collection.InsertOne(user);
        }

        public string GetUUID(string username, string password)
        {
            var collection = GetUserCollection();
            var user = collection.Find(x => x.Username == username).FirstOrDefault();

            if (user != null)
            {
                string hashedPassword = HashPassword(password);

                if (user.Password == hashedPassword)
                {
                    return user.APIKey;
                }
            }

            return null;
        }

        public bool CheckCredentials(string username, string password)
        {
            var collection = GetUserCollection();
            var user = collection.Find(x => x.Username == username).FirstOrDefault();

            if (user != null)
            {
                // Verify the hashed password
                string hashedPassword = HashPassword(password);
                return user.Password == hashedPassword;
            }

            return false;
        }

        /*
        public void AddUser(User user)
        {
            var collection = GetUserCollection();
            collection.InsertOne(user);
        }*/

        public void DeleteByApiKey(string apiKey)
        {
            var collection = GetUserCollection();
            collection.DeleteMany(x => x.APIKey == apiKey);
        }


        public User GetUserByUsername(string username)
        {
            var collection = GetUserCollection();
            return collection.Find(x => x.Username == username).FirstOrDefault();
        }

        /*
        public bool CheckCredentials(string username, string password)
        {
            var collection = GetUserCollection();
            return collection.Find(x => x.Username == username && x.Password == password).Any();
        }


        
        public string GetUUID(string username, string password)
        {
            var collection = GetUserCollection();
            var user = collection.Find(x => x.Username == username && x.Password == password).FirstOrDefault();
            return user?.APIKey;
        }
        */

        public bool CheckApiKey(string apiKey)
        {
            var collection = GetUserCollection();
            return collection.Find(x => x.APIKey == apiKey).Any();
        }
    }
}
