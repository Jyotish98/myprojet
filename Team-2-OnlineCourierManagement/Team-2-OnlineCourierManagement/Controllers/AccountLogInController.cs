using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Team_2_OnlineCourierManagement.Repositories;
using Team_2_OnlineCourierManagement.Entities;
using Team_2_OnlineCourierManagement.Models;
using Microsoft.Extensions.Configuration;
using System.IO;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Team_2_OnlineCourierManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController] 
    public class AccountLogInController : ControllerBase
    {
        private IAdminRepository adminRepository = null;   
        private IUserRepository userRepository=null;
        private IConsigneeRepository consigneeRepository=null;
        private IConsignerRepository consignerRepository=null;
        private IDeliveryExecutiveRepository deliveryExecutiveRepository=null;
        //Constructor
        public AccountLogInController(IUserRepository userRepository, IConsigneeRepository consigneeRepository,
            IConsignerRepository consignerRepository, IDeliveryExecutiveRepository deliveryExecutiveRepository, IAdminRepository adminRepository)
        {
            this.adminRepository = adminRepository;
            this.userRepository = userRepository;
            this.consigneeRepository = consigneeRepository;
            this.consignerRepository = consignerRepository;
            this.deliveryExecutiveRepository = deliveryExecutiveRepository;
        }

        //Logging in Admin
        [Route("AdminLogin")]
        [HttpPost]
        public IActionResult AdminLogin(Login login)
        {
            LoggedUserModel model = new LoggedUserModel();
            //Validating Login credentials
            Admin admin = adminRepository.ValidateAdmin(login);
            if (admin != null)
            {
                string token = GetToken(admin);
                model = new LoggedUserModel() { EmailID = admin.Email, Token = token, Role = admin.PersonRole };
            }
            else
            {
                return BadRequest("Invalid Credentials");
            }

            return Ok(model);
        }

        //Logging in User
        [Route("UserLogin")]
        [HttpPost]
        public IActionResult UserLogin(Login login)
        {
            LoggedUserModel model = new LoggedUserModel();
            //Validating Login credentials
            User user = userRepository.ValidateUser(login);
            if (user != null)
            {
                string token = GetToken(user);
                model = new LoggedUserModel() { EmailID = user.Email, Token = token, Role = user.PersonRole };
            }
            else {
                return BadRequest("Invalid Credentials");
            }
         
            return Ok(model);
        }

        //Logging in DeliveryExecutive
        [Route("DeliveryExecutiveLogin")]
        [HttpPost]
        public IActionResult DeliveryExecutiveLogin(Login login)
        {
            LoggedUserModel model = new LoggedUserModel();
            //Validating Login credentials
            DeliveryExecutive deliveryExecutive = deliveryExecutiveRepository.ValidateDeliveyExecutive(login);
            if (deliveryExecutive != null)
            {
                string token = GetToken(deliveryExecutive);
                model = new LoggedUserModel() { EmailID = deliveryExecutive.Email, Token = token, Role = deliveryExecutive.PersonRole };
            }

            return Ok(model);
        }

        //Logging in Consignee
        [Route("ConsigneeLogin")]
        [HttpPost]
        public IActionResult ConsigneeLogin(Login login)
        {
            LoggedUserModel model = new LoggedUserModel();
            //Validating Login credentials
            Consignee consignee = consigneeRepository.ValidateConsignee(login);
            if (consignee != null)
            {
                string token = GetToken(consignee);
                model = new LoggedUserModel() { EmailID = consignee.Email, Token = token, Role = consignee.PersonRole };
            }

            return Ok(model);
        }

        //Logging in Consigner
        [Route("ConsignerLogin")]
        [HttpPost]
        public IActionResult ConsignerLogin(Login login)
        {
            LoggedUserModel model = new LoggedUserModel();
            //Validating Login credentials
            Consigner consigner = consignerRepository.ValidateConsigner(login);
            if (consigner != null)
            {
                string token = GetToken(consigner);
                model = new LoggedUserModel() { EmailID = consigner.Email, Token = token, Role = consigner.PersonRole };
            }

            return Ok(model);
        }

        private string GetToken(Person person)
        {
            var _config = new ConfigurationBuilder()
                              .SetBasePath(Directory.GetCurrentDirectory())
                              .AddJsonFile("appsettings.json").Build();
            var issuer = _config["Jwt:Issuer"];
            var audience = _config["Jwt:Audience"];
            var expiry = DateTime.Now.AddMinutes(2);
            var securityKey = new SymmetricSecurityKey
        (Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials
        (securityKey, SecurityAlgorithms.HmacSha256);

            //    var token = new JwtSecurityToken(issuer: issuer,
            //audience: audience,

            //expires: DateTime.Now.AddMinutes(120),
            //signingCredentials: credentials);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                   {

                    new Claim(ClaimTypes.Name, person.Email.ToString()),
                    new Claim(ClaimTypes.Role, person.PersonRole)
                   }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var stringToken = tokenHandler.WriteToken(token);
            return stringToken;
        }
    }
}
