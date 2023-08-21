using KronoWeaveAPI.Models;
using KronoWeaveAPI.Repository;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KronoWeaveAPI.Controllers
{
    [EnableCors("KronoWeave")]
    [ApiController]
    public class UserController : ControllerBase
    {
        UserRepository UserRepository = new UserRepository();

        [EnableCors("KronoWeave")]
        [HttpGet]
        [Route("api/GetUserName")]
        public User GetUserName(string Email)
        {
            User user = new User();

            user = UserRepository.GetUserName(Email);

            return user;
        }

        [EnableCors("KronoWeave")]
        [HttpGet]
        [Route("api/GetLicenseType")]
        public License GetLicenseType(string Email)
        {
            License license = new License();

            string LicenseType = string.Empty;
            
            int UserID = UserRepository.GetUserID(Email);

            license = UserRepository.GetLicenseType(UserID);

            return license;
        }

    }
}
