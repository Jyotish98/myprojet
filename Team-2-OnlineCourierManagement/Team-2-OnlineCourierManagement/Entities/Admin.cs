using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Team_2_OnlineCourierManagement.Entities
{
    [Table("Admins")]// Admin Table
    public class Admin:Person
    {
        [Key]
        public int AdminId { get; set; } //Primary key
    }
}
