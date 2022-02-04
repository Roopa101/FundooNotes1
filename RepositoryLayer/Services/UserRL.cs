using CommonLayer.User;
using RepositoryLayer.Interface;
using RepositoryLayer.Services;
using System;
using System.Collections.Generic;
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
    }
}
