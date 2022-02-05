using BusinessLayer.Interface;
using CommonLayer;
using CommonLayer.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RepositoryLayer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
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
        [HttpPost]
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
        [HttpPost("login")]
        public ActionResult Login(UserLogin login)
        {
            try
            {
                this.userBL.Login(login);
                return this.Ok(new { success = true, message = $"Login Successful {login.Email}" });
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        [Authorize]
        [HttpPut("resetpassword")]
        public ActionResult ResetPassword(string Email, string Password, string cpassword)
        {
            try
            {
                if (Password != cpassword)
                {
                    return BadRequest(new { success = false, message = $"Paswords are not equal" });
                }
                // var identity = User.Identity as ClaimsIdentity 
                this.userBL.ResetPassword(Email, Password, cpassword);
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

                return Ok(new { message = "Token sent succesfully.Please check your email for password reset" });
            }
            catch (Exception)
            {
                throw;
            }

        }

    }
}

    