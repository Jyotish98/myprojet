using Team_2_OnlineCourierManagement.Entities;
using Team_2_OnlineCourierManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Team_2_OnlineCourierManagement.Repositories
{
    public class UserRepository : IUserRepository
    {
        private CourierManagementContext context = null;

        //Constructor
        public UserRepository(CourierManagementContext context)
        {
            this.context = context;
        }

        //Add Consignee
        public Feedback AddConsignee(Consignee consignee, Role role)
        {
            try
            {
                //Check if Consignee already exists by matching Email
                Consignee consignee1 = context.Consignees.SingleOrDefault(s => s.Email == consignee.Email);
                if (consignee1 == null)
                {
                    //Add Consignee
                    consignee.PersonRole = role.ToString();
                    context.Consignees.Add(consignee);
                    context.SaveChanges();
                    var fb = new Feedback() { Result = true, Message = "Consignee Added" };
                    return fb;
                }
                else
                {
                    var fb = new Feedback() { Result = false, Message = "Consignee with same Email already exists" };
                    return fb;
                }
            }
            catch (Exception ex)
            {
                var fb = new Feedback() { Result = false, Message = ex.Message };
                return fb;
            }
        }

        //Add Consigner
        public Feedback AddConsigner(Consigner consigner, Role role)
        {
            try
            {
                //Check if Consigner already exists by matching Email
                Consigner consigner1 = context.Consigners.SingleOrDefault(s => s.Email == consigner.Email);
                if (consigner1 == null)
                {
                    //Add Consigner
                    consigner.PersonRole = role.ToString();
                    context.Consigners.Add(consigner);
                    context.SaveChanges();
                    var fb = new Feedback() { Result = true, Message = "Consigner Added" };
                    return fb;
                }
                else
                {
                    var fb = new Feedback() { Result = false, Message = "Consigner with same Email already exists" };
                    return fb;
                }
            }
            catch (Exception ex)
            {
                var fb = new Feedback() { Result = false, Message = ex.Message };
                return fb;
            }
        }

        //Add Consignment
        public Feedback AddConsignment(Consignment consignment)
        {
            try
            {
                // Add consigner
                   context.Consignments.Add(consignment);
                   context.SaveChanges();
                   var fb = new Feedback() { Result = true, Message = "Consignment Added successfully " };
                   return fb;
            }
            catch (Exception ex)
            {
                var fb = new Feedback() { Result = false, Message = ex.Message };
                return fb;
            }
        }

        //Delete Consignee
        public Feedback DeleteConsignee(int consigneeid)
        {
            try
            {
                //Check if Consignee Exists or not
                Consignee consignee = context.Consignees.SingleOrDefault(s => s.ConsigneeId == consigneeid);
                if (consignee != null)
                {
                    //Delete Consignee
                    context.Consignees.Remove(consignee);
                    context.SaveChanges();
                    var fb = new Feedback() { Result = true, Message = "Consignee deleted" };
                    return fb;
                }
                else
                {
                    var fb = new Feedback() { Result = false, Message = "Consignee ID doesn't Exists" };
                    return fb;
                }
            }
            catch (Exception ex)
            {
                var fb = new Feedback() { Result = false, Message = ex.Message };
                return fb;
            }
        }

        //Delete Consigner
        public Feedback DeleteConsigner(int consignerid)
        {
            try
            {
                //Check if Consigner Exists or not
                Consigner consigner = context.Consigners.SingleOrDefault(s => s.ConsignerId == consignerid);
                if (consigner != null)
                {
                    //Delete Consignee
                    context.Consigners.Remove(consigner);
                    context.SaveChanges();
                    var fb = new Feedback() { Result = true, Message = "Consigner deleted" };
                    return fb;
                }
                else
                {
                    var fb = new Feedback() { Result = false, Message = "Consigner ID doesn't Exists" };
                    return fb;
                }
            }
            catch (Exception ex)
            {
                var fb = new Feedback() { Result = false, Message = ex.Message };
                return fb;
            }
        }

        //Delete Consignment
        public Feedback DeleteConsignment(int consignmentid)
        {
            try
            {
                //Check if Consignment Exists or not
                Consignment consignment = context.Consignments.SingleOrDefault(s => s.ConsignmentId == consignmentid);
                if (consignment != null)
                {
                    //Delete Consignment
                    context.Consignments.Remove(consignment);
                    context.SaveChanges();
                    var fb = new Feedback() { Result = true, Message = "Consignment deleted" };
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

        //Generate Bill
        public Feedback GenerateBill(Bill bill,int consignmentid)
        {
            try
            {
                //Generate bill by Validating Id
                Consignment consignment= context.Consignments.SingleOrDefault(s => s.ConsignmentId == consignmentid);
                if (consignment != null)
                {
                    Bill bill1 = context.Bills.SingleOrDefault(s => s.ConsignmentId == consignmentid);
                    if (bill1 == null)
                    {
                        //Bill Generated
                        bill.ConsignmentId = consignmentid;
                        context.Bills.Add(bill);
                        context.SaveChanges();
                        var fb = new Feedback() { Result = true, Message = "Bill Generated" };
                        return fb;
                    }
                    else
                    {

                        var fb = new Feedback() { Result = false, Message = "Bill already Generated for this Consignment" };
                        return fb;
                    }
                }
                else {
                    var fb = new Feedback() { Result = false, Message = "Consignment does not exists" };
                    return fb;
                }
            }
            catch (Exception ex)
            {
                var fb = new Feedback() { Result = false, Message = ex.Message };
                return fb;
            }
        }

        //Update Consignee
        public Feedback UpdateConsignee(Consignee consignee,int consigneeid)
        {
            try
            {
                //Check if ConsigneeId Exists or not
                Consignee consignees = context.Consignees.SingleOrDefault(s => s.ConsigneeId == consigneeid);
                if (consignees != null)
                {
                    consignees.Email=consignee.Email;
                    consignees.Name = consignee.Name;
                    consignees.ContanctNo = consignee.ContanctNo;
                    consignees.Address = consignee.Address;
                    consignees.Password = consignee.Password;
                    context.SaveChanges();
                    var fb = new Feedback() { Result = true, Message = "Consignee Updated" };
                    return fb;
                }
                else
                {

                    var fb = new Feedback() { Result = false, Message = "Consignee not found" };
                    return fb;
                }
            }
            catch (Exception ex)
            {
                var fb = new Feedback() { Result = false, Message = ex.Message };
                return fb;
            }
        }

        //Update Consigner
        public Feedback UpdateConsigner(Consigner consigner,int consignerid)
        {
            try
            {
                //Check if ConsignerId Exists or not
                Consigner consigners = context.Consigners.SingleOrDefault(s => s.ConsignerId == consignerid);
                if (consigners != null)
                {
                    consigners.Email = consigner.Email;
                    consigners.Name = consigner.Name;
                    consigners.ContanctNo = consigner.ContanctNo;
                    consigners.Address = consigner.Address;
                    consigners.Address = consigner.Address;
                    context.SaveChanges();
                    var fb = new Feedback() { Result = true, Message = "Consigner Updated" };
                    return fb;
                }
                else
                {

                    var fb = new Feedback() { Result = false, Message = "Consigner not found" };
                    return fb;
                }
            }
            catch (Exception ex)
            {
                var fb = new Feedback() { Result = false, Message = ex.Message };
                return fb;
            }
        }

        //Update Consignment
        public Feedback UpdateConsignment(Consignment consignment,int consignmentid)
        {
            try {
                //Update Consignment by Validating Id
                Consignment consignment1 = context.Consignments.SingleOrDefault(s => s.ConsignmentId == consignmentid);
                if (consignment1 != null)
                {
                    consignment1.ConsignmentType = consignment.ConsignmentType;
                    consignment1.DateOfBooking = consignment.DateOfBooking;
                    consignment1.ExpectedDeliveryDate = consignment.ExpectedDeliveryDate;
                    consignment1.ConsigneeId = consignment.ConsigneeId;
                    consignment1.ConsignerId = consignment.ConsignerId;
                    context.SaveChanges();
                    var fb = new Feedback() { Result = true, Message = "Consignment Updated" };
                    return fb;
                }
                else
                {

                    var fb = new Feedback() { Result = false, Message = "Consignment not found" };
                    return fb;
                }
            }
            catch (Exception ex)
            {
                var fb = new Feedback() { Result = false, Message = ex.Message };
                return fb;
            }
        }

        //Validating User login credentials
        public User ValidateUser(Login login)
        {
            return context.Users.SingleOrDefault(u => u.Email == login.EmailID && u.Password == login.Password);
        }

        public Bill ViewBillByBillNo(int billNo)
        {
            return context.Bills.SingleOrDefault(s => s.BillNo == billNo);
        }

        //View Consignee By ID
        public Consignee ViewConsignee(int consigneeid)
        {
            return context.Consignees.SingleOrDefault(s => s.ConsigneeId == consigneeid);
        }

        //View Consigner By ID
        public Consigner ViewConsigner(int consignerid)
        {
            return context.Consigners.SingleOrDefault(s => s.ConsignerId == consignerid);
        }

        //View Consignment By ID
        public Consignment ViewConsignment(int consignmentid)
        {
            return context.Consignments.SingleOrDefault(s => s.ConsignmentId == consignmentid);
        }
    }
}