using CommonLayer.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interface
{
    public interface IUserBL
    {
        void RegisterUser(UserPostModel userPostModel);
        public bool Login(UserLogin userLogin);
        // public bool ForgetPassword(User Email);
        void ResetPassword(string Email, string Password, string cpassword);

    }
}