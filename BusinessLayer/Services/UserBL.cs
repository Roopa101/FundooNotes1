using BusinessLayer.Interface;
using CommonLayer.User;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Class
{
    public class UserBL : IUserBL
    {
        IUserRL userRL;
        public UserBL(IUserRL userRL)
        {
            this.userRL = userRL;
        }
        public void RegisterUser(UserPostModel userPostModel)
        {
            try
            {
                userRL.RegisterUser(userPostModel);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public bool Login(UserLogin userlogin)
        {
            try
            {
                return userRL.Login(userlogin);
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        //public void ResetPassword(string Email, string Password, string cpassword)
        //{
        //    try
        //    {
        //        userRL.ResetPassword(Email, Password, cpassword);
        //    }
        //    catch (Exception e)
        //    {
        //        throw e;
        //    }
        //}
    }
}
    