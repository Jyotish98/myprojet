using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Team_2_OnlineCourierManagement.Entities
{
    [Table("Consignments")] //Consignments Table
    public class Consignment
    {
        [Key]
        public int ConsignmentId { get; set; }    //Primary Key

        [Required(ErrorMessage = "Please Enter Consignment type")]
        public string ConsignmentType { get; set; } //Type of Consignment

        [Required(ErrorMessage = "Please Enter Date of Booking")]
        public DateTime DateOfBooking { get; set; }  //Date on which the consignment is booked

        [Required(ErrorMessage = "Please Enter Expected delivery date")]
        public DateTime ExpectedDeliveryDate { get; set; } //Expected Date for delivery
        [Column(TypeName ="Money")]
        public double ConsignmentCharges { get; set; } //Consignment Charges
        public string ConsignmentStatus { get; set; } //Consignment status

        [Required(ErrorMessage = "Please Enter ConsigneeID")]
        public int? ConsigneeId { get; set; }  //Consignee's ID

        [Required(ErrorMessage = "Please Enter ConsignerID")]
        public int? ConsignerId { get; set; } //Consigner's ID

        public int? DeliveryExecitiveId { get; set; } //DeliveryExecitive's ID

        [ForeignKey("ConsigneeId")] //Foreign key Consignee ID
        public Consignee consignee { get; set; }

        [ForeignKey("ConsignerId")] //Foreign key Consigner ID
        public Consigner consigner { get; set; }

        [ForeignKey("DeliveryExecitiveId")] //Foreign key DeliveryExecitiveId ID
        public DeliveryExecutive deliveryExecitive { get; set; }
    }
}
