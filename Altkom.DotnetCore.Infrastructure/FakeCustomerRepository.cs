using Altkom.DotnetCore.Infrastructure.Fakers;
using Altkom.DotnetCore.Models;
using Altkom.DotnetCore.Models.SearchCriterias;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Altkom.DotnetCore.Infrastructure
{
    public class CustomerOptions
    {
        public int Count { get; set; }
    }

    public class FakeCustomerRepository : ICustomerRepository
    {
        private ICollection<Customer> customers;

        // dotnet add package Microsoft.Extensions.Options
        public FakeCustomerRepository(IOptions<CustomerOptions> options, CustomerFaker customerFaker)
        {
            customers = customerFaker.Generate(options.Value.Count);
        }

        public void Add(Customer customer)
        {
            customers.Add(customer);
        }

        public IEnumerable<Customer> Get()
        {
            return customers;
        }

        public Customer Get(int id)
        {
            return customers.SingleOrDefault(customer => customer.Id == id);
        }

        public IEnumerable<Customer> Get(string city, string street)
        {
            return customers
                .Where(customer => customer.HomeAddress.City == city 
                || customer.HomeAddress.Street == street)
                .ToList();
        }

        public Customer Get(string lastname)
        {
            return customers.SingleOrDefault(c => c.LastName == lastname);
        }

        public IEnumerable<Customer> Get(CustomerSearchCriteria searchCriteria)
        {
            IQueryable<Customer> results = customers.AsQueryable();

            // Expression
            if (!string.IsNullOrEmpty(searchCriteria.City))
            {
                results = results.Where(c => c.HomeAddress.City == searchCriteria.City);
            }

            if (!string.IsNullOrEmpty(searchCriteria.Street))
            {
                results = results.Where(c => c.HomeAddress.Street == searchCriteria.Street);
            }

            if (!string.IsNullOrEmpty(searchCriteria.Country))
            {
                results = results.Where(c => c.HomeAddress.Country == searchCriteria.Country);
            }

            return results.ToList();
        }

        //public Customer GetOld(int id)
        //{
        //    foreach (var customer in customers)
        //    {
        //        if (customer.Id == id)
        //        {
        //            return customer;
        //        }
        //    }

        //    return null;
        //}

        public void Remove(int id)
        {
            customers.Remove(Get(id));
        }

        public void Update(Customer customer)
        {
            throw new NotImplementedException();
        }
    }
}
