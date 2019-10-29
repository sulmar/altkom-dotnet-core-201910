using Altkom.DotnetCore.Infrastructure;
using Altkom.DotnetCore.Models;
using Altkom.DotnetCore.Models.SearchCriterias;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Altkom.DotnetCore.WebApi.Controllers
{
    [Route("api/[controller]")]
   // [Route("api/klienci")]
   // [ApiController]
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

        // curl https://localhost:5001/api/customers
        // curl -X GET https://localhost:5001/api/customers
        //[HttpGet]
        //public IActionResult Pobierz()
        //{
        //    var customers = customerRepository.Get();

        //    return Ok(customers);
        //}

        // GET api/customers/10
        [HttpGet("{id:int}", Name = nameof(GetById))]
        public IActionResult GetById(int id)
        {
            var customer = customerRepository.Get(id);

            return Ok(customer);
        }

        // GET api/customers/Smith
        [HttpGet("{lastName}")]
        public IActionResult Get(string lastName)
        {
            var customer = customerRepository.Get(lastName);

            if (customer == null)
                return NotFound();

            return Ok(customer);
        }

        // GET api/customers?city=Poznan&street=Umultowska&country=Poland
        //[HttpGet]
        //public IActionResult Get(string city, string street, string country)
        //{
        //    var customers = customerRepository.Get(city, street);

        //    return Ok(customers);
        //}

        // GET api/customers? city = Poznan & street = Umultowska & country = Poland
        [HttpGet]
        public IActionResult Get([FromQuery] CustomerSearchCriteria searchCriteria)
        {
            var customers = customerRepository.Get(searchCriteria);

            return Ok(customers);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Customer customer)
        {
            customerRepository.Add(customer);

            //string url = $"http://localhost:5000/api/customers/{customer.Id}";
            //return Created(url, customer);

            // return CreatedAtRoute(new { Id = customer.Id }, customer);

            return CreatedAtRoute(nameof(GetById), new { Id = customer.Id }, customer);


        }

    }
}
