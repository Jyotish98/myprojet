using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;

namespace Team_2_OnlineCourierManagement.Entities
{
    //Base class for all types of User
    public class Person
    { 
        public string PersonRole { get; set; }   //Role of the person

        [Required(ErrorMessage = "Please Enter your name")]
        public string Name { get; set; }   //Name of the person

        [Required(ErrorMessage ="Please Enter an Email address")]
        [EmailAddress(ErrorMessage ="Enter a valid Email Address")]
        public string Email { get; set; }   //EmailId of the person Used for LogIn purpose

        [Required(ErrorMessage = "Please create a password")]
        public string Password { get; set; } //Password of the person Used for LogIn purpose

        [Required(ErrorMessage = "Please Enter your Contanct Number")]
        [Phone(ErrorMessage = "Contanct no format not Correct")]
        public string ContanctNo { get; set; } //Contanct number of the person

        [Required(ErrorMessage = "Please Enter your address")]
        public string Address { get; set; }  //Address of the person
    }
}
