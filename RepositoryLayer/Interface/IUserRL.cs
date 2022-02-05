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
        public bool Login(UserLogin userLogin);
        //void ResetPassword(string Email, string Password, string cpassword);

        // public bool ForgetPassword(string Email);
    }

}