using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Team_2_OnlineCourierManagement.Entities;
using Team_2_OnlineCourierManagement.Models;

namespace Team_2_OnlineCourierManagement.Repositories
{
    public class ConsignerRepository : IConsignerRepository
    {
        private CourierManagementContext context = null;
        //Constructor
        public ConsignerRepository(CourierManagementContext context)
        {
            this.context = context;
        }

        //View Consignment History
        public List<Consignment> ViewConsignments(int consignerid)
        {
            //Matching Consigner 
            return context.Consignments.Where(s => s.ConsignerId == consignerid).ToList();
        }

        //View Consignment By ID
        public Consignment ViewConsignmentByID(int consignmentid, int consignerid)
        {
            //Matching ConsignmentID and ConsignerId
            return context.Consignments.SingleOrDefault(s => s.ConsignerId == consignerid && s.ConsignmentId == consignmentid);
        }

        //Validating Consigner login credentials
        public Consigner ValidateConsigner(Login login)
        {
            return context.Consigners.SingleOrDefault(u => u.Email == login.EmailID && u.Password == login.Password);
        }
    }
}
