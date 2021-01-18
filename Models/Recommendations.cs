using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Recommendations
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Message { get; set; }
        public string StoreId { get; set; }
        public string ProductId { get; set; }
        public int Rate { get; set; }
        public string Image { get; set; }
        public string Email { get; set; } 
       

        public Recommendations(string firstName, string lastName, string message, string storeId, string productId, int rate, string image, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            Message = message;
            StoreId = storeId;
            ProductId = productId;
          
            Rate = rate;
            Image = image;
            Email = email;
        }

        public Recommendations()
        {

        }
    }
}