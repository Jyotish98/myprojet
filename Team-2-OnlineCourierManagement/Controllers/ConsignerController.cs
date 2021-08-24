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
    [Authorize(Roles = "Admin,Consigner")]
    
    public class ConsignerController : ControllerBase
    {
        private IConsignerRepository repo;
        //Constructor
        public ConsignerController(IConsignerRepository _repo)
        {
            repo = _repo;
        }

        //View Consignments By ID
        [HttpGet]
        [Route("ViewConsignmentById")]
        [Authorize(Roles = "Consigner")]
        public IActionResult ViewConsignmentById(int consignmentid, int consignerId)
        {
            Consignment consignment = repo.ViewConsignmentByID(consignmentid, consignerId);
            if (consignment != null)
            {
                return Ok(consignment);
            }
            else
                return NotFound("Invalid Consignmentid");
        }

        //View Consignments By ID
        [HttpGet]
        [Route("ViewConsignments")]
        [Authorize(Roles = "Consigner")]
        public IActionResult ViewConsignments(int consignerid)
        {
            var result = repo.ViewConsignments(consignerid);
            if (result != null)
            {
                return Ok(result);
            }
            else
                return NotFound("Invalid Consignmentid");
        }
    }
}
