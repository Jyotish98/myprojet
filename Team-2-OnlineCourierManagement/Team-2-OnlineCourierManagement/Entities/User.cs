using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Team_2_OnlineCourierManagement.Entities
{
    [Table("Users")] //Users Table
    public class User:Person
    {
        [Key]
        public int UserId { get; set; }  //Primary Key
    }
}
