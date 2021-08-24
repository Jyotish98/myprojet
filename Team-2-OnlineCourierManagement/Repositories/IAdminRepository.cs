using Team_2_OnlineCourierManagement.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Team_2_OnlineCourierManagement.Models;

namespace Team_2_OnlineCourierManagement.Repositories
{
    public interface IAdminRepository
    {
        Feedback AddAdmin(Admin admin, Role role); //Adding Admin
        Feedback AddUser(User user,Role role); //Adding User
        Feedback AddDeliveryExecutive(DeliveryExecutive deliveryExecutive, Role role); //Adding Delivery Executive
        Feedback DeleteUser(int userid);
        Feedback UpdateUser(User user,int userid);
        Feedback DeleteDeliveryExecutive(int exid);
        Feedback UpdateDeliveryExecutive(DeliveryExecutive deliveryExecutive,int deliveryExecutiveid);
        Feedback AssignConsignmentToDeliveryExecutive(int deliveryExecutiveId, int consignmentid);
        Feedback AddConsignmentCharges(int consignmentId,double charges);
        Feedback UpdateConsignmentCharges(int consignmentId, double charges);
        Consignment ViewConsignment(int consignmentId);
        List<Consignment> ViewConsignmentsByDate(DateTime date);
        List<Consignment> ViewConsignmentsBetweenSelectedDays(DateTime StartingDate, DateTime EndDate);
        User ViewUserById(int userId); 
        DeliveryExecutive ViewDeliveryExecutive(int deliveryExecutiveId);
        Consignee ViewConsignee(int consigneeId);
        Consigner ViewConsigner(int consignerId);
        string ViewConsignmentStatus(int consignmentId);
        Admin ValidateAdmin(Login login);
    }
}
