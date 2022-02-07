using BusinessLayer.Interface;
using CommonLayer;
using CommonLayer.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RepositoryLayer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace FundooNotes.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        IUserBL userBL;
        FundooDBContext fundooDbContext;
        public UserController(IUserBL userBL, FundooDBContext fundooDB)
        {
            this.userBL = userBL;
            this.fundooDbContext = fundooDB;
        }
        [HttpPost("UserRegistration")]
        public ActionResult RegisterUser(UserPostModel userPostModel)
        {
            try
            {
                this.userBL.RegisterUser(userPostModel);
                return this.Ok(new { success = true, message = $"Registration Successfull  {userPostModel.Email} " });
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        //[HttpPost("login")]
        //public ActionResult Login(UserLogin login)
        //{
        //    try
        //    {
        //        this.userBL.Login(login);
        //        return this.Ok(new { success = true, message = $"Login Successful {login.Email}" });
        //    }
        //    catch (Exception e)
        //    {
        //        throw e;
        //    }
        //}
        //[HttpPost("UserLogin")]
        //public ActionResult Login(UserLogin userLogin)
        //{
        //    try
        //    {
        //        string result = this.userBL.Login(userLogin);
        //        return this.Ok(new { success = true, message = $"LogIn Successful {userLogin.Email}, Token = {result}" });
        //    }
        //    catch (Exception e)
        //    {
        //        throw e;
        //    }
        //}
        [HttpPost("login")]
        public ActionResult Login(UserLogin userLogin)
        {
            try
            {
                string result = this.userBL.Login(userLogin);
                if (result != null)
                    return this.Ok(new { success = true, message = $"LogIn Successful {userLogin.Email}, Token = {result}" });
                else
                    return this.BadRequest(new { Success = false, message = "Invalid Username and Password" });
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [Authorize]
        [HttpPut("Reset Password")]
        public ActionResult ResetPassword(string Email, string Password, string cpassword)
        {
            try
            {
                
                var UserEmailObject = User.Claims.First(x => x.Type == "Email").Value;
                if (Password != cpassword)
                {
                    return this.BadRequest(new { success = false, message = $"Password are not same" });
                }

                this.userBL.ResetPassword(UserEmailObject, Password, cpassword);
                return this.Ok(new { success = true, message = $"Password changed Successfully {Email}" });
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [HttpPut("forgetpassword")]
        public ActionResult ForgetPassword(string Email)
        {

            try
            {
                this.userBL.ForgetPassword(Email);

                return this.Ok(new { success = true, message = $"The link has been sent to {Email}, please check your email to reset your password..." });
            }
            catch (Exception e)
            {
                throw e;
            }

        }
        
    }
}

    