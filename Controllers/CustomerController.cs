using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test_App.Repository;
using Test_App.RequestModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Test_App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepo _customerrepo;
        public CustomerController(ICustomerRepo customerrepo)
        {
            _customerrepo = customerrepo;
        }
        [HttpPost("createCustomer")]
        public async Task<IActionResult> createCustomer(CreateRequestModel obj)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var result = await _customerrepo.CreateCustomer(obj);

            return Ok(result);
        }

        [HttpGet("getallCustomers")]
        public async Task<IActionResult> getallCustomers()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var result = await _customerrepo.GetAllCustomers();

            return Ok(result);
        }


        [HttpGet("getCustomerById")]
        public async Task<IActionResult> getCustomerById(long cusId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var result = await _customerrepo.getCustomerById(cusId);

            return Ok(result);
        }

        [HttpGet("getCustomerbyFullName")]
        public async Task<IActionResult> getCustomerbyFullNameAsync(string Firstname, string Lastname)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var result = await _customerrepo.getCustomerbyFullName(Firstname, Lastname);

            return Ok(result);
        }

    }
}
