using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Team_2_OnlineCourierManagement.Entities;
using Team_2_OnlineCourierManagement.Models;

namespace Team_2_OnlineCourierManagement.Repositories
{
    public interface IDeliveryExecutiveRepository
    {
        Consignment ViewConsignmentById(int consignmentid,int exid);
        Feedback SetConsignmentStatus(int consignmentid,ConsignmentStatus status);
        List<Consignment> ViewAssignedConsignment(int exid);

        DeliveryExecutive ValidateDeliveyExecutive(Login login);
    }
}
