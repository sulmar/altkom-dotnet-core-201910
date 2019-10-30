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


        // dotnet add package Microsoft.AspNetCore.Mvc.Api.Analyzers

        // GET api/customers/10
        /// <summary>
        /// Get customer by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id:int}", Name = nameof(GetById))]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]       
        public IActionResult GetById(int id)
        {
            var customer = customerRepository.Get(id);

            if (customer == null)
                return NotFound();

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

        // POST api/customers
        [HttpPost]
        public IActionResult Post([FromBody] Customer customer)
        {
            customerRepository.Add(customer);

            //string url = $"http://localhost:5000/api/customers/{customer.Id}";
            //return Created(url, customer);

            // return CreatedAtRoute(new { Id = customer.Id }, customer);

            return CreatedAtRoute(nameof(GetById), new { Id = customer.Id }, customer);


        }

        // PUT api/customers/10
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Customer customer)
        {
            if (id != customer.Id)
                return BadRequest();

            customerRepository.Update(customer);

            return Ok();
        }

        // DELETE api/customers/10
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            customerRepository.Remove(id);

            return Ok();
        }

        // GET /api/customers/10/orders

        [HttpGet("{id}/orders")]
        public IActionResult GetOrders(int customerId)
        {
            throw new NotImplementedException();
        }

        // GET /api/customers?barcode=XYZ32382

        // GET /api/products/XYZ32382/customers
        [HttpGet("~/api/products/{barcode}/customers")]
        public IActionResult GetCustomersByProduct(string barcode)
        {
            throw new NotImplementedException();
        }


        // GET /api/customers/10/orders/2/details

    }
}
