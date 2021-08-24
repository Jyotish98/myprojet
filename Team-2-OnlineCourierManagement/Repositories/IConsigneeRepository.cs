using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Team_2_OnlineCourierManagement.Entities;
using Team_2_OnlineCourierManagement.Models;

namespace Team_2_OnlineCourierManagement.Repositories
{
    public interface IConsigneeRepository
    {
        public List<Consignment> ViewConsignments(int consigneeid);

        public Consignment ViewConsignmentByID(int consignmentid, int consigneeid);

        Consignee ValidateConsignee(Login login);
    }
}
