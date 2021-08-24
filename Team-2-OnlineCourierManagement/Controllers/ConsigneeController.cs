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
    [Authorize(Roles = "Admin,Consignee")]
    public class ConsigneeController : ControllerBase
    {
        
        private IConsigneeRepository repo;
        //Constructor
        public ConsigneeController(IConsigneeRepository repo)
        {
           this.repo = repo;
        }

        //View Consignments By ID
        [HttpGet]
        [Route("ViewConsignmentById")]
        //[Authorize(Roles = "Consignee")]
        public IActionResult ViewConsignmentById(int consignmentid,int consigneeId)
        {
            Consignment consignment = repo.ViewConsignmentByID(consignmentid, consigneeId);
            if (consignment != null)
            {
                return Ok(consignment);
            }
            else
                return NotFound("Invalid Consignmentid");
        }

        //View Consignments
        [HttpGet]
        [Route("ViewConsignments")]
        //[Authorize(Roles = "Consignee")]
        public IActionResult ViewConsignments(int consigneeid)
        {
            var result= repo.ViewConsignments(consigneeid);
            if (result != null)
            {
                return Ok(result);
            }
            else
                return NotFound("Invalid Consignmentid");
        }
    }
}
