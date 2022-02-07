using CommonLayer.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interface
{
    public interface IUserBL
    {
        void RegisterUser(UserPostModel userPostModel);
       // public bool Login(UserLogin userLogin);
        string Login(UserLogin userLogin);

        void ResetPassword(string Email, string Password, string cpassword);
        public void ForgetPassword(string Email);
       // public string EncryptPassword(string Password);


    }
}