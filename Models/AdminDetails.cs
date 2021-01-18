using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;
namespace WebApplication1.Models
{
    public class AdminDetails
    {
        [BsonId]
        public string Id { get; set; }

        [BsonElement("FirstName")]
        public string FirstName { get; set; }

        [BsonElement("LastName")]
        public string LastName { get; set; }

        [BsonElement("UserName")]
        public string UserName { get; set; }

        [BsonElement("Password")]
        public string Password { get; set; }

        


        public AdminDetails(string id, string firstName, string lastName, string password, string userName)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Password = password;
            UserName = userName;
        }

        public AdminDetails()
        {
        }
    }
}