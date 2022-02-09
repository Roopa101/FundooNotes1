using BusinessLayer.Interface;
using CommonLayer;
using CommonLayer.User;
using IdentityModel;
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

        [AllowAnonymous]
        [HttpPut("Reset Password")]
        public ActionResult ResetPassword(string Password, string cpassword)
        {
            try
            {
                if (Password != cpassword)
                {
                    return BadRequest(new { success = false, message = $"Paswords are not same" });
                }
                var identity = User.Identity as ClaimsIdentity;
                if (identity != null)
                {
                    IEnumerable<Claim> claims = identity.Claims;
                    var UserEmailObject = claims.Where(p => p.Type == @"http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress").FirstOrDefault()?.Value;
                    if (UserEmailObject != null)
                    {
                        this.userBL.ResetPassword(UserEmailObject, Password, cpassword);
                        return Ok(new { success = true, message = "Password Changed Sucessfully" });
                    }
                    else
                    {
                        return this.BadRequest(new { success = false, message = $"Password not changed Successfully" });
                    }
                }
                return this.BadRequest(new { success = false, message = $"Password not changed Successfully" });
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

                var result = fundooDbContext.Users.FirstOrDefault(x => x.Email == Email);
                if (result == null)
                {
                    return this.BadRequest(new { success = false, message = "Email is invalid" });
                }
                else
                {
                    this.userBL.ForgetPassword(Email);
                    return this.Ok(new { success = true, message = "Token sent succesfully to email for password reset" });
                }
            }
            catch (Exception e)
            {
                throw e;
            }

        }
        [HttpGet("getallusers")]
        public ActionResult GetAllUsers()
        {
            try
            {
                var result = this.userBL.GetAllUsers();
                return this.Ok(new { success = true, message = $"Below are the User data", data = result });
            }
            catch (Exception e)
            {
                throw e;
            }

        }
    }
}

    