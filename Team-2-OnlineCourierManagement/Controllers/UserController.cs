using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Team_2_OnlineCourierManagement.Entities;
using Team_2_OnlineCourierManagement.Repositories;

using Team_2_OnlineCourierManagement.Models;

namespace Team_2_OnlineCourierManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin,User")]
    public class UserController : ControllerBase
    {
        
        private IUserRepository userRepository;
        //Constructor
        public UserController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        //Viewing Consignments by ID
        [HttpGet]
        [Route("ViewConsignment/{consignmentId}")]
        //[Authorize(Roles = "User")]
        public IActionResult ViewConsignment(int consignmentId)
        {
            Consignment consignment = userRepository.ViewConsignment(consignmentId);
            if (consignment != null)
            {

                return Ok(consignment);
            }
            else
            {
                return BadRequest("ConsignmentID not valid");
            }
        }

        //Viewing Consignees by ID
        [HttpGet]
        [Route("ViewConsignee/{consigneeId}")]
        //[Authorize(Roles = "User")]
        public IActionResult ViewConsignee(int consigneeId)
        {
            Consignee consignee = userRepository.ViewConsignee(consigneeId);
            if (consignee != null)
            {
                return Ok(consignee);
            }
            else
            {
                return BadRequest("ConsigneeID not valid");
            }
        }

        //Viewing Consigners by ID
        [HttpGet]
        [Route("ViewConsigner/{consignerId}")]
        //[Authorize(Roles = "User")]
        public IActionResult ViewConsigner(int consignerId)
        {
            Consigner consigner = userRepository.ViewConsigner(consignerId);
            if (consigner != null)
            {
                return Ok(consigner);
            }
            else
            {
                return BadRequest("ConsignerID not valid");
            }
        }

        //Viewing Bills by ID
        [HttpGet]
        [Route("ViewBillByBillNo")]
        //[Authorize(Roles = "User")]
        public IActionResult ViewBillByBillNo(int billNo)
        {
            Bill bill = userRepository.ViewBillByBillNo(billNo);
            if (bill != null)
            {
                return Ok(bill);
            }
            else
            {
                return BadRequest("Bill number is not valid");
            }
        }

        //Adding a Consignee to database
        [HttpPost]
        [Route("AddConsignee")]
        //[Authorize(Roles = "User")]
        public IActionResult AddConsignee(Consignee consignee,Role role)
        {
            if (consignee != null)
            {
                Feedback feedback = userRepository.AddConsignee(consignee,role);
                return Ok(feedback.Message);
            }
            else
            {
                return BadRequest("User not entered");
            }
        }

        //Adding a Consigner to database
        [HttpPost]
        [Route("AddConsigner")]
        //[Authorize(Roles = "User")]
        public IActionResult AddConsigner(Consigner consigner,Role role)
        {
            if (consigner != null)
            {
                Feedback feedback = userRepository.AddConsigner(consigner,role);
                return Ok(feedback.Message);
            }
            else
            {
                return BadRequest("User not entered");
            }
        }

        //Adding a Consignment to database
        [HttpPost]
        [Route("AddConsignment")]
        //[Authorize(Roles = "User")]
        public IActionResult AddConsignment(Consignment consignment)
        {
            if (consignment != null)
            {
                Feedback feedback = userRepository.AddConsignment(consignment);
                return Ok(feedback.Message);
            }
            else
            {
                return BadRequest("User not entered");
            }
        }

        //Generating a bill for a consignment
        [HttpPost]
        [Route("GenerateBill")]
        //[Authorize(Roles = "User")]
        public IActionResult GenerateBill(Bill bill, int consignmentId)
        {
            if (bill != null)
            {
                Feedback feedback = userRepository.GenerateBill(bill, consignmentId);
                return Ok(feedback.Message);
            }
            else
            {
                return BadRequest("Bill  not entered");
            }
        }

        //Deleting a User
        [HttpDelete]
        [Route("DeleteConsignee")]
        //[Authorize(Roles = "User")]
        public IActionResult DeleteConsignee(int consigneeid)
        {
            if (consigneeid != 0)
            {
                Feedback feedback = userRepository.DeleteConsignee(consigneeid);
                return Ok(feedback.Message);
            }
            else
            {
                return BadRequest("ConsigneeID not valid");
            }
        }

        //Deleting a Consigner
        [HttpDelete]
        [Route("DeleteConsigner")]
        //[Authorize(Roles = "User")]
        public IActionResult DeleteConsigner(int consignerid)
        {
            if (consignerid != 0)
            {
                Feedback feedback = userRepository.DeleteConsigner(consignerid);
                return Ok(feedback.Message);
            }
            else
            {
                return BadRequest("ConsignerID not valid");
            }
        }

        //Deleting a User
        [HttpDelete]
        [Route("DeleteConsignment")]
        //[Authorize(Roles = "User")]
        public IActionResult DeleteConsignment(int consignmentid)
        {
            if (consignmentid != 0)
            {
                Feedback feedback = userRepository.DeleteConsignment(consignmentid);
                return Ok(feedback.Message);
            }
            else
            {
                return BadRequest("ConsignmentID not valid");
            }
        }

        //Updating Consignee
        [HttpPut]
        [Route("UpdateConsignee")]
        //[Authorize(Roles = "User")]
        public IActionResult UpdateConsignee(Consignee consignee, int consigneeid)
        {
            if (consignee != null)
            {
                Feedback feedback = userRepository.UpdateConsignee(consignee, consigneeid);
                return Ok(feedback.Message);
            }
            else
            {
                return BadRequest("Consignee not entered");
            }
        }

        //Updating Consigner
        [HttpPut]
        [Route("UpdateConsigner")]
        //[Authorize(Roles = "User")]
        public IActionResult UpdateConsigner(Consigner consigner, int consignerid)
        {
            if (consigner != null)
            {
                Feedback feedback = userRepository.UpdateConsigner(consigner, consignerid);
                return Ok(feedback.Message);
            }
            else
            {
                return BadRequest("Consigner not entered");
            }
        }

        //Updating Consignment
        [HttpPut]
        [Route("UpdateConsignment")]
        //[Authorize(Roles = "User")]
        public IActionResult UpdateConsignment(Consignment consignment, int consignmentid)
        {
            if (consignment != null)
            {
                Feedback feedback = userRepository.UpdateConsignment(consignment, consignmentid);
                return Ok(feedback.Message);
            }
            else
            {
                return BadRequest("Consignment not entered");
            }
        }

    }
}
