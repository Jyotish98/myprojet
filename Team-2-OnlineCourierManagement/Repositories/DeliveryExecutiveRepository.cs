using Team_2_OnlineCourierManagement.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Team_2_OnlineCourierManagement.Models;

namespace Team_2_OnlineCourierManagement.Repositories
{
    public class DeliveryExecutiveRepository : IDeliveryExecutiveRepository
    {
        private CourierManagementContext context = null;

        //Constructor
        public DeliveryExecutiveRepository(CourierManagementContext context)
        {
            this.context = context;
        }

        //Set Consignment Status
        public Feedback SetConsignmentStatus(int consignmentid,ConsignmentStatus status)
        {
            try
            {
                //Check if ConsignmentId Exists
                Consignment consignment = context.Consignments.SingleOrDefault(s => s.ConsignmentId == consignmentid);
                if (consignment != null)
                {
                    //Assigned and saved Consignment Status
                    consignment.ConsignmentStatus = status.ToString();
                    context.SaveChanges();
                    var fb = new Feedback() { Result = true, Message = "Consignment status updated" };
                    return fb;
                }
                else
                {
                    var fb = new Feedback() { Result = false, Message = "Consignment ID doesn't Exists" };
                    return fb;
                }
            }
            catch (Exception ex)
            {
                var fb = new Feedback() { Result = false, Message = ex.Message };
                return fb;
            }
        }

        //Validating Delivery Executive login credentials
        public DeliveryExecutive ValidateDeliveyExecutive(Login login)
        {
            return context.DeliveryExecutives.SingleOrDefault(u => u.Email == login.EmailID && u.Password == login.Password);
        }

        //View Assigned Consignments
        public List<Consignment> ViewAssignedConsignment(int exid)
        {
            //Matching Delivery Executive 
            return context.Consignments.Where(s => s.DeliveryExecitiveId == exid).ToList();
        }

        //View Assigned Consignments By ID
        public Consignment ViewConsignmentById(int consignmentid, int exid)
        {
            //Matching Consignment ID and Delivery Execuive Id
            return context.Consignments.SingleOrDefault(s => s.DeliveryExecitiveId == exid && s.ConsignmentId==consignmentid);
        }
    }
}
