using CommonLayer.User;
using RepositoryLayer.Interface;
//using RepositoryLayer.Interface;
using RepositoryLayer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RepositoryLayer.Class
{

    public class UserRL : IUserRL
    {
        FundooDBContext dbContext;
        public UserRL(FundooDBContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public void RegisterUser(UserPostModel userPostModel)
        {
            try
            {
                User user = new User();
                user.userId = new User().userId;
                user.Firstname = userPostModel.Firstname;
                user.Lastname = userPostModel.Lastname;
                user.PhoneNumber = userPostModel.PhoneNumber;
                user.address = userPostModel.address;
                user.Email = userPostModel.Email;
                user.password = userPostModel.password;
                user.cpassword = userPostModel.cpassword;
                user.registeredDate = DateTime.Now;
                dbContext.Users.Add(user);
                dbContext.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        public bool Login(UserLogin userLogin)
        {
            try
            {
                User user = new User();
                var result = dbContext.Users.Where(x => x.Email == userLogin.Email && x.password == userLogin.Password).FirstOrDefault();
                if (result != null)
                    return true;
                else

                    return false;

            }
            catch (Exception e)
            {

                throw e;
            }

        }
        public void ResetPassword(string Email, string Password, string cpassword)
        {
            try
            {
                User user = new User();
                var result = dbContext.Users.FirstOrDefault(x => x.Email == Email);
                if (result != null)
                {
                    result.password = Password;
                    result.cpassword = cpassword;
                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void ForgetPassword(string Email)
        {
            try
            {
                User user = new User();
                var result = dbContext.Users.Where(x => x.Email == Email).FirstOrDefault();
            }
            catch (Exception e)
            {
                throw e;
            }

        }
    }
}




