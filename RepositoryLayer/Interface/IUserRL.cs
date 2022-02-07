using CommonLayer;
using CommonLayer.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interface
{
    public interface IUserRL
    {
        void RegisterUser(UserPostModel userPostModel);
        // public bool Login(UserLogin userLogin);
        string Login(UserLogin userLogin);
        //public string GenerateJwtToken(string Email);
        void ResetPassword(string Email, string Password, string cpassword);
        public void ForgetPassword(string Email);
        List<User> GetAllUsers();


    }

}