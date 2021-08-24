using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Team_2_OnlineCourierManagement.Entities;
using Team_2_OnlineCourierManagement.Models;

namespace Team_2_OnlineCourierManagement.Repositories
{
    public interface IUserRepository
    {
        Feedback AddConsignee(Consignee consignee,Role role);
        Feedback DeleteConsignee(int consigneeid);
        Feedback UpdateConsignee(Consignee consignee,int consigneeid);
        Feedback AddConsigner(Consigner consigner,Role role);
        Feedback DeleteConsigner(int consignerid);
        Feedback UpdateConsigner(Consigner consigner,int consignerid);
        Feedback AddConsignment(Consignment consignment);
        Feedback DeleteConsignment(int consignmentid);
        Feedback UpdateConsignment(Consignment consignment,int consignmentid);
        Consignment ViewConsignment(int consignmentid);
        Consignee ViewConsignee(int consigneeid);
        Consigner ViewConsigner(int consignerid);
        Feedback GenerateBill(Bill bill,int consignmentid);
        Bill ViewBillByBillNo(int billNo);

        User ValidateUser(Login login);
    }
}
