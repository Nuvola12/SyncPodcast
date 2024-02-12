using System;
using System.Security.Cryptography;
using System.Text;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;

namespace HonorsBackend.DataAccess
{
    public class EncryptionHelper 
    {
        private static readonly string EncryptionKey = "ijNMM80@%%Nz9HO*s@Fc$Vkk";

        public static string EncryptString(string input)
        {
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Encoding.UTF8.GetBytes(EncryptionKey);
                aesAlg.IV = new byte[16]; 
                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                byte[] inputBytes = Encoding.UTF8.GetBytes(input);
                byte[] encryptedBytes = encryptor.TransformFinalBlock(inputBytes, 0, inputBytes.Length);

                string encryptedString = Convert.ToBase64String(encryptedBytes);
                return encryptedString;
            }
        }

        public static string DecryptString(string input)
        {
            if(input == null) { return string.Empty; }

            try
            {
                using (Aes aesAlg = Aes.Create())
                {
                    aesAlg.Key = Encoding.UTF8.GetBytes(EncryptionKey);
                    aesAlg.IV = new byte[16]; 

                    ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                    byte[] inputBytes = Convert.FromBase64String(input);
                    byte[] decryptedBytes = decryptor.TransformFinalBlock(inputBytes, 0, inputBytes.Length);

                    string decryptedString = Encoding.UTF8.GetString(decryptedBytes);
                    return decryptedString;
                }
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Invalid input string format: " + ex.Message);
                return string.Empty;
            }
        }
    }


    public class DataModel
    {
        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement("APIKey")]
        public string APIKey { get; set; }

        [BsonElement("json")]
        public string JSON { get; set; }
    }

    public class DataInput 
    {
        public string APIKey { get; set; }
        public string LibraryData { get; set; }
        
    }

    public class DataDB
    {
        private static DataDB _instance;
        private readonly IMongoDatabase _database;

        private DataDB(string connectionString, string databaseName)
        {
            var client = new MongoClient(connectionString);
            _database = client.GetDatabase(databaseName);
        }

        public static DataDB GetInstance()
        {
            if (_instance == null)
            {
                _instance = new DataDB("mongodb://localhost:2717/", "user");
            }

            return _instance;
        }

        public IMongoCollection<DataModel> GetDataCollection()
        {
            return _database.GetCollection<DataModel>("data");
        }

        public IEnumerable<DataModel> GetAllData()
        {
            var collection = GetDataCollection();
            
            var result =   collection.Find(_ => true).ToEnumerable();
            return result;
        }

        public void AddData(string uuid, string json)
        {
            var collection = GetDataCollection();
            var existingData = GetDataByUUID(uuid);

            var encryptedData = EncryptionHelper.EncryptString(json);

            if (existingData != null)
            {
                var filter = Builders<DataModel>.Filter.Eq(x => x.APIKey, uuid);
                var update = Builders<DataModel>.Update.Set(x => x.JSON, json);
                collection.UpdateOne(filter, update);
            }
            else
            {
                var data = new DataModel { APIKey = uuid, JSON = json };
                collection.InsertOne(data);
            }
        }

        public string GetDataByUUID(string uuid)
        {
            var collection = GetDataCollection();
            var datamodel = collection.Find(x => x.APIKey == uuid).FirstOrDefault();
            var result = EncryptionHelper.DecryptString(datamodel?.JSON);
            return datamodel?.JSON;
        }
    }

}
