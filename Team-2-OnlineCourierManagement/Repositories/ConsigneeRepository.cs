using Team_2_OnlineCourierManagement.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Team_2_OnlineCourierManagement.Models;

namespace Team_2_OnlineCourierManagement.Repositories
{
    public class ConsigneeRepository : IConsigneeRepository
    {
        private CourierManagementContext context = null;
        //Constructor
        public ConsigneeRepository(CourierManagementContext context)
        {
            this.context = context;
        }

        //Validating Consignee login credentials
        public Consignee ValidateConsignee(Login login)
        {
            return context.Consignees.SingleOrDefault(u => u.Email == login.EmailID && u.Password == login.Password);
        }

        //View Consignment By ID
        public Consignment ViewConsignmentByID(int consignmentid, int consigneeid)
        {
            return context.Consignments.SingleOrDefault(i => i.ConsignmentId == consignmentid &&i.ConsigneeId==consigneeid);
        }

        //View Consignment History
        public List<Consignment> ViewConsignments(int consigneeid)
        {
            return context.Consignments.Where(i => i.ConsigneeId == consigneeid).ToList();
        }
    }
}
