using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Team_2_OnlineCourierManagement.Entities
{
    [Table("DeliveryExecutives")] //DeliveryExecutives Table
    public class DeliveryExecutive:Person
    {
        [Key]
        public int DeliveryExecitiveId { get; set; } //Primary Key
    }
}
