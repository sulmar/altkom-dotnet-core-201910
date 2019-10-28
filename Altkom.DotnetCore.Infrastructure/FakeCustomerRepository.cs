using Altkom.DotnetCore.Infrastructure.Fakers;
using Altkom.DotnetCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Altkom.DotnetCore.Infrastructure
{
    public class FakeCustomerRepository : ICustomerRepository
    {
        private ICollection<Customer> customers;

        public FakeCustomerRepository(CustomerFaker customerFaker)
        {
            customers = customerFaker.Generate(100);
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
                .Where(customer => customer.HomeAddress.City == city || customer.HomeAddress.Street == street)
                .ToList();
        }

        public Customer Get(string lastname)
        {
            return customers.SingleOrDefault(c => c.LastName == lastname);
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
