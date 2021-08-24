using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Team_2_OnlineCourierManagement.Entities
{
    [Table("Consigners")] //Consigners Table
    public class Consigner:Person
    {
        [Key]
        public int ConsignerId { get; set; }  //Primary Key
    }
}
