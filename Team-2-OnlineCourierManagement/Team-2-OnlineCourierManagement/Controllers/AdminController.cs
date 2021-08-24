using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Team_2_OnlineCourierManagement.Repositories;
using Team_2_OnlineCourierManagement.Entities;
using Microsoft.AspNetCore.Authorization;

namespace Team_2_OnlineCourierManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class AdminController : ControllerBase
    {
        private IAdminRepository repo;
        //Constructor
        public AdminController(IAdminRepository repo)
        {
            this.repo = repo;
        }

        //Viewing consignee by ConsigneeID
        [HttpGet]
        [Route("ViewConsignee/{consigneeId}")]
        public IActionResult ViewConsignee(int consigneeId)
        {
            Consignee consignee = repo.ViewConsignee(consigneeId);
            if (consignee != null)
            {
                return Ok(consignee);
            }
            else
            {
                return BadRequest("ConsigneeID not valid");
            }
        }

        //Viewing consigner by ConsignerID
        [HttpGet]
        [Route("ViewConsigner/{consignerId}")]
        public IActionResult ViewConsigner(int consignerId)
        {
            Consigner consigner = repo.ViewConsigner(consignerId);
            if (consigner != null)
            {
                return Ok(consigner);
            }
            else
            {
                return BadRequest("ConsignerID not valid");
            }
        }

        //Viewing consignment by ConsignmentID
        [HttpGet]
        [Route("ViewConsignment/{consignmentId}")]
        public IActionResult ViewConsignment(int consignmentId)
        {
            Consignment consignment = repo.ViewConsignment(consignmentId);
            if (consignment != null)
            {
                return Ok(consignment);
            }
            else
            {
                return BadRequest("ConsignmentID not valid");
            }
        }

        //Viewing consignments for a particular date
        [HttpGet]
        [Route("ViewConsignmentsByDate")]
        public IActionResult ViewConsignmentsByDate(DateTime date)
        {
            var consignments = repo.ViewConsignmentsByDate(date);
            return Ok(consignments);
        }

        //Viewing consignments within a peroid of days
        [HttpGet]
        [Route("ViewConsignmentsBetweenSelectedDays")]
        public IActionResult ViewConsignmentsBetweenSelectedDays(DateTime StartingDate, DateTime EndDate)
        {
            var consignments = repo.ViewConsignmentsBetweenSelectedDays(StartingDate, EndDate);
            return Ok(consignments);
        }

        //Viewing consignments within a peroid of days
        [HttpGet]
        [Route("ViewUserById/{userId}")]
        public IActionResult ViewUserById(int userId)
        {
            User user = repo.ViewUserById(userId);
            if (user != null)
            {
                return Ok(user);
            }
            else
            {
                return BadRequest("ConsignmentID not valid");
            }
        }

        //Viewing Delivery Executive by their ID
        [HttpGet]
        [Route("ViewDeliveryExecutiveById/{deliveryExecutiveId}")]
        public IActionResult ViewDeliveryExecutiveById(int deliveryExecutiveId)
        {
            DeliveryExecutive deliveryExecutive = repo.ViewDeliveryExecutive(deliveryExecutiveId);
            if (deliveryExecutive != null)
            {
                return Ok(deliveryExecutive);
            }
            else
            {
                return BadRequest("ConsignmentID not valid");
            }
        }

        //Adding new Admin
        [HttpPost]
        [Route("AddAdmin")]
        public IActionResult AddAdmin(Admin admin, Role role)
        {
            if (admin != null)
            {
                Feedback feedback = repo.AddAdmin(admin, role);
                return Ok(feedback.Message);
            }
            else
            {
                return BadRequest("Admin not entered");
            }

        }

        //Adding new Delivery Executive
        [HttpPost]
        [Route("AddDeliveryExecutive")]
        public IActionResult AddDeliveryExecutive(DeliveryExecutive deliveryExecutive,Role role)
        {
            if (deliveryExecutive != null)
            {
                Feedback feedback=repo.AddDeliveryExecutive(deliveryExecutive,role);
                return Ok(feedback.Message);
            }
            else
            {
                return BadRequest("deliveryExecutive not entered");
            }
            
        }

        //Adding new User
        [HttpPost]
        [Route("AddUser")]
        public IActionResult AddUser(User user,Role role)
        {
            if (user != null)
            {
                Feedback feedback= repo.AddUser(user,role);
                return Ok(feedback.Message);
            }
            else {
                return BadRequest("User not entered");
            }
        }

        //Assigning a consignment to Delivery Executive
        [HttpPost]
        [Route("AssignConsignmentToDeliveryExecutive")]
        public IActionResult AssignConsignmentToDeliveryExecutive(int deliveryExecutiveId, int consignmentid)
        {
            if (deliveryExecutiveId != 0 && consignmentid != 0)
            {
                Feedback feedback=repo.AssignConsignmentToDeliveryExecutive(deliveryExecutiveId,consignmentid);
                return Ok(feedback.Message);
            }
            else
            {
                return BadRequest("deliveryExecutiveId & consignmentid could not be found ");
            }
        }

        //Assigning charges for consignments
        [HttpPost]
        [Route("AddConsignmentCharges")]
        public IActionResult AddConsignmentCharges(int consignmentid, double charges)
        {
            if (consignmentid != 0)
            {
                Feedback feedback = repo.AddConsignmentCharges(consignmentid, charges);
                return Ok(feedback.Message);
            }
            else
            {
                return BadRequest("User not entered");
            }
        }

        //Deleteing a Delivery Executive
        [HttpDelete]
        [Route("DeleteDeliveryExecutive")]
        public IActionResult DeleteDeliveryExecutive(int exid)
        {
            
            if (exid != 0)
            {
                Feedback feedback = repo.DeleteDeliveryExecutive(exid);
                return Ok(feedback.Message);
            }
            else
            {
                return BadRequest("User not entered");
            }
        }

        //Deleteing a User
        [HttpDelete]
        [Route("DeleteUser")]
        public IActionResult DeleteUser(int userid)
        {
            if (userid != 0)
            {
                Feedback feedback = repo.DeleteUser(userid);
                return Ok(feedback.Message);
            }
            else
            {
                return BadRequest("User not entered");
            }
            
        }

        //Updating Delivery Executive details
        [HttpPut]
        [Route("UpdateDeliveryExecutive")]
        public IActionResult UpdateDeliveryExecutive(DeliveryExecutive deliveryExecutive,int deliveryExecutiveid)
        {
            if (deliveryExecutive != null)
            {
                Feedback feedback = repo.UpdateDeliveryExecutive(deliveryExecutive, deliveryExecutiveid);
                return Ok(feedback.Message);
            }
            else
            {
                return BadRequest("User not entered");
            }
            
        }

        //Updating User details
        [HttpPut]
        [Route("UpdateUser")]
        public IActionResult UpdateUser(User user, int userid)
        {
            if (user != null)
            {
                Feedback feedback = repo.UpdateUser(user, userid);
                return Ok(feedback.Message);
            }
            else
            {
                return BadRequest("User not entered");
            }
            
        }


        //Updating Consignments charges
        [HttpPut]
        [Route("UpdateConsignmentCharges")]
        public IActionResult UpdateConsignmentCharges(int consignmentid, double charges)
        {
            if (consignmentid != 0)
            {
                Feedback feedback = repo.UpdateConsignmentCharges(consignmentid, charges);
                return Ok(feedback.Message);
            }
            else
            {
                return BadRequest("User not entered");
            }
           
        }
    }
}
