using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Team_2_OnlineCourierManagement.Entities;
using Team_2_OnlineCourierManagement.Repositories;

namespace Team_2_OnlineCourierManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin,DeliveryExecutive")]
    
    public class DeliveryExecutiveController : ControllerBase
    {
        
        private IDeliveryExecutiveRepository repo;
        //Constructor
        public DeliveryExecutiveController(IDeliveryExecutiveRepository _repo)
        {
            repo = _repo;
        }

        //View Consignments By ID
        [HttpGet]
        [Route("ViewConsignment")]
        [Authorize(Roles = "DeliveryExecutive")]
        public IActionResult ViewConsignment(int consignmentid,int exId)
        {
            Consignment consignment = repo.ViewConsignmentById(consignmentid,exId);
            if (consignment != null)
            {
                return Ok(consignment);
            }
            else
                return NotFound("Invalid Input");
        }

        //View Assigned Consignments By ID
        [HttpGet]
        [Route("ViewAssignedConsignment/{exId}")]
        [Authorize(Roles = "DeliveryExecutive")]
        public IActionResult ViewAssignedConsignment(int exId)
        {
            var consignment = repo.ViewAssignedConsignment(exId);
            if (consignment != null)
            {
                return Ok(consignment);
            }
            else
                return NotFound("Invalid Input");
        }

        //Setting or updating Consignment status
        [HttpPost]
        [Route("SetConsignmentStatus")]
        [Authorize(Roles = "DeliveryExecutive")]
        public IActionResult SetConsignmentStatus(int consignmentid, ConsignmentStatus status) 
        {
            Feedback feedback= repo.SetConsignmentStatus (consignmentid,status);
            if (feedback.Result)
            {
                return Ok("Consignment Status Updated");
            }
            else
                return NotFound("Invalid Input");
        }
    }
} 
