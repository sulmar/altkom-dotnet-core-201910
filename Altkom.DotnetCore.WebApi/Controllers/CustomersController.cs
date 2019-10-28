using Altkom.DotnetCore.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Altkom.DotnetCore.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Route("api/klienci")]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerRepository customerRepository;
        
        //public CustomersController()
        //    : this(new FakeCustomerRepository(new Infrastructure.Fakers.CustomerFaker()))
        //{

        //}


        public CustomersController(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        [HttpGet]
        public IActionResult Pobierz()
        {
            var customers = customerRepository.Get();

            return Ok(customers);
        }

        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            var customer = customerRepository.Get(id);

            return Ok(customer);
        }


        [HttpGet("{lastName}")]
        public IActionResult Get(string lastName)
        {
            var customer = customerRepository.Get(lastName);

            if (customer == null)
                return NotFound();

            return Ok(customer);
        }

    }
}
