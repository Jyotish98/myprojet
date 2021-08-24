using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Team_2_OnlineCourierManagement.Entities
{
    [Table("Bills")] //Bills Table
    public class Bill
    {
        [Key]
        public int BillNo { get; set; } //Primary Key

        public int? ConsignmentId { get; set; }  //Foreign Key Reference

        [Required(ErrorMessage = "Please Enter Consignment type")]
        public string ConsignmentType { get; set; } //Type of Consignment

        [Required(ErrorMessage = "Please Enter Date of Booking")]
        public DateTime BillDate { get; set; } //Date on Bill is generated

        public string ConsigneeName { get; set; } //Consignee's Name

        [Required(ErrorMessage = "Please Enter your Contanct Number")]
        [Phone(ErrorMessage = "Contanct no format not Correct")]
        public string ConsigneeContanctNo { get; set; } //Consignee's Contanct number

        [Required(ErrorMessage = "Please Enter your address")]
        public string ConsigneeAddress { get; set; } //Consignee's Address

        public string ConsignerName { get; set; }  //Consigner's Name

        [Required(ErrorMessage = "Please Enter your Contanct Number")]
        [Phone(ErrorMessage = "Contanct no format not Correct")]
        public string ConsignerContanctNo { get; set; } //Consigner's Contanct number

        [Required(ErrorMessage = "Please Enter your address")]
        public string ConsignerAddress { get; set; } //Consignee's Address

        public double ConsignmentCharges { get; set; } //Consignment Charges

        [ForeignKey("ConsignmentId")] //Foreign Key
        public Consignment consignment { get; set; } 
    }
}
