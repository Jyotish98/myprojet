using Team_2_OnlineCourierManagement.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Team_2_OnlineCourierManagement.Models;

namespace Team_2_OnlineCourierManagement.Repositories
{
    public class AdminRepository : IAdminRepository
    {
        private CourierManagementContext context = null;
        //Constructor
        public AdminRepository(CourierManagementContext context)
        {
            this.context = context;
        }

        //Adding Consignment Charges to Consignment
        public Feedback AddConsignmentCharges(int consignmentid,double charges)
        {
            try
            {
                //Check if ConsignmentId Exists
                Consignment consignment = context.Consignments.SingleOrDefault(s => s.ConsignmentId == consignmentid);
                if (consignment != null && consignment.ConsignmentCharges==0)
                {
                    //Assigned and saved the ConsignmentCharges
                    consignment.ConsignmentCharges = charges;
                    context.SaveChanges();
                    var fb = new Feedback() { Result = true, Message = "Consignment charges Added" };
                    return fb;
                }
                else {
                    var fb = new Feedback() { Result = false,Message="Consignment ID doesn't Exists" };
                    return fb;
                }
            }
            catch (Exception ex)
            {
                var fb = new Feedback() { Result = false, Message = ex.Message };
                return fb;
            }
        }

        public Feedback UpdateConsignmentCharges(int consignmentid, double charges)
        {
            try
            {
                //Check if ConsignmentId Exists
                Consignment consignment = context.Consignments.SingleOrDefault(s => s.ConsignmentId == consignmentid);
                if (consignment != null)
                {
                    //Assigned and updated the ConsignmentCharges
                    consignment.ConsignmentCharges = charges;
                    context.SaveChanges();
                    var fb = new Feedback() { Result = true, Message = "Consignment charges updated" };
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

        //Add Admin
        public Feedback AddAdmin(Admin admin, Role role)
        {
            try
            {
                //Check if Admin already exists by matching Email
                Admin admin1 = context.Admins.SingleOrDefault(s => s.Email == admin.Email);
                if (admin1 == null)
                {
                    //Add Admin Executive
                    admin.PersonRole = role.ToString();
                    context.Admins.Add(admin);
                    context.SaveChanges();
                    var fb = new Feedback() { Result = true, Message = "Adminstrator Added" };
                    return fb;
                }
                else
                {
                    var fb = new Feedback() { Result = false, Message = "Adminstrator with same Email already exists" };
                    return fb;
                }
            }
            catch (Exception ex)
            {
                var fb = new Feedback() { Result = false, Message = ex.Message };
                return fb;
            }
        }

        //Add Delivery Executive
        public Feedback AddDeliveryExecutive(DeliveryExecutive deliveryExecutive, Role role)
        {
            try
            {
                //Check if Delivery Executive already exists by matching Email
                DeliveryExecutive executive = context.DeliveryExecutives.SingleOrDefault(s => s.Email == deliveryExecutive.Email);
                if (executive == null)
                {
                    //Add Delivery Executive
                    deliveryExecutive.PersonRole = role.ToString();
                    context.DeliveryExecutives.Add(deliveryExecutive);
                    context.SaveChanges();
                    var fb = new Feedback() { Result = true, Message = "Delivery Executive Added" };
                    return fb;
                }
                else
                {
                    var fb = new Feedback() { Result = false, Message = "Delivery Executive with same Email already exists" };
                    return fb;
                }
            }
            catch (Exception ex)
            {
                var fb = new Feedback() { Result = false, Message = ex.Message };
                return fb;
            }
        }

        public Feedback AddUser(User user, Role role)
        {
            Feedback feedback = null;
            try
            {
                //Check if User already exists by matching Email
                User user1 = context.Users.SingleOrDefault(s => s.Email == user.Email);
                if (user1 == null)
                {
                    //Add User
                    user.PersonRole = role.ToString();
                    context.Users.Add(user);
                    context.SaveChanges();
                    feedback = new Feedback() { Result = true, Message = "User Added" };
                }
                else
                {
                   feedback = new Feedback() { Result = false, Message = "User with same Email already exists" };
                   
                }
                
            }
            catch (Exception ex)
            {
               feedback = new Feedback() { Result = false, Message = ex.Message };
                
            }
            return feedback;
        }

        //Assiging Consignment to Delivery Executive
        public Feedback AssignConsignmentToDeliveryExecutive(int deliveryExecutiveId,int consignmentid)
        {
            try
            {
                DeliveryExecutive deliveryExecutive= context.DeliveryExecutives.SingleOrDefault(s => s.DeliveryExecitiveId == deliveryExecutiveId);
                if (deliveryExecutive != null)
                {
                    //Check if Consignment is already assigned to Delivery Executive
                    Consignment consignment1 = context.Consignments.SingleOrDefault(s => s.ConsignmentId == consignmentid);
                    if (consignment1 != null)
                    {
                        if (consignment1.DeliveryExecitiveId == null)
                        {
                            //Assigned and saved Consignment
                            consignment1.DeliveryExecitiveId = deliveryExecutiveId;
                            context.SaveChanges();
                            var fb = new Feedback() { Result = true, Message = "Assigned Delivery Executive" };
                            return fb;
                        }
                        else
                        {
                            var fb = new Feedback() { Result = false, Message = "Consignment Already assigned to Delivery Excecutive" };
                            return fb;
                        }
                    }
                    else
                    {
                        var fb = new Feedback() { Result = false, Message = "Consignment Does not exists" };
                        return fb;
                    }
                }
                else {
                    var fb = new Feedback() { Result = false, Message = "DeliveryExecutive Does not exists" };
                    return fb;
                }
            }
            catch (Exception ex)
            {
                var fb = new Feedback() { Result = false, Message = ex.Message };
                return fb;
            }

        }

        //Delete Delivery Executive
        public Feedback DeleteDeliveryExecutive(int exid)
        {
            try
            {
                //Check if Delivery Executive exists or not
                DeliveryExecutive executive = context.DeliveryExecutives.SingleOrDefault(s => s.DeliveryExecitiveId == exid);
                if (executive != null)
                {
                    //Deleted Delivery Executive
                    context.DeliveryExecutives.Remove(executive);
                    context.SaveChanges();
                    var fb = new Feedback() { Result = true, Message = "Delivery Executive Removed" };
                    return fb;
                }
                else
                {
                    var fb = new Feedback() { Result = false, Message = "Delivery Executive doesn't exists" };
                    return fb;
                }
            }
            catch (Exception ex)
            {
                var fb = new Feedback() { Result = false, Message = ex.Message };
                return fb;
            }
        }

        //Delete User
        public Feedback DeleteUser(int userid)
        {
            try
            {
                //Check if User exists or not
                User user = context.Users.SingleOrDefault(s => s.UserId == userid);
                if (user != null)
                {
                    //Deleted User
                    context.Users.Remove(user);
                    context.SaveChanges();
                    var fb = new Feedback() { Result = true, Message = "User Removed" };
                    return fb;
                }
                else
                {
                    var fb = new Feedback() { Result = false, Message = "User doesn't exists" };
                    return fb;
                }
            }
            catch (Exception ex)
            {
                var fb = new Feedback() { Result = false, Message = ex.Message };
                return fb;
            }
        }

        //Update Delivery Executive
        public Feedback UpdateDeliveryExecutive(DeliveryExecutive deliveryExecutive,int deliveryExecutiveid)
        {
            try
            {
                //Check if Delivery Executive exists or not by Email
                DeliveryExecutive executive = context.DeliveryExecutives.SingleOrDefault(s => s.DeliveryExecitiveId == deliveryExecutiveid);
                if (executive != null)
                {
                    //Updated Delivery Executive
                    executive.Email = deliveryExecutive.Email;
                    executive.Name = deliveryExecutive.Name;
                    executive.ContanctNo = deliveryExecutive.ContanctNo;
                    executive.Address = deliveryExecutive.Address;
                    executive.Password = deliveryExecutive.Password;
                    context.SaveChanges();
                    var fb = new Feedback() { Result = true, Message = "Delivery Executive Updated" };
                    return fb;
                }
                else
                {
                    var fb = new Feedback() { Result = false, Message = "Delivery Executive doesn't exists" };
                    return fb;
                }
            }
            catch (Exception ex)
            {
                var fb = new Feedback() { Result = false, Message = ex.Message };
                return fb;
            }
        }

        //Update User
        public Feedback UpdateUser(User user,int userid)
        {
            try
            {
                //Check if User exists or not
                User user1 = context.Users.SingleOrDefault(s => s.UserId == userid);
                if (user1 != null)
                {
                    //Updated User
                    user1.Email = user.Email;
                    user1.Name = user.Name;
                    user1.ContanctNo = user.ContanctNo;
                    user1.Address = user.Address;
                    user1.Password = user.Password;
                    context.SaveChanges();
                    var fb = new Feedback() { Result = true, Message = "User Updated" };
                    return fb;
                }
                else
                {
                    var fb = new Feedback() { Result = false, Message = "User doesn't exists" };
                    return fb;
                }
            }
            catch (Exception ex)
            {
                var fb = new Feedback() { Result = false, Message = ex.Message };
                return fb;
            }
        }

        //View Consignee using ConsigneeId
        public Consignee ViewConsignee(int consigneeId)
        {
            return context.Consignees.SingleOrDefault(s => s.ConsigneeId == consigneeId);
        }

        //View Consigner using ConsignerId
        public Consigner ViewConsigner(int consignerId)
        {
            return context.Consigners.SingleOrDefault(s => s.ConsignerId == consignerId);
        }

        //View Consignment using ConsignmentId
        public Consignment ViewConsignment(int consignmentId)
        {
            return context.Consignments.SingleOrDefault(s => s.ConsignmentId == consignmentId);
        }

        //View Consignment For a Particular Date
        public List<Consignment> ViewConsignmentsByDate(DateTime date)
        {
            return context.Consignments.Where(s => s.DateOfBooking == date).ToList();
        }

        //View Consignment Between Selected Days
        public List<Consignment> ViewConsignmentsBetweenSelectedDays(DateTime StartingDate, DateTime EndDate)
        {
            return context.Consignments.Where(s => s.DateOfBooking>=StartingDate && s.DateOfBooking<= EndDate).ToList();
        }

        //View Cosignment Status by ConsignmentID
        public string ViewConsignmentStatus(int consignmentId)
        {
            Consignment consignment= context.Consignments.SingleOrDefault(s => s.ConsignmentId == consignmentId);
            return consignment.ConsignmentStatus;
        }

        //View User using UserId
        public User ViewUserById(int userId)
        {
            return context.Users.SingleOrDefault(s => s.UserId == userId);
        }

        //View DeliveryExecutive using DeliveryExecutiveId
        public DeliveryExecutive ViewDeliveryExecutive(int deliveryExecutiveId)
        {
            return context.DeliveryExecutives.SingleOrDefault(s => s.DeliveryExecitiveId ==deliveryExecutiveId );
        }

        //Validating Admin login credentials
        public Admin ValidateAdmin(Login login)
        {
            return context.Admins.SingleOrDefault(u => u.Email == login.EmailID && u.Password == login.Password);
        }
    }
}
