using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Team_2_OnlineCourierManagement.Entities
{
    [Table("Consignees")] //Consignees Table
    public class Consignee:Person
    {
        [Key]
        public int ConsigneeId { get; set; }  //Primary Key
    }
}
