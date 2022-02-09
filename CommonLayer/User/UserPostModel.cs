using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CommonLayer.User
{
    public class UserPostModel
    {
        [RegularExpression(@"^[A-Z]{1}[a-z]{2,}$",
        ErrorMessage = "Please enter valid first name")]
        public string Firstname { get; set; }
       
        [RegularExpression(@"^[A-Z]{1}[a-z]{2,}$",
        ErrorMessage = "Please enter valid last name")]
        public string Lastname { get; set; }
        
        [RegularExpression(@"^[6-9]{1}[0-9]{9}$",
        ErrorMessage = "Please enter correct phone number")]
        public string PhoneNumber { get; set; }

        [RegularExpression(@"^[a-zA-Z-0-9]{3,}$",
        ErrorMessage = "Please enter valid address")]
        public string address { get; set; }
        [RegularExpression(@"^[a-z0-9]+(.[a-z0-9]+)?@[a-z]+[.][a-z]{3}$",
        ErrorMessage = "Please enter correct Email address")]
        public string Email { get; set; }
        [RegularExpression("^(?=.*[A-Z]).{8,}$",
        ErrorMessage = "Password Have minimum 8 Characters, Should have at least 1 Upper Case and Should have at least 1 numeric number and Has exactly 1 Special Character")]
        public string password { get; set; }
        [RegularExpression("^(?=.*[A-Z]).{8,}$", 
        ErrorMessage = "Password Have minimum 8 Characters, Should have at least 1 Upper Case and Should have at least 1 numeric number and Has exactly 1 Special Character")]
        public string cpassword { get; set; }
      
    }

}
